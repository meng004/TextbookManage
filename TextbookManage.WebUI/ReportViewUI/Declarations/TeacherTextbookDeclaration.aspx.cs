using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI.Declarations
{
    public partial class TeacherTextbookDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
          protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string schoolName = ccmbSchool.SelectedText;
            string departmentID = ccmbDepartment.SelectedValue;
            string departmentName = ccmbDepartment.SelectedText;
            string term = ccmbTerm.SelectedText;
            string Zhenggao = "（正稿）";


            ReportViewerDataBind(schoolName,departmentName, term, departmentID, Zhenggao);

        }
        protected void ReportViewerDataBind(string schoolName,string departmentName, string term, string departmentID, string Zhenggao)
        {
            sqlTeacherDeclarationByDepartmentID.SelectParameters["Term"] =new Parameter("Term",System.Data.DbType.String,term);
            sqlTeacherDeclarationByDepartmentID.SelectParameters["DepartmentID"] = new Parameter("DepartmentID",System.Data.DbType.String,departmentID);

            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Term",term));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("DepartmentName", departmentName));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("ZhengGao", Zhenggao));
            ReportViewer1.LocalReport.Refresh();
        }
    
    }
}