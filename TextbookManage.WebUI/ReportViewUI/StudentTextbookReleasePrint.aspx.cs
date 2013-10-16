using System;
using System.Web;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace CPMis.WebPage.ReportViewsUI
{
    using Parameter = Microsoft.Reporting.WebForms.ReportParameter;

    public partial class StudentTextbookReleasePrint : System.Web.UI.Page
    {
        private CPMis.IBLL.ReportViews.ITextbookHandlerBLL _textbookRecordRow = new CPMis.BLL.ReportViews.TextbookHandlerBLL();
        private CPMis.BLL.ReportViews.TermHandlerBLL _termGetter = new BLL.ReportViews.TermHandlerBLL();
        private const string ParentPage = "StudentReleaseTextbook";

        //protected Tb_PSS.Tb_PSS_02.ReleaseStudentTextbook Parent {
        //    get { 
        //          if (ViewState[ParentPage] == null)
        //        {
        //            ViewState[ParentPage] = Context.Handler;
        //        }
        //          return (Tb_PSS.Tb_PSS_02.ReleaseStudentTextbook)ViewState[ParentPage];
        //    }
        //    set {
        //        ViewState[ParentPage] = value;
        //    }
        //}
        private string[] _textbookIdSet = null;
        private string _term;
        private string _school;
        private string _className;
        private string _classID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Parent = (Tb_PSS.Tb_PSS_02.ReleaseStudentTextbook)Context.Handler;
                Fill();
                
            }
        }
        protected void cbtnPrint_OnClick(object sender, EventArgs e)
        {
            Fill();
        }
        //天长
        protected void Fill()
        {
            HttpCookie cookie = Request.Cookies["ReleaseRecord"];
            if (cookie == null)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("找不到cookie");
            }
            else
            {
                _school = cookie["School"];
                _className = cookie["ClassName"];
                _classID = cookie["ClassID"];
                _textbookIdSet = (cookie["TextbookIdSet"].Split('#'));
                _term = _termGetter.FnGetCurrentTerm();
                ReportViewerDataBind(_school, _className, _term, _classID);

                //CPMis.Web.WebClient.ScriptManager.Alert("学院：" + _school + "班级：" + _className + "学期" + _term);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", getDataSource(cookie)));
                ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", _school));
                ReportViewer1.LocalReport.SetParameters(new Parameter("ClassName", _className));
                ReportViewer1.LocalReport.SetParameters(new Parameter("Term", _term));
                ReportViewer1.LocalReport.Refresh();
                cookie.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Add(cookie); 
            }
        }

        protected DataTable getDataSource(HttpCookie releaseCount)
        {
            DataTable dataTable = new DataTable();
            string[] header = { "TextbookID","TextbookName", "ISBN", "Author", "Press", "ReleaseCount", "ShelfNumber", "CourseName"};
            foreach (string s in header)
            {
                dataTable.Columns.Add(s);
            }
            for (int i = 0,rowIndex=0; i < _textbookIdSet.Length; i++)
            {
                if (!_textbookIdSet[i].Equals(String.Empty))
                {
                    DataRow dr = _textbookRecordRow.TextbookRecord(_textbookIdSet[i]);
                    dataTable.Rows.Add();
                    dataTable.Rows[rowIndex]["TextbookID"] = _textbookIdSet[i];
                    dataTable.Rows[rowIndex]["TextbookName"] = dr["TextbookName"];
                    dataTable.Rows[rowIndex]["Author"] = dr["Author"];
                    dataTable.Rows[rowIndex]["ISBN"] = dr["ISBN"];
                    dataTable.Rows[rowIndex]["Press"] = dr["Press"];
                    dataTable.Rows[rowIndex]["ReleaseCount"] = Convert.ToInt32(releaseCount[_textbookIdSet[i]]);//获得发放数量
                    dataTable.Rows[rowIndex]["ShelfNumber"] = releaseCount[_textbookIdSet[i] + "ShelfNumber"];
                    dataTable.Rows[rowIndex]["CourseName"] = releaseCount[_textbookIdSet[i] + "CourseName"];
                    rowIndex++;
                }
            }
            return dataTable;
        }

        protected void ReportViewerDataBind(string schoolName, string className, string term, string classID)
        {

            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("ClassID", classID);
            SqlDataSource1.SelectParameters.Add("Term", term);
            System.Web.UI.WebControls.Parameter paraSchoolCount = new System.Web.UI.WebControls.Parameter("StudentCount", System.Data.DbType.Int32);
            paraSchoolCount.Direction = System.Data.ParameterDirection.Output;
            SqlDataSource1.SelectParameters.Add(paraSchoolCount);

        //   int StudentCount = _studentCount.Fn_GetStudentCount(term, classID);
            ReportViewer1.LocalReport.SetParameters(new Parameter("SchoolName", schoolName));
            ReportViewer1.LocalReport.SetParameters(new Parameter("ClassName", className));
            ReportViewer1.LocalReport.SetParameters(new Parameter("Term", term));
          //  ReportViewer1.LocalReport.SetParameters(new Parameter("StudentCount", StudentCount.ToString()));
            ReportViewer1.LocalReport.Refresh();
        }
    }

}