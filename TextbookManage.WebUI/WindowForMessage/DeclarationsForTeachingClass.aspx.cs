using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.DeclarationService;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class DeclarationsForTeachingClass : USCTAMis.Web.WebControls.Page
    {

        //页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["TeachingClassNum"]))
            {
                cgrdDeclarations.DoDataBind();
            }
        }


        protected void cgrdDeclarations_BeforeDataBind(object sender, EventArgs e)
        {
            string teachingTaskNum = Request.QueryString["TeachingClassNum"];

            using (DeclarationApplClient app = new DeclarationApplClient())
            {
                cgrdDeclarations.DataSource = app.GetDeclarationByTeacingTaskNum(teachingTaskNum);
            }
            
        }
    }
}