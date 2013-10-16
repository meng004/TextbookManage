using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI.Orders
{
    public partial class AcadamicBooksellerOrder : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbSchool.DataSourceID = "SqlDataSource_School";
                ccmbSchool.DataBind();
                ccmbSchool.InsertListItem(0, "-----全部-----", "全部");
                ccmbSchool.SelectedIndex = 1;
            }
        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string schoolName = ccmbSchool.SelectedText;
            string schoolID = ccmbSchool.SelectedValue;
            string term = ccmbTerm.SelectedText;


            ReportViewerDataBind(schoolName, term, schoolID);

        }
        protected void ReportViewerDataBind(string schoolName, string term, string schoolID)
        {
            if (schoolID != "全部")
            {
                sqlBooksellerOrderBySchoolID.SelectParameters.Clear();
                sqlBooksellerOrderBySchoolID.SelectParameters.Add("SchoolID", schoolID);
                sqlBooksellerOrderBySchoolID.SelectParameters.Add("Term", term);

            }
            else
            {
                ReportViewer1.LocalReport.DataSources[0].DataSourceId = "sqlBooksellerOrderBySchool";
                ReportViewer1.LocalReport.DataSources[0].Name = "DataSet1";
                sqlBooksellerOrderBySchool.SelectParameters.Clear();
                sqlBooksellerOrderBySchool.SelectParameters.Add("Term", term);
            }
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}