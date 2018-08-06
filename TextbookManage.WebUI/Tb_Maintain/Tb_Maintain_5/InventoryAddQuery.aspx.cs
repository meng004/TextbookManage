using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_5
{
    public partial class InventoryAddQuery : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_5.IInventoryAddBLL _InventoryAddQuery = new CPMis.BLL.Tb_Maintain.Tb_Maintain_5.InventoryAddBLL();
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
            cgrdStock.DoDataBind();

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
        
        protected void cgrdStock_BeforeDataBind(object sender, EventArgs e)
        {
            cgrdStock.DataSource = _InventoryAddQuery.Fn_InventoryAddQuery(ctxtTextbookName.Text);//给数据源赋值
        }

        protected void cgrdStock_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "insert")
            {
                string message = "";//消息参数
                Model.Tb_Maintain.Tb_Maintain_5.InventoryModel _para_InventoryModel = new Model.Tb_Maintain.Tb_Maintain_5.InventoryModel();
                _para_InventoryModel.TextbookID = e.CommandArgument.ToString();;
                _para_InventoryModel.StockName = cdlstStockName.SelectedValue;
                _InventoryAddQuery.Fn_InventoryAdd(_para_InventoryModel, ref message);
                CPMis.Web.WebClient.ScriptManager.Alert(message);
            }
            
        }
    }
}