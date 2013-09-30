using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextbookManage.WebUI.Declaration
{
    public partial class DepartmentProgress : USCTAMis.Web.WebControls.Page
    {

        #region 属性与构造函数

        //获取登陆用户
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        readonly string _loginName = "46010";
        //新华书店，dongxb
        //外国语教师，46010
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl
        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;

        //创建申报实例
        TextbookManage.Application.Interface.IProgress _progress;

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _progress = new TextbookManage.Application.Factory.PopWindowFactory().CreateProgressApplication();
            //首次加载
            if (!IsPostBack)
            {
                //if (!string.IsNullOrWhiteSpace(Request.QueryString["SchoolId"]) && !string.IsNullOrWhiteSpace(Request.QueryString["YearTerm"]) && !string.IsNullOrWhiteSpace(Request.QueryString["DataSignId"]))
                //{
                //    cgrdDeclarationList.DoDataBind();
                //}
                cgrdDeclarationList.DoDataBind();

            }
        }
        #endregion

        #region 申报进度

        protected void cgrdDeclarationList_BeforeDataBind(object sender, EventArgs e)
        {
            //string schoolId = Request.QueryString["SchoolId"];
            //string yearTerm = Request.QueryString["YearTerm"];
            //string dataSignId = Request.QueryString["DataSignId"];

            //跨页面调用
            if (PreviousPage != null)
            {
                if (PreviousPage.IsCrossPagePostBack)
                {
                    SchoolProgress sourcePage = PreviousPage as SchoolProgress;
                    string yearTerm = sourcePage.YearTerm;
                    string schoolId = sourcePage.SchoolId;
                    string dataSignId = sourcePage.DataSignId;

                    cgrdDeclarationList.DataSource = _progress.GetDepartmentProgress(yearTerm, dataSignId, schoolId);
                }
            }
        }
        #endregion

        #region Ajax

        /// <summary>
        /// Ajax回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                default:
                    cgrdDeclarationList.DoDataBind();
                    break;
            }
        }
        #endregion

        #region 进度颜色处理

        /// <summary>
        /// 完成绿色
        /// 进行中黄色
        /// 没开始红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDeclarationList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is Telerik.Web.UI.GridDataItem)
            {
                Telerik.Web.UI.GridDataItem dataItem = e.Item as Telerik.Web.UI.GridDataItem;
                switch (dataItem["Proportion"].Text)
                {
                    case "100%":
                        dataItem["Proportion"].BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "0%":
                        dataItem["Proportion"].BackColor = System.Drawing.Color.Red;
                        break;
                    default:
                        dataItem["Proportion"].BackColor = System.Drawing.Color.Orange;
                        break;
                }
            }
        }
        #endregion

    }
}