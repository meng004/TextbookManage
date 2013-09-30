using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TextbookManage.Application.Factory;
using TextbookManage.Application.Interface;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class FeedbackForDeclaration : USCTAMis.Web.WebControls.Page
    {
        readonly IDeclaration _declaration = new ApplicationFactory(HttpContext.Current.User.Identity.Name, HttpContext.Current.Request.UserHostAddress).CreateDeclarationApplication();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["DeclarationID"]))
            {
                SetFeedbackInfo(_declaration.GetFeedbackByDeclarationId(Request.QueryString["DeclarationID"]));
            }
        }

        private void SetFeedbackInfo(TextbookManage.Application.ViewModel.FeedbackView feedbackView)
        {
            txt_Person.Text = feedbackView.FeedbackPerson;
            txt_Date.Text = feedbackView.FeedbackDate;
            txt_State.Text = feedbackView.FeedbackState;
            txt_Remark.Text = feedbackView.FeedbackRemark;
        }

    }
}