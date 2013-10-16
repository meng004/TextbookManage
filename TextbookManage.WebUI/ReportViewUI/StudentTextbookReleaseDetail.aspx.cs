using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class StudentTextbookReleaseDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string schoolName = ccmbSchool.SelectedText;
            string className = ccmbProfessionalClass.SelectedText;
            string classID = ccmbProfessionalClass.SelectedValue;
            string term = ccmbTerm.SelectedText;
            ReportViewerDataBind(schoolName, className, classID, term);
        }
        public void ReportViewerDataBind(string schoolName, string className, string classID, string term)
        {
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("ClassId", classID);
            SqlDataSource1.SelectParameters.Add("Term", term);
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("ProfessionalClass", className));
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}