using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Query.Tb_Query_06
{
    public partial class StudentReleasePlanQuery : System.Web.UI.Page
    {
        private CPMis.IBLL.Tb_Query.Tb_Query06.IClassReleasePlanQueryBLL _ClassReleasePlanQueryBLL = new CPMis.BLL.Tb_Query.Tb_Query06.ClassReleasePlanQueryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbTerm.DataSource = _ClassReleasePlanQueryBLL.Fn_TermGetList();
                ccmbTerm.DataBind();
                ccmbTerm.InsertListItem(0, "----全部----", "全部");

                ccmbSchool.DataSource = _ClassReleasePlanQueryBLL.Fn_SchoolNameGetList();
                ccmbSchool.DataBind();
                ccmbSchool.InsertListItem(0, "----请选择----", "00000000-0000-0000-0000-000000000000");

                ccmbGrade.DataSource = _ClassReleasePlanQueryBLL.Fn_GradeGetList();
                ccmbGrade.DataBind();
                ccmbGrade.InsertListItem(0, "----请选择----", "00000000-0000-0000-0000-000000000000");

                ccmbProfessionalClass.InsertListItem(0, "----请选择----", "00000000-0000-0000-0000-000000000000");
            }
        }

        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbntQuery_Click(object sender, EventArgs e)
        {
            cgrdClassReleasePlanQuery.DoDataBind();
        }

        /// <summary>
        /// gridview绑定前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdClassReleasePlanQuery_BeforeDataBind(object sender, EventArgs e) 
        {
            cgrdClassReleasePlanQuery.DataSource = _ClassReleasePlanQueryBLL.Fn_ClassReleasePlanGetList(ccmbProfessionalClass.SelectedValue,ccmbTerm.SelectedText);
        }

        /// <summary>
        /// 学院的下拉列表联动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选着学院后年级重新绑定
            ccmbGrade.DataSource = _ClassReleasePlanQueryBLL.Fn_GradeGetList();
            ccmbGrade.DataBind();
            ccmbGrade.InsertListItem(0, "----请选择----", "00000000-0000-0000-0000-000000000000");

            //选择学院后显示对应的班级
            ccmbProfessionalClass.DataSource = _ClassReleasePlanQueryBLL.Fn_ProfessionalClassGetListBySchoolID(ccmbSchool.SelectedValue);
            ccmbProfessionalClass.DataBind();
            ccmbProfessionalClass.InsertListItem(0, "----请选择----", "00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// 年级的下拉列表联动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择年级后显示对应的班级
            ccmbProfessionalClass.DataSource = _ClassReleasePlanQueryBLL.Fn_ProfessionalClassGetListBySchoolIDClassID(ccmbSchool.SelectedValue, ccmbGrade.SelectedValue);
            ccmbProfessionalClass.DataBind();
            ccmbProfessionalClass.InsertListItem(0, "----请选择----", "00000000-0000-0000-0000-000000000000");
        }        
    }
}