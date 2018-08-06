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
    public partial class TeacherUserFunctionList : CPMis.Web.WebControls.Page
    {
        private static CPMis.IBLL.Sys.IUser _userBLL = new CPMis.BLL.Sys.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_UserFunction.DoDataBind();
            }
        }
        /// <summary>
        /// webgrid绑定前进行数据源获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wg_UserFunction_BeforeDataBind(object sender, EventArgs e)
        {
            CPMis.Model.Sys.UserModel userModel = 
                CPMis.Web.WebClient.SerializeDataManager.GetSerializeData<CPMis.Model.Sys.UserModel>(Request.QueryString[0]);
            if (null != userModel)
            {
                lbl_UserName.Text = userModel.Name + " " + userModel.UserName;
                wg_UserFunction.DataSource = _userBLL.GetUserFunctionList(userModel.UserName);
            }
        }

        //protected void wg_UserFunction_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item is GridDataItem)
        //    {
        //        GridDataItem dateItem = e.Item as GridDataItem;
        //        switch (dateItem["IsShow"].Text.Trim())
        //        {
        //            case "0":
        //                dateItem["IsShow"].Text = "否";
        //                break;
        //            case "1":
        //                dateItem["IsShow"].Text = "是";
        //                break;
        //            default:
        //                dateItem["IsShow"].Text = "未指定";
        //                break;
        //        }
        //    }
        //}

        #region 有关工具条
        /// <summary>
        /// AJAX异步回调
        /// </summary>
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                case "Delete":
                    break;
                case "Help":
                    OpenHelpFile("/Help/SystemManage/系统管理.htm");
                    break;
                default:
                    wg_UserFunction.DoDataBind();
                    break;
            }
        }
        #endregion 
    }
}
