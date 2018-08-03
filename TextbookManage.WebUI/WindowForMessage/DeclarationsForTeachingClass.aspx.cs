using System;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class DeclarationsForTeachingClass : CPMis.Web.WebControls.Page
    {
        private readonly IDeclarationAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationAppl>();
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


            cgrdDeclarations.DataSource = _impl.GetDeclarationByTeacingTaskNum(teachingTaskNum);


        }
    }
}