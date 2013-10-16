using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI.Orders
{
    public partial class BooksellerOrderByTextbook : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger userProfile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        IBLL.ReportViews.IBooksellerInfoBLL _booksellerInfoBLL = new BLL.ReportViews.BooksellerInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string term = ccmbTerm.SelectedText;
            string booksellerID =userProfile.UserInGroupID;
            string booksellerName = _booksellerInfoBLL.Fn_GetBooksellerInfo(booksellerID).BooksellerName;
            ReportViewerDataBind(booksellerName,booksellerID,term);

        }
        protected void ReportViewerDataBind(string booksellerName,string booksellerID,string term)
        {

            sqlBooksellerOrderByTextbookAndBooksellerID.SelectParameters.Clear();
            sqlBooksellerOrderByTextbookAndBooksellerID.SelectParameters.Add("Term", term);
            sqlBooksellerOrderByTextbookAndBooksellerID.SelectParameters.Add("BooksellerID", booksellerID);
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("BooksellerName",booksellerName));
            ReportViewer1.LocalReport.Refresh();
        }
  
    }
}