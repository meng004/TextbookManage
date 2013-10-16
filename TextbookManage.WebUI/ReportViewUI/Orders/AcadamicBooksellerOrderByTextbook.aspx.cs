using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.ReportViewsUI.Orders
{
    public partial class AcadamicBooksellerOrderByTextbook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
          protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            string term = ccmbTerm.SelectedText;
            ReportViewerDataBind(term);

        }
        protected void ReportViewerDataBind(string term)
        {
          
           sqlBooksellerOrderByTextbook.SelectParameters.Clear();
           sqlBooksellerOrderByTextbook.SelectParameters.Add("Term",term);
           ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Term",term));
           ReportViewer1.LocalReport.Refresh();
        }
  
    }
}