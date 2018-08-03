using System;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.WebUI.TextbookMaintain
{
    public partial class TextbookQuery : CPMis.Web.WebControls.Page
    {
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cgrdBookQuery.DoDataBind();
            }
        }

        #region 查询

        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            //gridview数据绑定
            cgrdBookQuery.DoDataBind();
        }
        #endregion

        #region Grid事件处理器

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdBookQuery_BeforeDataBind(object sender, EventArgs e)
        {
            var name = ctxtTextbookName.Text.Trim();
            var isbn = ctxtIsbn.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(isbn))
            {
                return;
            }
            //获取gridview数据源

            cgrdBookQuery.DataSource = _impl.GetByName(name, isbn);

        }

        /// <summary>
        /// checkbox全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            var chk = sender as CPMis.Web.WebControls.CPMisCheckBox;
            cgrdBookQuery.SetAllCheckControlState(chk.Checked);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdBookQuery_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            //保持Checked状态
            cgrdBookQuery.PersistCheckState<TextbookForQueryView>();
        }

        #endregion

        #region Ajax回调

        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                case "Delete":
                    BatchDeleteBooks();
                    cgrdBookQuery.DoDataBind();
                    break;
                default:
                    cgrdBookQuery.DoDataBind();
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
            cgrdBookQuery.PersistCheckState<TextbookForQueryView>();
            var books = cgrdBookQuery.GetAllCheckedDataList<TextbookForQueryView>();

            //删除
            var result = _impl.Remove(books.ToArray());

            CPMis.Web.WebClient.ScriptManager.Alert(result.Message);

        }
        #endregion

    }
}
