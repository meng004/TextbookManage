using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TextbookManage.WebUI.DeclarationQueryService;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class ApprovalRecordDetail :USCTAMis.Web.WebControls.Page
    {

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

            using (DeclarationQueryApplClient app = new DeclarationQueryApplClient())
            {
                cgrdApprovalRecord.DataSource = app.GetDeclarationApproval(declarationId);
            }            
        }
    }
}