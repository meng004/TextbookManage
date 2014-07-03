using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
//添加引用
using TextbookManage.WebUI.FeedbackService;
using TextbookManage.WebUI.TermService;


namespace TextbookManage.WebUI.FeedBack
{
    public partial class BooksellerFeedBack : USCTAMis.Web.WebControls.Page
    {

        #region 属性

        //获取用户信息
        //ProfileManger profile = new ProfileManger(HttpContext.Current.User.Identity.Name);
        //获取登录名
        readonly string _loginName = HttpContext.Current.User.Identity.Name;
        //readonly string _loginName = "dongxb";
        //新华书店，dongxb
        //蓝色畅想，yangfan
        //江西，wantao
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl


        #endregion

        #region 页面加载

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (FeedbackApplClient app = new FeedbackApplClient())
                {
                    if (string.IsNullOrWhiteSpace(_loginName))
                        return;
                    //回告人
                    ctxt_Sign.Text = app.GetFeedbackPerson(_loginName);
                }

                //学期
                ccmbTerm.DoDataBind();
            }
        }

        #endregion

        #region 学期

        protected void ccmbTerm_DataBinding(object sender, EventArgs e)
        {
            using (TermApplClient app = new TermApplClient())
            {
                var result = app.GetAllTerms();
                ccmbTerm.DataSource = result;
            }
        }


        protected void ccmbTerm_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdOrderSet.DoDataBind();
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
            using (FeedbackApplClient app = new FeedbackApplClient())
            {
                //学期
                var term = ccmbTerm.SelectedValue;
                //获取未回告订单列表
                cgrdOrderSet.DataSource = app.GetSubscriptionWithNotFeedback(term, _loginName);
            }

        }

        /// <summary>
        /// 分页持久化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdOrderSet_BeforePageIndexChanged(object sender, EventArgs e)
        {
            cgrdOrderSet.PersistCheckState<SubscriptionForFeedbackView>();
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
            cgrdOrderSet.PersistCheckState<SubscriptionForFeedbackView>();
            IList<SubscriptionForFeedbackView> views = cgrdOrderSet.GetAllCheckedDataList<SubscriptionForFeedbackView>();
            //判断是否选中数据行
            if (views.Count > 0)
            {
                //获取回告状态
                string feedbackState = crdlFeedbackState.SelectedText.Trim();
                //获取回告说明
                string feedbackRemark = ctxtRemark.Text.Trim();
                //回告人
                var person = ctxt_Sign.Text;
                //提交回告
                using (FeedbackApplClient app = new FeedbackApplClient())
                {
                    var result = app.SubmitFeedback(views.ToArray(), person, feedbackState, feedbackRemark);
                    //提示消息
                    USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);
                }
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