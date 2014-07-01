using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.TextbookService;

namespace TextbookManage.WebUI.TextbookMaintain
{
    public partial class TextbookQuery : USCTAMis.Web.WebControls.Page
    {
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
            using (TextbookApplClient client = new TextbookApplClient())
            {
                cgrdBookQuery.DataSource = client.GetByName(name, isbn);
            }
        }

        /// <summary>
        /// checkbox全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
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
            using (TextbookApplClient client = new TextbookApplClient())
            {
                //取选中的图书
                cgrdBookQuery.PersistCheckState<TextbookForQueryView>();
                var books = cgrdBookQuery.GetAllCheckedDataList<TextbookForQueryView>();

                //删除
                var result = client.Remove(books.ToArray());

                USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);
            }
        }
        #endregion

    }
}
