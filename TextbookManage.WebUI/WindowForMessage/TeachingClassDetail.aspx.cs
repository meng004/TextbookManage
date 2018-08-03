using System;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IApplications;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class TeachingClassDetail : CPMis.Web.WebControls.Page
    {
        private readonly IDeclarationAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationAppl>();

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

            cgrdProfessionalClasses.DataSource = _impl.GetProfessionalClassByTeachingTaskNum(num);

        }
    }
}