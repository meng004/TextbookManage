using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.ReleaseClassBookService;

namespace TextbookManage.WebUI.ReportViewUI
{
    public partial class ReportForClassBook : System.Web.UI.Page
    {
        private const string _dataSetKey = "ReportForClassBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var schoolName = Request.QueryString["SchoolName"];
                var className = Request.QueryString["ClassName"];
                var dataSet = Session[_dataSetKey] as IEnumerable<InventoryForReleaseClassView>;
                if (string.IsNullOrWhiteSpace(schoolName) || string.IsNullOrWhiteSpace(className) || dataSet == null)
                {
                    return;
                }
                else
                {
                    LoadReportDataSource(dataSet, schoolName, className);
                }
            }
        }

        private void LoadReportDataSource(IEnumerable<InventoryForReleaseClassView> dataSet, string schoolName, string className)
        {
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dataSet));

            ReportViewer1.LocalReport.Refresh();
        }
    }
}
