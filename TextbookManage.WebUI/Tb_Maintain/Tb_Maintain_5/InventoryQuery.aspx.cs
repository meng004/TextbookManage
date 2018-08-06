using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_5
{
    public partial class InventoryQuery : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_5.IInventoryQueryBLL _InventoryQueryBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_5.InventoryQueryBLL();
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_5.IInventoryDeleteBLL _IInventoryDeleteBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_5.InventoryDeleteBLL();
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_6.IDiscountMaintainBLL _discountMaintainBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_6.DiscountMaintainBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉列表绑定
                cdlstBooksellerName.DataSourceID = "SqlDataSource3";
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
            ctxtSaveTextbookName.Text = ctxtTextbookName.Text;
            ctxtSaveStockName.Text = cdlstStockName.SelectedValue;
            cgrdStock.DoDataBind();
        }
        protected void cgrdStock_BeforeDataBind(object sender, EventArgs e)
        {
            cgrdStock.DataSource = _InventoryQueryBLL.Fn_InventoryQuery(ctxtSaveTextbookName.Text, ctxtSaveStockName.Text);//给数据源赋值GridViewDeleteEventArgs
        }
        protected void cgrdStock_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                string para_InventoryID = e.CommandArgument.ToString();
                string message ="";//消息参数
                _IInventoryDeleteBLL.Fn_InventoryDelete(para_InventoryID, ref message);
                CPMis.Web.WebClient.ScriptManager.Alert(message);
                cgrdStock.DoDataBind();
            }

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
            cdlstStockName.DataBind();
            cdlstStockName.DataTextField = "StockName";
            cdlstStockName.DataValueField = "StockID";

        }


        #endregion
    }
}