using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TextbookManage.WebUI.ReprotViewUI
{
    public partial class DepartmentTextbookOrderForStudent : USCTAMis.Web.WebControls.Page
    {
        #region 字段
        #endregion
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbTerm.DoDataBind();
                ccmbDataSign.DoDataBind();
                ccmbRecipientType.DoDataBind();

                //ccmbReport.DoDataBind();
                
                //USCTAMis.Web.BusinessControls.ReportDropDownList
                rptDepartment.Parameters = new string[] { "2011-2012", "2", "A", "A0D87BDB-C611-47ED-BA79-775A80732B2E", "6D1365DF-8BBC-4E1E-9116-6371C4C702E6", "2", "1" };
                rptDepartment.DoPrint();
            }
        }

        protected void ccmbTerm_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbTerm_AfterDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbSchool_AfterDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbDepartment_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbDepartment_AfterDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbRecipientType_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbRecipientType_AfterDataBind(object sender, EventArgs e)
        {

        }

        protected void cbtnPreview_Click(object sender, EventArgs e)
        {

        }

        protected void rptDepartment_DataBinding(object sender, EventArgs e)
        {
            rptDepartment.DoPrint();
        }

        protected void rptDepartment_Load(object sender, EventArgs e)
        {
            rptDepartment.DoPrint();
        }

        protected void df_BeforeDataBind(object sender, EventArgs e)
        {

        }

        protected void df_BeforeDataBind1(object sender, EventArgs e)
        {

        }

       

    }
}