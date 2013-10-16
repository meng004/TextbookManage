using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.DeclarationQueryService;


namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class FeedbackForDeclaration : USCTAMis.Web.WebControls.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["DeclarationID"]))
            {
                var id = Request.QueryString["DeclarationID"];
                using (DeclarationQueryApplClient app = new DeclarationQueryApplClient())
                {
                    var result = app.GetFeedbackByDeclarationId(id);
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