using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class FeedbackForSubscriptionPlan : USCTAMis.Web.WebControls.Page
    {
        //获取用户信息
        //ProfileManger profile = new ProfileManger(HttpContext.Current.User.Identity.Name);
        //获取登录名
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        readonly string _loginName = "dongxb";
        //新华书店，dongxb
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl

        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;
        TextbookManage.Application.Interface.IFeedback _feedback; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["SubscriptionPlanId"]))
            {
                _feedback = new TextbookManage.Application.Factory.ApplicationFactory(_loginName, _ipAddress).CrateFeedbackApplication();
                SetFeedbackInfo(_feedback.GetFeedback(Request.QueryString["SubscriptionPlanId"]));
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