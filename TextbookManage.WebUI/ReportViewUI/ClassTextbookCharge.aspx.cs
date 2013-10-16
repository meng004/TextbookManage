using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewersUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class ClassTextbookCharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            rvClassTextbookCharge.Visible = true;
            string term = ccmbTerm.SelectedText;
            string schoolName = ccmbSchool.SelectedText;
            string grade = ccmbGrade.SelectedText;
            string professionalClass = ccmbProfessionalClass.SelectedText;
            string professionalClassID=ccmbProfessionalClass.SelectedValue;
            rvClassTextbookCharge.LocalReport.SetParameters(new Parameter("parmTerm", term));
            rvClassTextbookCharge.LocalReport.SetParameters(new Parameter("parmSchool", schoolName));
            rvClassTextbookCharge.LocalReport.SetParameters(new Parameter("parmGrade", grade));
            rvClassTextbookCharge.LocalReport.SetParameters(new Parameter("parmClass", professionalClass));
            ReportBatabind(term, professionalClassID);

        }
        private void ReportBatabind(string term, string professionalClassID)
        {
            DsClassTextbookCharge.SelectParameters.Clear();
            DsClassTextbookCharge.SelectParameters.Add("Term", term);
            DsClassTextbookCharge.SelectParameters.Add("ClassId", professionalClassID);
            rvClassTextbookCharge.LocalReport.Refresh();

        }
    }
}