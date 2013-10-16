using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class StudentTextbookFee : System.Web.UI.Page
    {
        CPMis.IBLL.ReportViews.IBooksellerInfoBLL _studentCount = new CPMis.BLL.ReportViews.BooksellerInfoBLL();
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
            string classID = ccmbProfessionalClass.SelectedValue;
            ReportViewerDataBind(schoolName, className, term,classID);
        }
        protected void ReportViewerDataBind(string schoolName, string className, string term,string classID)
        {

            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("ClassID", classID);
            SqlDataSource1.SelectParameters.Add("Term", term);
            System.Web.UI.WebControls.Parameter paraSchoolCount= new System.Web.UI.WebControls.Parameter("StudentCount",System.Data.DbType.Int32);
            paraSchoolCount.Direction = System.Data.ParameterDirection.Output;
            SqlDataSource1.SelectParameters.Add(paraSchoolCount);

            int StudentCount = _studentCount.Fn_GetStudentCount(term,classID);
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("ClassName", className));
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Parameter("StudentCount",StudentCount.ToString()));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}