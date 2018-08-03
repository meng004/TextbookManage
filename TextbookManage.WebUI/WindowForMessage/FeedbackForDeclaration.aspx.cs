using System;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class FeedbackForDeclaration : CPMis.Web.WebControls.Page
    {
        private readonly IDeclarationQueryAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationQueryAppl>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["DeclarationID"]))
            {
                var id = Request.QueryString["DeclarationID"];

                var result = _impl.GetFeedbackByStudentDeclarationId(id);
                SetFeedbackInfo(result);

            }
        }

        private void SetFeedbackInfo(FeedbackView feedbackView)
        {
            txt_Person.Text = feedbackView.Person;
            txt_Date.Text = feedbackView.FeedbackDate;
            txt_State.Text = feedbackView.FeedbackState;
            txt_Remark.Text = feedbackView.Remark;
        }

    }
}