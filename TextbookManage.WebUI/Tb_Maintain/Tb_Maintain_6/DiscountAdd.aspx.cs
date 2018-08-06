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
    public partial class DiscountAdd : System.Web.UI.Page
    {
        //用于新增库存折扣
        private IDiscountMaintainBLL _discountMaintainBLL = new DiscountMaintainBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取URL传值
                string inventoryId = Request.Params["id"];
                //执行查询获取Model
                DiscountModel inventoryModel = _discountMaintainBLL.Fn_InventoryGetById(inventoryId);
                //填充txt
                ctxtTextbookName.Text = inventoryModel.TextbookName;
                ctxtStoreCount.Text = inventoryModel.StoreCount.ToString();
                ctxtStockName.Text = inventoryModel.StockName;
                ctxtRetailPrice.Text = Convert.ToString(inventoryModel.RetailPrice);
                ctxtBooksellerName.Text = inventoryModel.BooksellerName;


                ctxtDiscount.Text = "0.9";
                ctxtDiscountPrice.Text = (inventoryModel.RetailPrice * (decimal)0.9).ToString();

            }
        }

        protected void cbtnAfterSave(object sender, EventArgs e)
        {

        }

        protected void cbtnBeforeSave(object sender, EventArgs e)
        {

        }

        //实时计算折后价
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

        protected void cbtnSave_Click(object sender, EventArgs e)
        {
            //填充model
            DiscountModel temp = new DiscountModel();
            temp.Term = cdlstTerm.SelectedText;
            temp.Discount = Convert.ToDecimal(ctxtDiscount.Text);
            temp.DiscountPrice = Convert.ToDecimal(ctxtDiscountPrice.Text);
            temp.InventoryID = Request.Params["id"];


            string message = string.Empty;
            //_discountMaintainBLL.Fn_DiscountAdd(temp, ref message);
            _discountMaintainBLL.Fn_DiscountAdd(new List<DiscountModel>() { temp });

            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }


        /// <summary>
        /// 实时计算折后价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ctxtDiscount_TextChanged1(object sender, EventArgs e)
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