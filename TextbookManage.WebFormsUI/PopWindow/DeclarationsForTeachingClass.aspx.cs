using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.Application.Factory;
using TextbookManage.Application.Interface;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class DeclarationsForTeachingClass : System.Web.UI.Page
    {
        readonly IDeclaration _declaration = new ApplicationFactory(HttpContext.Current.User.Identity.Name, HttpContext.Current.Request.UserHostAddress).CreateDeclarationApplication();

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
            string teachingClassNum = Request.QueryString["TeachingClassNum"];
            cgrdDeclarations.DataSource = _declaration.GetDeclarationsByTeachingClassNum(teachingClassNum);
        }
    }
}