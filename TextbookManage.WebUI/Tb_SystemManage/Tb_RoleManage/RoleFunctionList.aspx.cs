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

namespace CPMis.WebPage.SystemManageUI.RoleManageUI
{
    using RoleModel = CPMis.Model.Sys.RoleModel;
    using Telerik.Web.UI;
    public partial class RoleFunctionList : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_FunctionRoleList.DoDataBind();
            }
        }
        private string RoleID
        {
            get { return ViewState["RoleID"] == null ? "" : ViewState["RoleID"].ToString(); }
            set { ViewState["RoleID"] = value; }
        }
        /// <summary>
        /// webgrid绑定前获取数据源进行初始化
        /// </summary>
        protected void wg_FunctionRoleList_BeforeDataBind(object sender, EventArgs e)
        {
            RoleModel roleModel = CPMis.Web.WebClient.SerializeDataManager.GetSerializeData<RoleModel>(Request.QueryString[0]);
            IList<CPMis.Model.Sys.FunctionModel> functionList = null;
            if (null != roleModel)
            {
                RoleID = roleModel.ID.ToString();
                lbl_RoleName.Text = roleModel.RoleName.ToString();
                functionList = _role.GetRoleFunctionList(roleModel.RoleName);
            }
            else if (!string.IsNullOrEmpty(RoleID))
            {
                functionList = _role.GetRoleFunctionList(lbl_RoleName.Text.Trim());
            }
            wg_FunctionRoleList.DataSource = functionList;
        }
        /// <summary>
        /// 列头复选框选择
        /// </summary>
        protected void chb_HeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            CPMis.Web.WebControls.CPMisCheckBox chx = sender as CPMis.Web.WebControls.CPMisCheckBox;
            wg_FunctionRoleList.SetAllCheckControlState(chx.Checked);
        }
        ///// <summary>
        ///// Toolbar点击事件
        ///// </summary>
        //protected void tb_RoleFunctionUserList_ButtonClicked(object sender, RadToolBarEventArgs e)
        //{
        //    RadToolBarButton btn = e.Item as RadToolBarButton;
        //    string commandName = btn.CommandName;
        //    if (commandName == "Delete")
        //    {
        //        btn_Manage_DeleteClick();
        //    }
        //    else if (commandName == "Help")
        //    {
        //        OpenHelpFile("/Help/SystemManage/系统管理.htm");
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
                    btn_Manage_DeleteClick();
                    break;
                case "Help":
                    //OpenHelpFile("/Help/SystemManage/系统管理.htm");
                    break;
                default:
                    wg_FunctionRoleList.DoDataBind();
                    break;
            }
        }
        #endregion 
        /// <summary>
        /// 删除 根据角色ID，功能ID删除系统_角色功能表中记录
        /// </summary>
        private void btn_Manage_DeleteClick()
        {
            string deleteMessage = "";
            if (wg_FunctionRoleList.DataSource == null)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("没有数据,不能进行操作!");
                return;
            }
            wg_FunctionRoleList.PersistCheckState<CPMis.Model.Sys.FunctionModel>();
            IList<CPMis.Model.Sys.FunctionModel> modelList =
                 wg_FunctionRoleList.GetAllCheckedDataList<CPMis.Model.Sys.FunctionModel>();
            if (modelList.Count == 0)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请先选择后再进行操作!");
                return;
            }
            deleteMessage = _role.BatchDeleteRoleFunctions(modelList, RoleID);
            CPMis.Web.WebClient.ScriptManager.Alert(deleteMessage);
            wg_FunctionRoleList.DoDataBind(); 
        }

        //protected void wg_FunctionRoleList_ItemDataBound(object sender, GridItemEventArgs e)
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
        /// <summary>
        /// 复选框选中父则子也自动选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chb_RowCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbBox = (CheckBox)sender;
            GridDataItem dataItem = (GridDataItem)chbBox.NamingContainer;
            string twoZero = "00";
            string fourZero = "0000";
            string sixZero = "000000";
            string eightZero = "00000000";
            string desMatchFigure = "";
            string srcMatch = dataItem["FunctionNum"].Text.ToString();
            string desMatch = "";
            if (srcMatch.EndsWith(eightZero))
            {
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 8);
            }
            else if (srcMatch.EndsWith(sixZero))
            {
                desMatchFigure=srcMatch.Substring(0,srcMatch.Length-6);
            }
            else if (srcMatch.EndsWith(fourZero))
            {
                desMatchFigure=srcMatch.Substring(0,srcMatch.Length-4);
            }
            else if (srcMatch.EndsWith(twoZero))
            {
                desMatchFigure=srcMatch.Substring(0,srcMatch.Length-2);
            }
            else
            {
                return;
            }
            bool isCheck = ((CPMis.Web.WebControls.CPMisCheckBox)dataItem.FindControl(wg_FunctionRoleList.CheckControlID)).Checked;
            do
            {
                if (wg_FunctionRoleList.Items.Count <= dataItem.ItemIndex + 1)
                {
                    break;
                }
                dataItem = wg_FunctionRoleList.Items[dataItem.ItemIndex + 1];
                if (null == dataItem)
                {
                    return;
                }
                desMatch = dataItem["FunctionNum"].Text.ToString();
                if (desMatch.StartsWith(desMatchFigure))
                {
                    wg_FunctionRoleList.SetCheckControlState(isCheck, dataItem.ItemIndex);
                }
                else
                {
                    return; 
                }
            }while(true);
        }
    }
}
