using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_5
{
    public partial class InventoryUpdate : System.Web.UI.Page
    {
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_5.IInventoryUpdateBLL _IInventoryUpdateBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_5.InventoryUpdateBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctxtTextbookName.Text = Server.UrlDecode(Request.QueryString["textbookName"].ToString());
                ctxtStockName.Text = Server.UrlDecode(Request.QueryString["stockName"].ToString());
                ctxtInputCount.Text = Server.UrlDecode(Request.QueryString["stockInCount"].ToString());
                ctxtStoreCount.Text = Server.UrlDecode(Request.QueryString["storeCount"].ToString());
                ctxtReleseCount.Text = Server.UrlDecode(Request.QueryString["releaseCount"].ToString());
            }
        }

        protected void cbtnSumbit_Click(object sender, EventArgs e)
        {
            string message = "";//消息参数
            Model.Tb_Maintain.Tb_Maintain_5.InventoryModel _para_InventoryModel = new Model.Tb_Maintain.Tb_Maintain_5.InventoryModel();
                _para_InventoryModel.InventoryID = new Guid(Request.QueryString["inventoryID"]);
                _para_InventoryModel.StockInCount =Convert.ToInt32(ctxtInputCount.Text);
                _para_InventoryModel.StoreCount = Convert.ToInt32(ctxtStoreCount.Text);
                _para_InventoryModel.ReleaseCount =Convert.ToInt32(ctxtReleseCount.Text);
                _IInventoryUpdateBLL.Fn_InventoryUpdate(_para_InventoryModel, ref message);
                Response.Write("<script type='text/javascript' language='javascript'>alert('"+ message+"');var oWindow = null;if (window.radWindow) oWindow = window.radWindow;else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;oWindow.close(); </script>");   
        }

        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            ctxtTextbookName.Text = Server.UrlDecode(Request.QueryString["textbookName"].ToString());
            ctxtStockName.Text = Server.UrlDecode(Request.QueryString["stockName"].ToString());
            ctxtInputCount.Text = Server.UrlDecode(Request.QueryString["stockInCount"].ToString());
            ctxtStoreCount.Text = Server.UrlDecode(Request.QueryString["storeCount"].ToString());
            ctxtReleseCount.Text = Server.UrlDecode(Request.QueryString["releaseCount"].ToString());
        }

    }
}