using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TextbookManage.Application.Factory;
using TextbookManage.Application.Interface;

using Telerik.Web.UI;

namespace TextbookManage.WebUI.Declaration
{
    public partial class QueryDeclaration : USCTAMis.Web.WebControls.Page
    {

        #region 属性与构造函数

        //获取登陆用户
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        readonly string _loginName = "46010";
        //新华书店，dongxb
        //外国语教师，46010
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl
        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;

        //创建申报实例
        IDeclaration _declaration;

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _declaration = new ApplicationFactory(_loginName, _ipAddress).CreateDeclarationApplication();
            //首次加载
            if (!IsPostBack)
            {
                //根据用户的角色列表初始化页面显示                
                ccmbTerm.DoDataBind();
                ccmbRecipientType.DoDataBind();
                ccmbSchool.DoDataBind();
            }
        }
        #endregion

        #region 学年学期、领用人类型

        //学年学期数据源获取
        protected void ccmbTerm_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbTerm.DataSource = _declaration.GetTermList();
        }

        //领用人数据源获取
        protected void ccmbRecipientType_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbRecipientType.DataSource = _declaration.GetRecipientTypeList();
        }

        protected void ccmbRecipientType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        protected void ccmbRecipientType_AfterDataBind(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        #endregion

        #region 学院、教研室、课程数据绑定

        //学院数据源获取绑定
        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbSchool.DataSource = _declaration.GetSchoolList();
        }

        //学院数据绑定后，绑定教研室数据
        protected void ccmbSchool_AfterDataBind(object sender, EventArgs e)
        {
            ccmbDepartment.DoDataBind();
        }

        //教研室数据源获取
        protected void ccmbDepartment_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbDepartment.DataSource = _declaration.GetDepartmentListBySchoolId(ccmbSchool.SelectedValue);
        }

        //教研室数据绑定后绑定课程
        protected void ccmbDepartment_AfterDataBind(object sender, EventArgs e)
        {
            ccmbCourse.DoDataBind();
        }

        //课程数据源获取
        protected void ccmbCourse_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbCourse.DataSource = _declaration.GetCourseListByDepartmentId(ccmbDepartment.SelectedValue);
        }

        //点击查询绑定申报列表
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        #endregion

        #region 申报列表

        /// <summary>
        /// 根据用户角色和级别绑定申报列表显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDeclarationList_BeforeDataBind(object sender, EventArgs e)
        {
            cgrdDeclarationList.DataSource = _declaration.GetDeclarations(ccmbTerm.SelectedValue, ccmbCourse.SelectedValue, ccmbDepartment.SelectedValue, ccmbRecipientType.SelectedValue);
        }

        #endregion

        #region Ajax

        /// <summary>
        /// Ajax回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                default:
                    cgrdDeclarationList.DoDataBind();
                    break;
            }
        }
        #endregion

    }
}