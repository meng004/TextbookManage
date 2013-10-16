using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;
    public partial class BooksellerTeacherTextbookFeeDetail : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger userProfile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        IBLL.ReportViews.IBooksellerInfoBLL _booksellerInfoBLL = new BLL.ReportViews.BooksellerInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string departmentID = ccmbDepartment.SelectedValue;
            string booksellerID = userProfile.UserInGroupID;
            string term = ccmbTerm.SelectedText;
            string booksellerName = _booksellerInfoBLL.Fn_GetBooksellerInfo(booksellerID).BooksellerName;
            string schoolName = ccmbSchool.SelectedText;
            string departmentName = ccmbDepartment.SelectedText;
            ReportViewerDataBind(departmentID, booksellerID,schoolName,departmentName,booksellerName, term);
        }
        protected void ReportViewerDataBind(string departmentID, string booksellerID,string schoolName,string departmentName,string booksellerName, string term)
        {
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("BooksellerID", booksellerID);
            SqlDataSource1.SelectParameters.Add("DepartmentID", departmentID);
            SqlDataSource1.SelectParameters.Add("Term", term);
            ReportViewer1.LocalReport.SetParameters(new Parameter("BooksellerName", booksellerName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("DepartmentName", departmentName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}