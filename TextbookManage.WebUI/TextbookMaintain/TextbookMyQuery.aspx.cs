using System;
using System.Linq;
using System.Web;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.WebUI.TextbookMaintain
{
    public partial class TextbookMyQuery : CPMis.Web.WebControls.Page
    {
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();
        private readonly string _loginName = HttpContext.Current.User.Identity.Name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cgrdMyBookQuery.DoDataBind();
            }
        }

        #region Ajax回调

        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                case "Delete":
                    BatchDeleteBooks();
                    cgrdMyBookQuery.DoDataBind();
                    break;
                default:
                    cgrdMyBookQuery.DoDataBind();
                    break;
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 批量删除
        /// </summary>
        private void BatchDeleteBooks()
        {

            //取选中的图书
            cgrdMyBookQuery.PersistCheckState<TextbookForQueryView>();
            var books = cgrdMyBookQuery.GetAllCheckedDataList<TextbookForQueryView>();

            //删除
            var result = _impl.Remove(books.ToArray());

            CPMis.Web.WebClient.ScriptManager.Alert(result.Message);

        }
        #endregion

        #region 个人申报教材


        protected void cgrdMyBookQuery_BeforeDataBind(object sender, EventArgs e)
        {
            //获取gridview数据源

            //cgrdBookQuery.DataSource = client.GetByLoginName(Page.User.Identity.Name);
            cgrdMyBookQuery.DataSource = _impl.GetByLoginName(_loginName);

        }

        protected void cgrdMyBookQuery_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            //保持Checked状态
            cgrdMyBookQuery.PersistCheckState<TextbookForQueryView>();
        }

        protected void cchkMyCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            var chk = sender as CPMis.Web.WebControls.CPMisCheckBox;
            cgrdMyBookQuery.SetAllCheckControlState(chk.Checked);
        }
        #endregion

    }
}