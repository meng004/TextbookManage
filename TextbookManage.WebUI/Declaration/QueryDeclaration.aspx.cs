using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using TextbookManage.WebUI.DeclarationQueryService;



namespace TextbookManage.WebUI.Declaration
{
    public partial class QueryDeclaration : USCTAMis.Web.WebControls.Page
    {

        #region 属性与构造函数

        //获取登陆用户
        //readonly string _loginName = "30047";
        private readonly string _loginName = HttpContext.Current.User.Identity.Name;


        //新华书店，dongxb
        //外国语教师，46010
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl


        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //首次加载
            if (!IsPostBack)
            {

                //根据用户的角色列表初始化页面显示                
                ccmbRecipientType.DataBind();
                ccmbTerm.DataBind();
            }
        }
        #endregion

        #region 学年学期、领用人类型

        //学年学期数据源获取
        protected void ccmbTerm_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationQueryApplClient client = new DeclarationQueryApplClient())
            {
                ccmbTerm.DataSource = client.GetTerm();
            }
        }

        protected void ccmbTerm_DataBound(object sender, EventArgs e)
        {
            ccmbSchool.DataBind();
        }

        protected void ccmbTerm_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ccmbSchool.DataBind();
        }

        //领用人数据源获取
        protected void ccmbRecipientType_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationQueryApplClient client = new DeclarationQueryApplClient())
            {
                ccmbRecipientType.DataSource = client.GetRecipientType();
            }
        }

        protected void ccmbRecipientType_AfterDataBind(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        protected void ccmbRecipientType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        #endregion

        #region 学院、教研室、课程数据绑定

        //学院数据源获取绑定
        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationQueryApplClient client = new DeclarationQueryApplClient())
            {
                ccmbSchool.DataSource = client.GetSchoolByLoginName(_loginName);
            }
        }

        //学院数据绑定后，绑定教研室数据
        protected void ccmbSchool_AfterDataBind(object sender, EventArgs e)
        {
            ccmbDepartment.DataBind();
        }

        //教研室数据源获取
        protected void ccmbDepartment_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationQueryApplClient client = new DeclarationQueryApplClient())
            {
                ccmbDepartment.DataSource = client.GetDepartmentBySchoolId(_loginName, ccmbSchool.SelectedValue);
            }
        }

        //教研室数据绑定后绑定课程
        protected void ccmbDepartment_AfterDataBind(object sender, EventArgs e)
        {
            ccmbCourse.DataBind();
        }

        //课程数据源获取
        protected void ccmbCourse_BeforeDataBind(object sender, EventArgs e)
        {
            var departmentId = ccmbDepartment.SelectedValue;
            var term = ccmbTerm.SelectedValue;

            if (string.IsNullOrWhiteSpace(departmentId) || string.IsNullOrWhiteSpace(term))
            {
                return;
            }
            using (DeclarationQueryApplClient client = new DeclarationQueryApplClient())
            {
                ccmbCourse.DataSource = client.GetCourseByDepartmentId(departmentId, term);
            }
        }

        protected void ccmbCourse_DataBound(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        protected void ccmbCourse_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
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
            var courseId = ccmbCourse.SelectedValue;
            var departmentId = ccmbDepartment.SelectedValue;
            var term = ccmbTerm.SelectedValue;
            var recipientTypeName = ccmbRecipientType.SelectedValue;

            if (string.IsNullOrWhiteSpace(courseId) || string.IsNullOrWhiteSpace(departmentId) || string.IsNullOrWhiteSpace(term) || string.IsNullOrWhiteSpace(recipientTypeName))
            {
                return;
            }

            using (DeclarationQueryApplClient client = new DeclarationQueryApplClient())
            {
                cgrdDeclarationList.DataSource = client.GetDeclarationByCourseId(courseId, departmentId, term, recipientTypeName);
            }
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

        protected void ctlbDeclaration_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            var argu = e.Item.AccessKey;
            if (argu == "h")
            {
                var filename = "帮助文档.doc";
                Response.ContentType = "/doc";
                string strTemp = System.Web.HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8);//解决文件名乱码
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + strTemp);
                Response.TransmitFile(Server.MapPath(filename));
                Response.End();
            }
        }

    }
}