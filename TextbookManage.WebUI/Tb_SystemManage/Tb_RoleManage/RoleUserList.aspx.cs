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

namespace CPMis.WebPage.SystemManageUI.RoleManageUI
{
    using UserModel = CPMis.Model.Sys.UserModel;
    using RoleModel = CPMis.Model.Sys.RoleModel;
    using System.Collections.Generic;
    using Telerik.Web.UI;

    public partial class RoleUserList : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();
        private CPMis.IBLL.Sys.IUser _user = new CPMis.BLL.Sys.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_RoleUserList.DoDataBind();
            }
        }
        /// <summary>
        /// 角色名
        /// </summary>
        private string RoleName
        {
            get { return ViewState["RoleName"] == null ? "" : ViewState["RoleName"].ToString(); }
            set { ViewState["RoleName"] = value; }
        }
        #region 有关grid
        /// <summary>
        /// 获取参数设置数据源，初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wg_RoleUserList_BeforeDataBind(object sender, EventArgs e)
        {
            RoleModel roleModel = CPMis.Web.WebClient.SerializeDataManager.GetSerializeData<RoleModel>(Request.QueryString[0]);
            string[] userNames = null;
            if (null != roleModel)
            {
                RoleName = roleModel.RoleName;
                lbl_RoleName.Text = RoleName;
                userNames = _role.GetUsersInRole(roleModel.RoleName);
            }
            else if (!lbl_RoleName.Text.Trim().Equals(""))
            {
                userNames = _role.GetUsersInRole(lbl_RoleName.Text.Trim());
            }
            wg_RoleUserList.DataSource = _role.GetSystemUserListByUsers(userNames);
        }
        /// <summary>
        /// webgrid行初始化时格式化用户类型和用户级别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void tb_RoleUserList_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item is GridDataItem)
        //    {
        //        GridDataItem dataItem = e.Item as GridDataItem;
        //        switch (dataItem["UserLevel"].Text.Trim())
        //        {
        //            case "01":
        //                dataItem["UserLevel"].Text = "学生级";
        //                break;
        //            case "02":
        //                dataItem["UserLevel"].Text = "教师级";
        //                break;
        //            //case "03":
        //            //    dataItem["UserLevel"].Text = "派出所级别";
        //            //    break;
        //            //case "04":
        //            //    dataItem["UserLevel"].Text = "民警级别";
        //            //    break;
        //            default:
        //                dataItem["UserLevel"].Text = "未知级别";
        //                break;
        //        }
        //    }
        //}
        /// <summary>
        /// 列头复选框选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chb_HeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            CPMis.Web.WebControls.CPMisCheckBox chx = sender as CPMis.Web.WebControls.CPMisCheckBox;
            wg_RoleUserList.SetAllCheckControlState(chx.Checked);
        }
        /// <summary>
        /// 分页前事件
        /// </summary>
        protected void wg_RoleUserList_BeforePageIndexChanged(object sender, EventArgs e)
        {
            wg_RoleUserList.PersistCheckState<CPMis.Model.Sys.UserModel>();
        }
        #endregion

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
                    btn_Manage_DeleteClick();//删除
                    break;
                case "Help":
                    //OpenHelpFile("/Help/SystemManage/系统管理.htm");
                    break;
                case "Query":
                    btn_Manage_QueryClick();//过滤查询
                    break;
                default:
                    wg_RoleUserList.DoDataBind();
                    break;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btn_Manage_DeleteClick()
        {
            string deleteMessage = "";
            if (wg_RoleUserList.DataSource == null)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("没有数据,不能进行操作!");
                return;
            }
            wg_RoleUserList.PersistCheckState<CPMis.Model.Sys.SystemUsersInfoModel>();
            IList<CPMis.Model.Sys.SystemUsersInfoModel> modelList =
                 wg_RoleUserList.GetAllCheckedDataList<CPMis.Model.Sys.SystemUsersInfoModel>();
            if (modelList.Count == 0)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请先选择后再进行操作!");
                return;
            }

            deleteMessage = _role.BatchDeleteUsersInRole(modelList, RoleName);
            CPMis.Web.WebClient.ScriptManager.Alert(deleteMessage);
            wg_RoleUserList.DoDataBind();
        }
        /// <summary>
        /// 过滤查询
        /// </summary>
        private void btn_Manage_QueryClick()
        {
            CPMis.Common.SimpleDictionary dictionary = new CPMis.Common.SimpleDictionary(2);
            CPMis.Web.WebControls.CPMisTextBox txt_Query =
                tb_RoleUserList.Items[2].FindControl("txt_Query") as CPMis.Web.WebControls.CPMisTextBox;
            if (null != txt_Query)
            {
                dictionary.Add(CPMis.Common.ParameterList.Sys.User.UserNameKey, txt_Query.Text.Trim());
                dictionary.Add(CPMis.Common.ParameterList.Sys.Role.RoleNameKey, lbl_RoleName.Text.Trim());
                wg_RoleUserList.DataSource = _user.QueryUserListByName(dictionary);
                wg_RoleUserList.DataBind();
            }
        }
        #endregion 
        
    }
}
