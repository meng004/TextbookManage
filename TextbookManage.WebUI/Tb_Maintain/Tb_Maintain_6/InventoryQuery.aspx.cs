using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_5;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_5;
using CPMis.Model.Tb_Maintain.Tb_Maintain_6;
using Telerik.Web.UI;
using CPMis.Web.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_6
{
    public partial class InventoryQuery : System.Web.UI.Page
    {
       
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        //BLL对象
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_6.IDiscountMaintainBLL _discountMaintainBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_6.DiscountMaintainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉列表绑定
                cdlstBooksellerName.DataSourceID = "SqlDataSource2";
                cdlstBooksellerName.DataBind();
                string booksellerId = profile.UserInGroupID;
                for (int i = 0; i < cdlstBooksellerName.Items.Count; i++)
                {
                    if (cdlstBooksellerName.Items[i].Value == booksellerId)
                    {
                        cdlstBooksellerName.SelectedIndex = i;
                        cdlstBooksellerName.Enabled = false;
                        return;
                    }
                }
            }
        }


        protected void cbntQuery_Click(object sender, EventArgs e)
        {
            cdgrdList.DoDataBind();
        }

        #region 下拉列表联动


        /// <summary>
        /// cdlstBooksellerName呈现之前绑定cdlstStockName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdlstBooksellerName_PreRender(object sender, EventArgs e)
        {
            cdlstStockName.DataSource = _discountMaintainBLL.Fn_GetStockInfoByBooksellerID(cdlstBooksellerName.SelectedValue);
            cdlstStockName.DataTextField = "StockName";
            cdlstStockName.DataValueField = "StockID";
            cdlstStockName.DataBind();
        }

        #endregion

        protected void cdgrdList_BeforeDataBind(object sender, EventArgs e)
        {
            cdgrdList.DataSource = _discountMaintainBLL.Fn_InventoryGetList(cdlstStockName.SelectedValue,ctxtTextbookName.Text,cdlstTrem.SelectedText);
        }

        protected void cbtnDiscountAdd_Click(object sender, EventArgs e)
        {
            if (RegularExpressionValidator1.IsValid == false)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("折扣应该是0到1之间的两位小数！");
                return;
            }

            decimal discount = Convert.ToDecimal(ctxtDiscount.Text);

            IList<DiscountModel> discountModelList = new List<DiscountModel>();
            DiscountModel temp;
            
            foreach (GridDataItem dataitem in cdgrdList.MasterTableView.Items)
            {
                CPMisCheckBox cbox = (CPMisCheckBox)dataitem.FindControl("cchk");
                if (cbox.Checked)
                {
                    temp = new DiscountModel();
                    temp.InventoryID = dataitem["InventoryID"].Text;
                    temp.Term = cdlstTrem.SelectedText;
                    temp.Discount = discount;
                    temp.RetailPrice = Convert.ToDecimal(dataitem["RetailPrice"].Text);
                    discountModelList.Add(temp);
                }
            }

            if (discountModelList.Count == 0)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请选择操作数据！");
            }
            else
            {
                int successCount = _discountMaintainBLL.Fn_DiscountAdd(discountModelList);
                CPMis.Web.WebClient.ScriptManager.Alert("您本次操作共选中" + discountModelList.Count.ToString() + "条，其中成功" + successCount.ToString() + "条，失败" + (discountModelList.Count - successCount).ToString() + "条！");
                cdgrdList.DoDataBind();
            }
        }
    }
}