using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextbookManage.WebUI.ReprotViewUI
{
    public partial class BookSellerTextbookSum : USCTAMis.Web.WebControls.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbTerm.DoDataBind();
                ccmbBookSellerName.DoDataBind();
            }
        }

        protected void ccmbBookSellerName_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbTerm_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void UTMisReportViewer1_BeforeReportPrint(object sender, EventArgs e)
        {
           
        }

     

        protected void rpv_CourseTextBookPrint_BeforeReportPrint(object sender, EventArgs e)
        {
            //rpv_CourseTextBookPrint.ReportName = "BookSellerTextbookSum";
            rpv_CourseTextBookPrint.ParameterNames = "YearTerm,BookSellerName";
            rpv_CourseTextBookPrint.Parameters = new string[] { "2011-2012-2", "新华书店" };         
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            rpv_CourseTextBookPrint.DoPrint();
        }
    }
}