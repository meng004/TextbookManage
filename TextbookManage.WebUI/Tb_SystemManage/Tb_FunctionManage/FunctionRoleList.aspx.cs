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
using System.Collections.Generic;

namespace CPMis.WebPage.SystemManageUI.FunctionManageUI
{
    using FunctionModel = CPMis.Model.Sys.FunctionModel;
    using Telerik.Web.UI;
    public partial class FunctionRoleList : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IFunction _functionBLL = new CPMis.BLL.Sys.Function();
        private CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_FunctionRoleList.DoDataBind();
            }
        }
        /// <summary>
        /// 功能ID
        /// </summary>
        private string SysFunctionID
        {
            get { return ViewState["SysFunctionID"] == null ? "" : ViewState["SysFunctionID"].ToString(); }
            set { ViewState["SysFunctionID"] = value; }
        }
        /// <summary>
        /// 获取数据源，初始化页面
        /// </summary>
        protected void wg_FunctionRoleList_BeforeDataBind(Object sender, EventArgs e)
        {
            FunctionModel functionModel = CPMis.Web.WebClient.SerializeDataManager.GetSerializeData<FunctionModel>(Request.QueryString[0]);
            IList<CPMis.Model.Sys.RoleModel> roleList = null;
            if (null != functionModel)
            {
                SysFunctionID = functionModel.ID.ToString();
                lbl_FunctionID.Text = functionModel.FunctionID.ToString();
                lbl_FunctionName.Text = functionModel.FunctionName.ToString();
                lbl_FunctionURL.Text = functionModel.FunctionURL.ToString();
                //roleList = _functionBLL.GetFunctionRoleList(functionModel.FunctionURL);
                roleList = _functionBLL.GetFunctionRoleList(SysFunctionID);
            }
            else if (!lbl_FunctionID.Text.Trim().Equals(""))
            {
                //roleList = _functionBLL.GetFunctionRoleList(lbl_FunctionURL.Text.Trim());
                roleList = _functionBLL.GetFunctionRoleList(SysFunctionID);
            }
            wg_FunctionRoleList.DataSource = roleList;
        }
        /// <summary>
        /// Toolbar点击事件
        /// </summary>
        protected void tb_FunctonRoleList_ButtonClicked(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton btn = e.Item as RadToolBarButton;
            string commandName = btn.CommandName;
            if (commandName == "Delete")
            {
                btn_Manage_DeleteClick();
            }
            else if (commandName == "Query")
            {
                tbn_Manage_QueryClick();
            }
            else if (commandName == "Help")
            {
                //OpenHelpFile("/Help/SystemManage/系统管理.htm");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btn_Manage_DeleteClick()
        {
            string deleteMessage = "";
            if (wg_FunctionRoleList.DataSource == null)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("没有数据,不能进行删除操作!");
                return;
            }
            wg_FunctionRoleList.PersistCheckState<CPMis.Model.Sys.RoleModel>();
            IList<CPMis.Model.Sys.RoleModel> modelList =
                 wg_FunctionRoleList.GetAllCheckedDataList<CPMis.Model.Sys.RoleModel>();
            if (modelList.Count == 0)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请先选择后在进行操作!");
                return;
            }
            deleteMessage = _role.BatchDeleteFunctionRoles(modelList, SysFunctionID);
            CPMis.Web.WebClient.ScriptManager.Alert(deleteMessage);
            wg_FunctionRoleList.DoDataBind();
        }
        /// <summary>
        /// 查找过滤
        /// </summary>
        private void tbn_Manage_QueryClick()
        {
            CPMis.Common.SimpleDictionary dictionary = new CPMis.Common.SimpleDictionary(2);
            CPMis.Web.WebControls.CPMisTextBox txt_Query =
                tb_FunctonRoleList.Items[2].FindControl("txt_Query") as CPMis.Web.WebControls.CPMisTextBox;
            if (null != txt_Query)
            {
                dictionary.Add(CPMis.Common.ParameterList.Sys.Role.RoleNameKey, txt_Query.Text.Trim());
                //dictionary.Add(CPMis.Common.ParameterList.Sys.Function.FunctionUrlKey, lbl_FunctionURL.Text.Trim());
                dictionary.Add(CPMis.Common.ParameterList.Sys.Function.SysFunctionIDKey, SysFunctionID);
                wg_FunctionRoleList.DataSource = _role.Retrieve(dictionary);
                wg_FunctionRoleList.DataBind();
            }
        }
        /// <summary>
        /// 全选或全不选
        /// </summary>
        protected void chb_HeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            CPMis.Web.WebControls.CPMisCheckBox chx = sender as CPMis.Web.WebControls.CPMisCheckBox;
            wg_FunctionRoleList.SetAllCheckControlState(chx.Checked);
        }
        /// <summary>
        /// 分页前事件
        /// </summary>
        protected void wg_FunctionRoleList_BeforePageIndexChanged(object sender, EventArgs e)
        {
            wg_FunctionRoleList.PersistCheckState<CPMis.Model.Sys.RoleModel>();
        }
    }
}
