using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//添加引用
using TextbookManage.Application.Interface;
using TextbookManage.Application.Factory;
using TextbookManage.Application.ViewModel;


namespace TextbookManage.WebUI.FeedBack
{
    public partial class BooksellerFeedBack : USCTAMis.Web.WebControls.Page
    {

        #region 属性

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

        IFeedback _feedback;

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
            _feedback = new ApplicationFactory(_loginName, _ipAddress).CrateFeedbackApplication();

            if (!IsPostBack)
            {
                //回告人
                ctxt_Sign.Text = _feedback.GetFeedbackPerson();
                //获取定单列表
                cgrdOrderSet.DoDataBind();
            }
        }

        #endregion

        #region 定单列表

        /// <summary>
        /// cgrdOrderSet数据绑定前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdOrderSet_BeforeDataBind(object sender, EventArgs e)
        {
            //获取未回告订单列表
            cgrdOrderSet.DataSource = _feedback.GetSubscriptionPlansForFeedback();
        }

        /// <summary>
        /// 分页持久化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdOrderSet_BeforePageIndexChanged(object sender, EventArgs e)
        {
            cgrdOrderSet.PersistCheckState<SubscriptionPlanView>();
        }

        /// <summary>
        /// 复选框全选与反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
            cgrdOrderSet.SetAllCheckControlState(chk.Checked);
        }

        #endregion

        #region 提交回告

        /// <summary>
        /// 回告事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            //获取选中的征订计划列表
            cgrdOrderSet.PersistCheckState<SubscriptionPlanView>();
            IList<SubscriptionPlanView> views = cgrdOrderSet.GetAllCheckedDataList<SubscriptionPlanView>();
            //判断是否选中数据行
            if (views.Count > 0)
            {
                //获取回告状态
                string feedbackState = crdlFeedbackState.SelectedText.Trim();
                //获取回告说明
                string feedbackRemark = ctxtRemark.Text.Trim();
                //消息
                string msg = string.Empty;
                //提交回告
                _feedback.SubmitFeedback(views, feedbackState, feedbackRemark, ref msg);
                //提示消息
                USCTAMis.Web.WebClient.ScriptManager.Alert(msg);
            }
            else
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请选择定单！");
            }
        }
        #endregion

        #region 刷新按钮

        /// <summary>
        /// 重新获取定单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdOrderSet.DoDataBind();
        }
        #endregion

    }
}