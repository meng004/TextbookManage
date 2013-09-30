using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TextbookManage.Application.Factory;
using TextbookManage.Application.Interface;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class TeachingClassDetail : USCTAMis.Web.WebControls.Page
    {
        readonly IDeclaration _declaration = new ApplicationFactory(HttpContext.Current.User.Identity.Name, HttpContext.Current.Request.UserHostAddress).CreateDeclarationApplication();

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
            cgrdProfessionalClasses.DataSource = _declaration.GetProfessinalClassList(num);
        }
    }
}