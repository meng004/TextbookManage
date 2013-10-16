using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.TextbookService;

namespace TextbookManage.WebUI.TextbookMaintain
{
    public partial class TextbookMyQuery : USCTAMis.Web.WebControls.Page
    {

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
            using (TextbookApplClient client = new TextbookApplClient())
            {
                //取选中的图书
                cgrdMyBookQuery.PersistCheckState<TextbookForQueryView>();
                var books = cgrdMyBookQuery.GetAllCheckedDataList<TextbookForQueryView>();

                //删除
                var result = client.Remove(books.ToArray());

                USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);
            }
        }
        #endregion

        #region 个人申报教材


        protected void cgrdMyBookQuery_BeforeDataBind(object sender, EventArgs e)
        {
            //获取gridview数据源
            using (TextbookApplClient client = new TextbookApplClient())
            {
                //cgrdBookQuery.DataSource = client.GetByLoginName(Page.User.Identity.Name);
                cgrdMyBookQuery.DataSource = client.GetByLoginName(_loginName);
            }
        }

        protected void cgrdMyBookQuery_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            //保持Checked状态
            cgrdMyBookQuery.PersistCheckState<TextbookForQueryView>();
        }

        protected void cchkMyCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
            cgrdMyBookQuery.SetAllCheckControlState(chk.Checked);
        }
        #endregion

    }
}