using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewersUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class TeacherTextbookReleaseDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            rvDepartmentTextbookCharge.Visible = true;
            string term = ccmbTerm.SelectedText;
            string schoolName = ccmbSchool.SelectedText;
            string departmentName = ccmbDepartment.SelectedText;
            string departmentID = ccmbDepartment.SelectedValue;
            rvDepartmentTextbookCharge.LocalReport.SetParameters(new Parameter("parmTerm", term));
            rvDepartmentTextbookCharge.LocalReport.SetParameters(new Parameter("parmSchool", schoolName));
            rvDepartmentTextbookCharge.LocalReport.SetParameters(new Parameter("parmDepartment", departmentName));
            ReportBatabind(term, departmentID);



        }
        private void ReportBatabind(string term, string departmentID)
        {
            DsDepartmentTextbookCharge.SelectParameters.Clear();
            DsDepartmentTextbookCharge.SelectParameters.Add("Term", term);
            DsDepartmentTextbookCharge.SelectParameters.Add("DepartmentId", departmentID);
            rvDepartmentTextbookCharge.LocalReport.Refresh();

        }
    }
}