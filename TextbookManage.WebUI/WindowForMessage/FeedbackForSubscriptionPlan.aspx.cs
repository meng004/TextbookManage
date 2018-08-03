using System;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class FeedbackForSubscriptionPlan : CPMis.Web.WebControls.Page
    {
        private readonly IFeedbackAppl _impl = ServiceLocator.Current.GetInstance<IFeedbackAppl>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["SubscriptionPlanId"]))
            {

                var id = Request.QueryString["SubscriptionPlanId"];
                var result = _impl.GetFeedbackBySubscriptionId(id);
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