using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.FeedbackService;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class FeedbackForSubscriptionPlan : USCTAMis.Web.WebControls.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["SubscriptionPlanId"]))
            {
                using (FeedbackApplClient app = new FeedbackApplClient())
                {
                    var id = Request.QueryString["SubscriptionPlanId"];
                    var result = app.GetFeedbackBySubscriptionId(id);
                    SetFeedbackInfo(result);
                }
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