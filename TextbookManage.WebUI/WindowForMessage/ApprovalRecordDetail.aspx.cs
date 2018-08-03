using System;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.WebUI.DeclarationQueryService;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class ApprovalRecordDetail : CPMis.Web.WebControls.Page
    {
        private readonly IDeclarationQueryAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationQueryAppl>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["DeclarationID"]))
            {
                cgrdApprovalRecord.DoDataBind();
            }
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdApprovalRecord_BeforeDataBind(object sender, EventArgs e)
        {
            string declarationId = Request.QueryString["DeclarationID"];

            cgrdApprovalRecord.DataSource = _impl.GetDeclarationApproval(declarationId);
        }
    }
}