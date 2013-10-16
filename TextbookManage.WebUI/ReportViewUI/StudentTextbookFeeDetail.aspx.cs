using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class StudentTextbookFeeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.Visible = false;
            }
        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string schoolName = ccmbSchool.SelectedText;
            string className = ccmbProfessionalClass.SelectedText;
            string term = ccmbTerm.SelectedText;
            string studentName = ccmbStudent.SelectedText;
            string studentNum = ccmbStudent.SelectedValue;
            ReportViewerDataBind(schoolName, className, studentName, studentNum, term);
        }
        public void ReportViewerDataBind(string schoolName, string className, string studentName, string studentNum, string term)
        {
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("studentNum", studentNum);
            SqlDataSource1.SelectParameters.Add("Term", term);
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("ClassName", className));
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Parameter("StudentNum", studentNum));
            ReportViewer1.LocalReport.SetParameters(new Parameter("StudentName",studentName));
            ReportViewer1.LocalReport.Refresh();
          
            
        }
    }
}