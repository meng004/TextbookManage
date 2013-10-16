using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.DeclarationApprovalService;


namespace TextbookManage.WebUI.Declaration
{
    public partial class DeclarationApproval : USCTAMis.Web.WebControls.Page
    {

        #region 属性

        //获取用户信息
        //ProfileManger profile = new ProfileManger(HttpContext.Current.User.Identity.Name);
        //获取登录名
        readonly string _loginName = HttpContext.Current.User.Identity.Name;
        //readonly string _loginName = "hynhpgj";
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl

        
        #endregion

        #region 页面加载事件

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定学院下拉列表
                ccmbSchool.DataBind();
                using (DeclarationApprovalApplClient client = new DeclarationApprovalApplClient())
                {
                    //审核人签名
                    txt_Sign.Text = client.GetAuditor(_loginName);
                }
            }
        }
        #endregion

        #region 学院

        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationApprovalApplClient client = new DeclarationApprovalApplClient())
            {
                ccmbSchool.DataSource = client.GetSchoolWithNotApproval(_loginName);
            }
        }

        protected void ccmbSchool_AfterDataBind(object sender, EventArgs e)
        {
            cgrdDeclaration.DoDataBind();
        }

        protected void ccmbSchool_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdDeclaration.DoDataBind();
        }

        #endregion

        #region 待审核申报

        /// <summary>
        /// 取申报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDeclaration_BeforeDataBind(object sender, EventArgs e)
        {
            string schoolId = ccmbSchool.SelectedValue;
            using (DeclarationApprovalApplClient client = new DeclarationApprovalApplClient())
            {
                cgrdDeclaration.DataSource = client.GetDeclarationWithNotApproval(_loginName, schoolId);
            }
        }

        #endregion

        #region Grid分页

        /// <summary>
        /// Grid中的分页前数据持久化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDeclaration_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            cgrdDeclaration.PersistCheckState<DeclarationForApprovalView>();
        }

        /// <summary>
        /// 全选或不选，然后是对申报数量的处理计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
            cgrdDeclaration.SetAllCheckControlState(chk.Checked);
        }
        #endregion

        #region 提交审核

        /// <summary>
        /// 确认审核事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            cgrdDeclaration.PersistCheckState<DeclarationForApprovalView>();
            IList<DeclarationForApprovalView> views = cgrdDeclaration.GetAllCheckedDataList<DeclarationForApprovalView>();
            string message = string.Empty;

            if (views.Count == 0)
            {
                message = "请选择待审核记录";
            }
            else
            {
                //取审核意见与备注
                string approvalSuggestion = crdlSuggestion.SelectedValue;
                string remark = ctxtRemark.Text.Trim();

                using (DeclarationApprovalApplClient client = new DeclarationApprovalApplClient())
                {
                    var result = client.SubmitDeclarationApproval(views.ToArray(), _loginName, approvalSuggestion, remark);
                    message = result.Message;
                }
            }
            USCTAMis.Web.WebClient.ScriptManager.Alert(message);
        }

        protected void cbtnSubmit_AfterClick(object sender, EventArgs e)
        {
            ccmbSchool.DataBind();
        }

        #endregion

        #region Ajax

        /// <summary>
        /// ajax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                default:
                    cgrdDeclaration.DoDataBind();
                    break;
            }
        }
        #endregion


    }
}