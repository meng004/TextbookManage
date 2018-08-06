using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_6;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_6;
using CPMis.Model.Tb_Maintain.Tb_Maintain_6;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_6
{
    public partial class DiscountUpdate : System.Web.UI.Page
    {
        //业务逻辑层
        private IDiscountMaintainBLL _discountMaintainBLL = new DiscountMaintainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string id = Request.Params["id"];
                DiscountModel temp = _discountMaintainBLL.Fn_DiscountGetById(id);

                //增加学期查询的
                cdlstTerm.DoDataBind();

                ctxtBooksellerName.Text = temp.BooksellerName;
                ctxtDiscount.Text = temp.Discount.ToString();
                ctxtDiscountPrice.Text = temp.DiscountPrice.ToString();
                ctxtStockName.Text = temp.StockName;
                ctxtStoreCount.Text = temp.StoreCount.ToString();
                ctxtTextbookName.Text = temp.TextbookName;
                ctxtRetailPrice.Text = temp.RetailPrice.ToString();
            }
        }


        /// <summary>
        /// 下拉列表数据绑定前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdlstTerm_BeforeDataBind(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 下拉列表数据绑定后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdlstTerm_AfterDataBind(object sender, EventArgs e)
        {
            cdlstTerm.DefaultIndex = cdlstTerm.Items.FindItemIndexByText(ctxtBooksellerName.Text);
        }

        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            string message = "";
            DiscountModel temp = new DiscountModel();

            temp.InventoryTextbookDiscountID = Request.Params["id"];
            temp.Term = cdlstTerm.SelectedText;
            temp.Discount = Convert.ToDecimal(ctxtDiscount.Text);
            temp.DiscountPrice = Convert.ToDecimal(ctxtDiscountPrice.Text);
            _discountMaintainBLL.Fn_DiscountUpdate(temp, ref message);

            Response.Write("<script>alert('" + message + "');</script>");
        }


        //计算折后价
        protected void ctxtDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal temp = Convert.ToDecimal(ctxtDiscount.Text);
            if (ctxtDiscount.Text == temp.ToString())
            {
                if (temp > 0 && temp < 1)
                {
                    ctxtDiscountPrice.Text = (temp * Convert.ToDecimal(ctxtRetailPrice.Text)).ToString();
                }
            }
        }
    }
}