using System;
using System.Linq;

namespace TextbookManage.WebUI.Declaration
{
    public partial class CourseTextbookPrint : USCTAMis.Web.WebControls.Page
    {
        public USCTAMis.IBLL.Educational.TeachingTask.IFillTeachingTask _FillTeachingTaskBll =
            new USCTAMis.BLL.Educational.TeachingTask.FillTeachingTask();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ddl_Yea1rTerm.DoDataBind();
                cb_DataSign.DoDataBind();
                ddl_School.DoDataBind();
                ddl_ReportType.DoDataBind();
            }
        }

        /// <summary>
        /// 根据学院获取教研室
        /// </summary>
        protected void ddl_Office_Bind(object sender, EventArgs e)
        {
            ddl_Office.DoDataBind();
        }

        /// <summary>
        /// 学院绑定前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_School_beforeBind(object sender, EventArgs e)
        {
            ddl_School.DataSource = _FillTeachingTaskBll.GetSchoolList(ddl_Yea1rTerm.GetData<USCTAMis.Model.BaseInfo.TermModel>(),
                cb_DataSign.SelectedValue);
            ddl_School.DataTextField = "SchoolName";  //文本绑定字段
            ddl_School.DataValueField = "SchoolID";   //VALUE绑定字段
        }

        protected void ddl_Yea1rTerm_Bind(object sender, EventArgs e)
        {
            ddl_School.DoDataBind();
        }

        /// <summary>
        /// 绑定教研室数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Office_BeforeDataBind(object sender, EventArgs e)
        {
            if (cb_DataSign.SelectedIndex != -1 && ddl_Yea1rTerm.SelectedIndex != -1 && ddl_School.SelectedIndex != -1)
            {
                ddl_Office.DataSource = _FillTeachingTaskBll.GetStaffRoomList(ddl_Yea1rTerm.GetData<USCTAMis.Model.BaseInfo.TermModel>(),
                    ddl_School.SelectedValue,
                    cb_DataSign.SelectedValue);
                ddl_Office.DataTextField = "SchoolName";  //文本绑定字段
                ddl_Office.DataValueField = "SchoolID";   //VALUE绑定字段
            }
        }

        protected void rpv_CourseTextBookPrint_beforeDataBind(object sender, EventArgs e)
        {
            string[] yearTerm = ddl_Yea1rTerm.SelectedValue.Split('-');
            string year = String.Format("{0}-{1}", yearTerm[0], yearTerm[1]);
            string term = yearTerm[2];
            if (ddl_Office.SelectedText.StartsWith("√") || ddl_Office.SelectedValue == Guid.Empty.ToString())
            {
                IsFinalDraft = "1";
            }
            else
            {
                IsFinalDraft = "0";
            }
            rpv_CourseTextBookPrint.ReportName = ddl_ReportType.SelectedValue;
            rpv_CourseTextBookPrint.ParameterNames = "SchoolYear,SchoolTerm,DataSign,CourseSchoolID,CourseStaffroomID,IsFinalDraft";
            rpv_CourseTextBookPrint.Parameters = new string[] { year, term, cb_DataSign.SelectedValue, ddl_School.SelectedValue, ddl_Office.SelectedValue, IsFinalDraft };
        }

        /// <summary>
        /// 定义是否正高参数
        /// </summary>
        public string IsFinalDraft
        {
            get
            {
                return ViewState["IsFinalDraft"].ToString();
            }
            set
            {
                ViewState["IsFinalDraft"] = value;
            }
        }

        protected void btn_Preveiw_Click(object sender, EventArgs e)
        {
            rpv_CourseTextBookPrint.DoPrint();
        }
    }
}