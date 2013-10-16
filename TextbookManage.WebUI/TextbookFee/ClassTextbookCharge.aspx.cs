using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextbookManage.WebUI.TextbookFee
{

    public partial class ClassTextbookCharge : USCTAMis.Web.WebControls.Page
    {
        readonly string _loginName = "46010";
        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbTerm.DoDataBind();
                
            }
        }

        protected void ccmbTerm_BeforeDataBind(object sender, EventArgs e)
        {
            using (TextbookFeeService.TextbookFeeApplClient client = new TextbookFeeService.TextbookFeeApplClient())
            {
                ccmbTerm.DataSource = client.GetTerm();
            }
        }

        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            using (TextbookFeeService.TextbookFeeApplClient client = new TextbookFeeService.TextbookFeeApplClient())
            {
                ccmbSchool.DataSource = client.GetSchoolByloginName(_loginName);
            }
        }

        protected void ccmbGrade_BeforeDataBind(object sender, EventArgs e)
        {
            using (TextbookFeeService.TextbookFeeApplClient client = new TextbookFeeService.TextbookFeeApplClient())
            {
                ccmbGrade.DataSource = client.GetGradeBySchoolId(ccmbSchool.SelectedValue);
            }
        }

        protected void ccmbProfessionalClass_BeforeDataBind(object sender, EventArgs e)
        {
            using (TextbookFeeService.TextbookFeeApplClient client = new TextbookFeeService.TextbookFeeApplClient())
            {
                ccmbProfessionalClass.DataSource = client.GetProfessionalClassFee(ccmbTerm.SelectedValue, ccmbProfessionalClass.SelectedValue);
            }
        }

        protected void ccmbSchool_AfterDataBind(object sender, EventArgs e)
        {
            ccmbGrade.DoDataBind();
        }

        protected void ccmbGrade_AfterDataBind(object sender, EventArgs e)
        {
            ccmbProfessionalClass.DoDataBind();
        }

    }
}