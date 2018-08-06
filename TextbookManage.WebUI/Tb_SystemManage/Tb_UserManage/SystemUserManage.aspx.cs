using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;

namespace CPMis.WebPage.SystemManageUI.UserManageUI
{
    public partial class UserManage : CPMis.Web.WebControls.Page
    {
        private static CPMis.IBLL.Sys.IUser _user = new CPMis.BLL.Sys.User();
        private static CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DataBind();
            }
        }

        /// <summary>
        /// AJAX异步回调
        /// </summary>
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                case "OK":
                    btn_Query.DoClick();
                    break;
                case "Help":
                    OpenHelpFile("/Help/SystemManage/系统管理.htm");
                    break;
                default:
                    //wg_UserManage.DoDataBind();
                    break;
            }
        }

        #region 有关grid
        ///// <summary>
        ///// 确定按钮点击事件后,获取数据进行数据源绑定
        ///// </summary>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            wg_StudentManage.DataBind();
        }

        protected void btn_BooksellerQuery_Click(object sender, EventArgs e)
        {
            wg_Bookseller.DataBind();
        }

        protected void btn_TeacherQuery_Click(object sender, EventArgs e)
        {
            wg_TeacherManage.DataBind();
        }

 
        ///// <summary>
        ///// webgrid单元点击事件
        ///// </summary>
        protected void wg_StudentManage_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string commandName = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (commandName.Equals("UserFunction"))//拥有功能
            {
                OpenNewWindow(dataItem, "UserFunctionList.aspx");
            }
            //else if (commandName.Equals("UpdateUser"))//点击姓名列
            //{
            //    UpdateUser(sender, dataItem);
            //}
            //else if (commandName.Equals("FunctionAuthorize"))//单独授权
            //{
            //    OpenNewWindow(dataItem, "UserFunctionAloneAuthorize.aspx");
            //}

        }

        protected void wg_Bookseller_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string commandName = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (commandName.Equals("UserFunction"))//拥有功能
            {
                OpenNewWindow(dataItem, "UserFunctionList.aspx");
            }
        }

        protected void wg_TeacherManage_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string commandName = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (commandName.Equals("UserFunction"))//拥有功能
            {
                OpenNewWindow(dataItem, "UserFunctionList.aspx");
            }
        }
        ///// <summary>
        ///// 打开功能角色OpenWindow
        ///// </summary>
        private void OpenNewWindow(GridDataItem dataItem, string Path)
        {
            CPMis.Model.Sys.UserModel userModel = new CPMis.Model.Sys.UserModel();
            userModel.UserName = dataItem["UserName"].Text.Trim();
            if (!string.IsNullOrEmpty(userModel.UserName))
            {
                userModel.Name = dataItem["Name"].Text.Trim();

                userModel.UserID = dataItem["UserID"].Text.Trim();
                PagePath = Path;
                SetPageParameter<CPMis.Model.Sys.UserModel>(userModel);
                CPMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 550, 800);
            }
            else
                CPMis.Web.WebClient.ScriptManager.Alert("此用户非系统功能用户，无功能列表！");
        }
        #endregion

    }
}
