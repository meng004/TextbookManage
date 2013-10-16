using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.InventoryService;

namespace TextbookManage.WebUI.Inventory
{
    public partial class InStock : USCTAMis.Web.WebControls.Page
    {

        //private readonly string _loginName = "dongxb";
        private readonly string _loginName = HttpContext.Current.User.Identity.Name;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccbxStorage.DoDataBind();                
            }
        }

        protected void ccbxStorage_BeforeDataBind(object sender, EventArgs e)
        {
            using (InventoryApplClient client = new InventoryApplClient())
            {
                ccbxStorage.DataSource = client.GetStorages(_loginName);
            }
        }

        protected void cgrdTextbook_BeforeDataBind(object sender, EventArgs e)
        {
            var name = ctxtTextbookName.Text.Trim();
            var isbn = ctxtIsbn.Text.Trim();

            using (InventoryApplClient client = new InventoryApplClient())
            {
                cgrdTextbook.DataSource = client.GetTextbooksByName(name, isbn);
            }
        }

        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctxtTextbookName.Text.Trim()) && string.IsNullOrWhiteSpace(ctxtIsbn.Text.Trim()))
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请输入教材名称 或 ISBN进行查询");
                return;
            }
            cgrdTextbook.DoDataBind();
        }
    }
}