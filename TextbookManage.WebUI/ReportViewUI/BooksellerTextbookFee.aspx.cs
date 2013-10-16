using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class BooksellerTextbookFee: System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger userProfile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        CPMis.WebPage.ReportViewsUI.Common.GetBooksellers _booksellersource = new CPMis.WebPage.ReportViewsUI.Common.GetBooksellers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbSchool.DataSourceID = "SqlDataSource_School";
                ccmbSchool.DataBind();
                ccmbSchool.InsertListItem(0, "---全部---", "00000000-0000-0000-0000-000000000000");
                ccmbBookseller.DataSource = _booksellersource.getBooksellerSource(userProfile);
                ccmbBookseller.DataBind();
                if (userProfile.RoleName == CPMis.Common.ParameterList.ReportViews.Roles.BOOKSELLER)
                {
                    ccmbBookseller.Enabled = false;
                }
            }
        }
       
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string term = ccmbTerm.SelectedText;
            string schoolName = ccmbSchool.SelectedText;
            string schoolID = ccmbSchool.SelectedValue.Trim();
            string booksellerID = ccmbBookseller.SelectedValue;
            string booksellerName =ccmbBookseller.SelectedText;
            
            ReportViewerDataBind(booksellerID,booksellerName,schoolID,schoolName, term);
        }
        protected void ReportViewerDataBind(string booksellerID,string booksellerName,string schoolID,string schoolName,string term)
        {
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("BooksellerID", booksellerID);
            SqlDataSource1.SelectParameters.Add("Term", term);
            SqlDataSource1.SelectParameters.Add("SchoolID", schoolID);
            ReportViewer1.LocalReport.SetParameters(new Parameter("BooksellerName", booksellerName));     
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}