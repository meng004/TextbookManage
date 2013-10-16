using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI.Orders
{
    public partial class BooksellerOrder : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger userProfile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        IBLL.ReportViews.IBooksellerInfoBLL _booksellerInfoBLL = new BLL.ReportViews.BooksellerInfoBLL();
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
            string booksellerID = userProfile.UserInGroupID;
            string booksellerName = _booksellerInfoBLL.Fn_GetBooksellerInfo(booksellerID).BooksellerName;
            ReportViewerDataBind(schoolName, booksellerName, term, schoolID, booksellerID);

        }
        protected void ReportViewerDataBind(string schoolName, string booksellerName, string term, string schoolID, string booksellerID)
        {
            if (schoolID != "全部")
            {
                sqlBooksellerOrderBySchoolID.SelectParameters.Clear();
                sqlBooksellerOrderBySchoolID.SelectParameters.Add("SchoolID", schoolID);
                sqlBooksellerOrderBySchoolID.SelectParameters.Add("Term", term);
                sqlBooksellerOrderBySchoolID.SelectParameters.Add("BooksellerID", booksellerID);

            }
            else
            {
                ReportViewer1.LocalReport.DataSources[0].DataSourceId = "sqlBooksellerOrder";
                ReportViewer1.LocalReport.DataSources[0].Name = "DataSet1";
                sqlBooksellerOrder.SelectParameters.Clear();
                sqlBooksellerOrder.SelectParameters.Add("BooksellerID", booksellerID);
                sqlBooksellerOrder.SelectParameters.Add("Term", term);
            }
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Term", term));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("BooksellerName", booksellerName));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}