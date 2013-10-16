using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.InventoryService;

namespace TextbookManage.WebUI.Inventory
{
    public partial class InStockForm : USCTAMis.Web.WebControls.Page
    {

        #region 属性与pageload

        //private readonly string _loginName = "dongxb";
        private readonly string _loginName = HttpContext.Current.User.Identity.Name;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var storageId = Request.QueryString["StorageId"];
                var textbookId = Request.QueryString["TextbookId"];
                //仓库id 与 教材ID 不为空
                if (!string.IsNullOrWhiteSpace(storageId) && !string.IsNullOrWhiteSpace(textbookId))
                {
                    using (InventoryApplClient client = new InventoryApplClient())
                    {
                        var view = client.GetInventory(storageId, textbookId);
                        SetForm(view);
                    }
                }

            }
        }
        #endregion

        #region 私有方法
        
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="view"></param>
        private void SetForm(InventoryView view)
        {

            ctxtInventoryId.Text = view.InventoryId;
            ctxtStorageId.Text = view.StorageId;
            ctxtTextbookId.Text = view.TextbookId;

            ctxtAuthor.Text = view.Author;
            ctxtPress.Text = view.Press;
            ctxtTextbookNum.Text = view.Num;
            ctxtTextbookName.Text = view.Name;
            ctxtISBN.Text = view.Isbn;
            ctxtInventoryCount.Text = view.InventoryCount.ToString();
            ctxtShelfNumber.Text = view.ShelfNumber;
        }

        /// <summary>
        /// 取回表单
        /// </summary>
        /// <returns></returns>
        private InventoryView GetForm()
        {
            var inventoryCount = 0;
            int.TryParse(ctxtInventoryCount.Text.Trim(), out inventoryCount);

            return new InventoryView
            {
                InventoryId = ctxtInventoryId.Text.Trim(),
                StorageId = ctxtStorageId.Text.Trim(),
                TextbookId = ctxtTextbookId.Text.Trim(),
                InventoryCount = inventoryCount,
                ShelfNumber = ctxtShelfNumber.Text.Trim()
            };
        }
        #endregion

        #region 按钮

        protected void cbtnSubmit_BeforeClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (InventoryApplClient client = new InventoryApplClient())
                {
                    //取表单
                    var view = GetForm();                    

                    var instockCount = ctxtInStockCount.Text.Trim();

                    var result = client.SubmitInStock(view, instockCount, _loginName);

                    USCTAMis.Web.WebClient.ScriptManager.AlertAndClose(result.Message);
                }
            }
        }

        protected void cbtnSubmit_AfterClick(object sender, EventArgs e)
        {
            USCTAMis.Web.WebClient.ScriptManager.ExecuteJs("Sys.Application.add_load(Close);");
        }

        #endregion


    }
}