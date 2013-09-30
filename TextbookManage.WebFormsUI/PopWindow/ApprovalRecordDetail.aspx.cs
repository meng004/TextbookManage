using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TextbookManage.Application.Factory;
using TextbookManage.Application.Interface;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class ApprovalRecordDetail :USCTAMis.Web.WebControls.Page
    {
        readonly IDeclaration _declaration = new ApplicationFactory(HttpContext.Current.User.Identity.Name, HttpContext.Current.Request.UserHostAddress).CreateDeclarationApplication();

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
            string declarationID = Request.QueryString["DeclarationID"];
            
            cgrdApprovalRecord.DataSource = _declaration.GetApprovalDeclarationsByDeclarationId(declarationID);
        }
    }
}