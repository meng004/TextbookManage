using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class BooksellerStudentTextbookFeeDetail : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger userProfile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        CPMis.WebPage.ReportViewsUI.Common.GetBooksellers booksellerSource = new Common.GetBooksellers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbBookseller.DataSource = booksellerSource.getBooksellerSource(userProfile);
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
            string schoolName = ccmbSchool.SelectedText;
            string className = ccmbProfessionalClass.SelectedText;
            string classID = ccmbProfessionalClass.SelectedValue;
            string booksellerID = ccmbBookseller.SelectedValue;
            string term = ccmbTerm.SelectedText;
            string booksellerName = ccmbBookseller.SelectedText;
            ReportViewerDataBind(classID,booksellerID,schoolName,className,booksellerName, term);
        }
        protected void ReportViewerDataBind(string classID,string booksellerID,string schoolName,string className,string booksellerName,string term)
        {
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("BooksellerId", booksellerID);
            SqlDataSource1.SelectParameters.Add("ClassId", classID);
            SqlDataSource1.SelectParameters.Add("Term", term);
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("ClassName", className));
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Parameter("BooksellerName",booksellerName));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}