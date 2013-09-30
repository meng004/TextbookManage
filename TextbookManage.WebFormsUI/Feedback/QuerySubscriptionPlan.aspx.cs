using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextbookManage.WebUI.FeedBack
{
    public partial class QuerySubscriptionPlan : USCTAMis.Web.WebControls.Page
    {

        #region 属性

        //获取用户信息
        //ProfileManger profile = new ProfileManger(HttpContext.Current.User.Identity.Name);
        //获取登录名
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        readonly string _loginName = "hynhpgj";
        //新华书店，dongxb
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl

        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;

        TextbookManage.Application.Interface.IFeedback _feedback;

        #endregion

        #region 页面加载

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //取应用对象
            _feedback = new TextbookManage.Application.Factory.ApplicationFactory(_loginName, _ipAddress).CrateFeedbackApplication();

            if (!IsPostBack)
            {
                //获取书商列表
                ccmbBookseller.DoDataBind();
                //获取回告状态                               
                ccmbFeedbackState.DoDataBind();
            }
        }

        #endregion

        #region 书商

        /// <summary>
        /// 书商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbBookseller_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbBookseller.DataSource = _feedback.GetBooksellerList();
        }

        #endregion

        #region 回告状态

        /// <summary>
        /// 回告状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbFeedbackState_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbFeedbackState.DataSource = _feedback.GetFeedbackState();
        }


        protected void ccmbFeedbackState_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdOrderSet.DoDataBind();
        }
        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdOrderSet.DoDataBind();
        }
        #endregion

        #region 订单

        /// <summary>
        /// 取订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdOrderSet_BeforeDataBind(object sender, EventArgs e)
        {
            string booksellerId = ccmbBookseller.SelectedValue;
            string feedbackState = ccmbFeedbackState.SelectedValue;
            cgrdOrderSet.DataSource = _feedback.GetSubscriptionPlansForFeedback(booksellerId, feedbackState);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdOrderSet_BeforePageIndexChanged(object sender, EventArgs e)
        {            
            cgrdOrderSet.PersistCheckState<TextbookManage.Application.ViewModel.SubscriptionPlanView>();
        }
        #endregion



    }
}