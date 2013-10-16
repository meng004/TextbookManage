using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.InventoryService;


namespace TextbookManage.WebUI.Inventory
{
    public partial class QueryStock : USCTAMis.Web.WebControls.Page
    {

        #region 属性与pageLoad

        //private readonly string _loginName = "dongxb";
        private readonly string _loginName = HttpContext.Current.User.Identity.Name;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccbxStorageByTime.DataBind();
                ccbxStorageByTextbook.DataBind();
            }
        }
        #endregion

        #region 按日期查询

        protected void cbtnQueryByTime_Click(object sender, EventArgs e)
        {
            //是否选择了日期
            if (dtpBeginTime.SelectedDate != null && dtpEndTime.SelectedDate != null)
            {
                if (dtpBeginTime.SelectedDate < dtpEndTime.SelectedDate)
                {
                    cgrdQueryByTime.DataBind();
                }
                else
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert("结束日期 应大于 开始日期");
                }
            }
            else
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请选择日期");
            }
        }

        protected void cgrdQueryByTime_DataBinding(object sender, EventArgs e)
        {
            using (InventoryApplClient client = new InventoryApplClient())
            {
                var storageId = ccbxStorageByTime.SelectedValue;
                var stockType = rblStockTypeByTime.SelectedValue;
                var beginDate = dtpBeginTime.SelectedDate.ToString();
                var endDate = dtpEndTime.SelectedDate.ToString();

                cgrdQueryByTime.DataSource = client.GetStockRecordsByDate(storageId, stockType, beginDate, endDate);
            }
        }

        protected void ccbxStorageByTime_DataBinding(object sender, EventArgs e)
        {
            using (InventoryApplClient client = new InventoryApplClient())
            {
                ccbxStorageByTime.DataSource = client.GetStorages(_loginName);
            }
        }
        #endregion

        #region 按教材查询

        protected void cbtnQueryByTextbook_Click(object sender, EventArgs e)
        {
            var name = ctxtTextbookName.Text.Trim();
            var isbn = ctxtISBN.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(isbn))
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请输入 教材名称 或 ISBN");
                return;
            }
            else
            {
                cgrdQueryByTextbook.DataBind();
            }
        }

        protected void cgrdQueryByTextbook_DataBinding(object sender, EventArgs e)
        {
            using (InventoryApplClient client = new InventoryApplClient())
            {
                var storageId = ccbxStorageByTextbook.SelectedValue;
                var stockType = rblStockTypeByTextbook.SelectedValue;
                var name = ctxtTextbookName.Text.Trim();
                var isbn = ctxtISBN.Text.Trim();

                cgrdQueryByTextbook.DataSource = client.GetStockRecordsByTextbook(storageId, stockType, name, isbn);
            }
        }

        protected void ccbxStorageByTextbook_DataBinding(object sender, EventArgs e)
        {
            using (InventoryApplClient client = new InventoryApplClient())
            {
                ccbxStorageByTextbook.DataSource = client.GetStorages(_loginName);
            }
        }
        #endregion

    }
}