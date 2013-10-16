using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.DeclarationService;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class TeachingClassDetail : USCTAMis.Web.WebControls.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["TeachingClassNum"]))
            {
                cgrdProfessionalClasses.DoDataBind();
            }
        }


        protected void cgrdProfessionalClasses_BeforeDataBind(object sender, EventArgs e)
        {
            string num = Request.QueryString["TeachingClassNum"];
            using (DeclarationApplClient app = new DeclarationApplClient())
            {
                cgrdProfessionalClasses.DataSource = app.GetProfessionalClassByTeachingTaskNum(num);
            }            
        }
    }
}