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
using Telerik.Web.UI;

namespace CPMis.WebPage.SystemManageUI.RoleManageUI
{
    public partial class PoleManage : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_RoleManage.DoDataBind();
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
                case "Delete":
                    btn_Manage_DeleteClick();
                    break;
                case "Help":
                    //OpenHelpFile("/Help/SystemManage/系统管理.htm");
                    break;
                default:
                    //wg_RootFunction.DoDataBind();
                    wg_RoleManage.DoDataBind();
                    break;
            }
        }

        #region 有关ViewState状态
        /// <summary>
        /// 是否是更新
        /// </summary>
        private bool IsUpdate
        {
            get { return ViewState["IsUpdate"] == null ? false : (bool)ViewState["IsUpdate"]; }
            set { ViewState["IsUpdate"] = value; }
        }
        /// <summary>
        /// 原角色名称
        /// </summary>
        private string OldRoleName
        {
            get { return ViewState["OldRoleName"] == null ? "" : ViewState["OldRoleName"].ToString(); }
            set { ViewState["OldRoleName"] = value; }
        }
        #endregion

        #region 有关工具条
        /// <summary>
        /// 删除角色,在BLL中先删除角色功能，后删除角色
        /// </summary>
        private void btn_Manage_DeleteClick()
        {
            string deleteMessage = "";
            if (wg_RoleManage.DataSource == null)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("没有数据,不能进行操作!");
                return;
            }
            wg_RoleManage.PersistCheckState<CPMis.Model.Sys.RoleModel>();
            IList<CPMis.Model.Sys.RoleModel> modelList =
                 wg_RoleManage.GetAllCheckedDataList<CPMis.Model.Sys.RoleModel>();
            if (modelList.Count == 0)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请先选择后在进行操作!");
                return;
            }

            deleteMessage = _role.BatchDeleteRoles(modelList);
            CPMis.Web.WebClient.ScriptManager.Alert(deleteMessage);
            wg_RoleManage.DoDataBind();
        }
        #endregion

        #region 有关webgrid
        /// <summary>
        /// 绑定前,获取数据源
        /// </summary>
        protected void wg_RoleManage_BeforeDataBind(object sender, EventArgs e)
        {
            wg_RoleManage.DataSource = _role.Retrieve();
        }
        /// <summary>
        /// OnItemCommand事件
        /// </summary>
        protected void wg_RoleManage_ItemCommand(object sender, GridCommandEventArgs e)
        {
            // convert the ParentControl to a CellItem object
            string key = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (key.Equals("RoleFunction"))//角色功能
            {
                OpenNewWindow(dataItem, "RoleFunctionList.aspx");
            }
            else if (key.Equals("RoleUser"))//角色用户
            {
                OpenNewWindow(dataItem, "RoleUserList.aspx");
            }
        }
        /// <summary>
        /// 打开功能角色OpenWindow
        /// </summary>
        private void OpenNewWindow(GridDataItem dataItem, string Path)
        {
            CPMis.Model.Sys.RoleModel roleModel = new CPMis.Model.Sys.RoleModel();
            roleModel.ID = new Guid(dataItem["ID"].Text.ToString());
            roleModel.RoleName = dataItem["RoleName"].Text.ToString();
            PagePath = Path;
            SetPageParameter<CPMis.Model.Sys.RoleModel>(roleModel);
            CPMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 550, 800);
        }
        /// <summary>
        /// 全选或全不选
        /// </summary>
        protected void chb_HeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            CPMis.Web.WebControls.CPMisCheckBox chx = sender as CPMis.Web.WebControls.CPMisCheckBox;
            wg_RoleManage.SetAllCheckControlState(chx.Checked);
        }
        /// <summary>
        /// 分页前事件
        /// </summary>
        protected void wg_RoleManage_BeforePageIndexChanged(object sender, EventArgs e)
        {
            wg_RoleManage.PersistCheckState<CPMis.Model.Sys.RoleModel>();
        }
        #endregion

    }
}
