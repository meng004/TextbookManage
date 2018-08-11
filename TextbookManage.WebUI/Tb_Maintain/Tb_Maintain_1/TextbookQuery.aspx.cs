using System;
using CPMis.Web.WebControls;
using Telerik.Web.UI;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.WebUI.Tb_Maintain.Tb_Maintain_1
{
    public partial class TextbookQuery : CPMis.Web.WebControls.Page
    {
        private ITextbookAppl _appl = ServiceLocator.Current.GetInstance<ITextbookAppl>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GdTextbooks.DoDataBind();
            }
        }



        protected void RadAjaxManager1_OnAjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            var argument = e.Argument;
            switch (argument)
            {
                case "Delete":
                    DeleteTextbook();
                    break;
                case "Help":
                    //OpenHelpFile("/Help/SystemManage/系统管理.htm");
                    break;
                default:
                    GdTextbooks.DoDataBind();
                    break;
            }
        }


        private void DeleteTextbook()
        {
            //取出选中的记录
            SaveCheckedState();
            var data = GdTextbooks.GetAllCheckedDataList<TextbookView>();
            if (data.Count > 0)
            {
                //删除
                var result = _appl.Remove(data);
                CPMis.Web.WebClient.ScriptManager.Alert(result.Message);
                GdTextbooks.DoDataBind();
            }
            else
            {
                //客户端消息
                CPMis.Web.WebClient.ScriptManager.Alert("还没有选择待删除的记录!");
            }

        }

        private void SaveCheckedState()
        {
            GdTextbooks.PersistCheckState<TextbookView>();
        }

        private void OpenNewWindow(string url, string textbookId)
        {
            var path = $"{url}?TextbookId={textbookId}";
            CPMis.Web.WebClient.ScriptManager.OpenRadWindow(path, "RadWindow1");
        }

        protected void BtnQuery_OnClick(object sender, EventArgs e)
        {
            GdTextbooks.DoDataBind();
        }

        protected void GdTextbooks_OnBeforeDataBind(object sender, EventArgs e)
        {
            var name = TxtTextbookName.Text.Trim();
            var isbn = TxtIsbn.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)
                && string.IsNullOrWhiteSpace(isbn))
            {
                return;
            }

            var data = _appl.GetByName(name, isbn);
            GdTextbooks.DataSource = data;
        }

        protected void GdTextbooks_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            // convert the ParentControl to a CellItem object
            
            if (!(e.Item is GridDataItem)) return;
            var dataItem = (GridDataItem) e.Item;
            var id = dataItem["TextbookId"].Text;
            var isNotNull = !string.IsNullOrWhiteSpace(id);
            var isNotEmpty = !string.Equals(id, Guid.Empty.ToString());

            //用索引号取当前数据对象
            var data = GdTextbooks.GetData<TextbookView>(e.Item.ItemIndex);

            var key = e.CommandName;

            if (key.Equals("Show") && isNotNull && isNotEmpty)//显示教材详情
            {
                OpenNewWindow("../../WindowForMessage/TextbookDetailMessage.aspx", id);
            }

        }

        protected void GdTextbooks_OnBeforePageIndexChanged(object sender, EventArgs e)
        {
            SaveCheckedState();
        }

        protected void ChkAll_OnCheckedChanged(object sender, EventArgs e)
        {
            var control = sender as CPMisCheckBox;
            var isChecked = control.Checked;
            GdTextbooks.SetAllCheckControlState(isChecked);
        }


    }
}