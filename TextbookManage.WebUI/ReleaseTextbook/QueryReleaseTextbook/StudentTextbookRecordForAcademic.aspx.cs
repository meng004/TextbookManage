using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Query.Tb_Query_02
{
    public partial class StudentTextbookRecordForAcademic : System.Web.UI.Page
    {
        private CPMis.IBLL.Tb_Query.Tb_Query_02.IStudentTextbookRecordBLL _TextbookRecordBLL =
            new CPMis.BLL.Tb_Query.Tb_Query_02.StudentTextbookRecordBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbTerm.DataSourceID = "Sql_Term";
                ccmbTerm.DataBind();
                ccmbTerm.InsertListItem(0, "---全部---", "全部");
                ccmbTerm.SelectedIndex = 1;
                ccmbSchool.DataSourceID = "SqlSchool";
                ccmbSchool.DataBind();
                ccmbSchool.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
                ccmbGrade.DataSourceID = "SqlGrade";
                ccmbGrade.DataBind();
                ccmbGrade.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
                ccmbClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
                ccmbStudent.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
            }
        }

        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbntQuery_Click(object sender, EventArgs e)
        {
            cgrdResult.DoDataBind();
        }

        /// <summary>
        /// gridview绑定前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdgrdResult_BeforeDataBind(object sender, EventArgs e)
        {
            string term = ccmbTerm.SelectedValue;
            decimal totalCharge = 0.0M;
            cgrdResult.DataSource = _TextbookRecordBLL.Fn_GetlistStudentTextbookRecord(ccmbStudent.SelectedValue, term, ref totalCharge);
            ctxtSumCharge.Text = totalCharge.ToString();
        }

        /// <summary>
        /// ccmbStudent联动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            cgrdResult.DoDataBind();
        }

        /// <summary>
        /// ccmbSchool联动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccmbClass.DataSourceID = "SqlClass";
            ccmbClass.DataBind();
            ccmbClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
            ccmbStudent.DataSourceID = "SqlStudent";
            ccmbStudent.DataBind();
            ccmbStudent.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// ccmbGrade联动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccmbClass.DataSourceID = "SqlClass";
            ccmbClass.DataBind();
            ccmbClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
            ccmbStudent.DataSourceID = "SqlStudent";
            ccmbStudent.DataBind();
            ccmbStudent.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// ccmbClass联动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccmbStudent.DataSourceID = "SqlStudent";
            ccmbStudent.DataBind();
            ccmbStudent.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }
    }
}