using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.DeclarationProgressService;


namespace TextbookManage.WebUI.Declaration
{
    public partial class DepartmentProgress : USCTAMis.Web.WebControls.Page
    {

        #region 属性与构造函数

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载
            if (!IsPostBack)
            {
                //采用QueryString方式传值
                if (!string.IsNullOrWhiteSpace(Request.QueryString["SchoolId"]) && !string.IsNullOrWhiteSpace(Request.QueryString["DataSignId"]))
                {
                    _schoolId = Request.QueryString["SchoolId"];
                    _dataSignId = Request.QueryString["DataSignId"];
                }

                ////跨页面调用传值
                //if (PreviousPage != null)
                //{
                //    if (PreviousPage.IsCrossPagePostBack)
                //    {
                //        SchoolProgress sourcePage = PreviousPage as SchoolProgress;
                //        _schoolId = sourcePage.SchoolId;
                //        _dataSignId = sourcePage.DataSignId;

                //    }
                //}
                ccmbDepartment.DataBind();

            }
        }
        #endregion

        private string _schoolId
        {
            get
            {
                return (string)ViewState["SchoolId"];
            }
            set
            {
                ViewState["SchoolId"] = value;
            }
        }

        private string _dataSignId
        {
            get
            {
                return (string)ViewState["DataSignId"];
            }
            set
            {
                ViewState["DataSignId"] = value;
            }
        }

        #region 申报进度

        protected void cgrdDeclarationList_BeforeDataBind(object sender, EventArgs e)
        {
            //采用QueryString方式传值
            //string schoolId = Request.QueryString["SchoolId"];
            //string yearTerm = Request.QueryString["YearTerm"];
            //string dataSignId = Request.QueryString["DataSignId"];

            var departmentId = ccmbDepartment.SelectedValue;

            using (DeclarationProgressApplClient client = new DeclarationProgressApplClient())
            {
                cgrdDeclarationList.DataSource = client.GetDepartmentProgress(_dataSignId, departmentId);
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
                    case "100":
                        dataItem["Proportion"].BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "0":
                        dataItem["Proportion"].BackColor = System.Drawing.Color.Red;
                        break;
                    default:
                        dataItem["Proportion"].BackColor = System.Drawing.Color.Orange;
                        break;
                }
            }
        }
        #endregion

        #region 系教研室

        protected void ccmbDepartment_DataBinding(object sender, EventArgs e)
        {
            using (DeclarationProgressApplClient client = new DeclarationProgressApplClient())
            {
                ccmbDepartment.DataSource = client.GetDepartments(_schoolId);
            }
        }

        protected void ccmbDepartment_DataBound(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }

        protected void ccmbDepartment_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }
        #endregion

        #region 查询

        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }
        #endregion

    }
}