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

namespace CPMis.WebPage.SystemMangageUI.FunctionManageUI
{
    public partial class FunctionManage : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IFunction _functionBLL = new CPMis.BLL.Sys.Function();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_RootFunction.DoDataBind();
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
                    wg_RootFunction.DoDataBind();
                    //wg_FunctionManage.DoDataBind();
                    break;
            }
        }

        #region 有关ViewState保存状态
        /// <summary>
        /// 是否是修改
        /// </summary>
        private bool IsUpdate
        {
            get { return ViewState["IsUpdate"] == null ? false : (bool)ViewState["IsUpdate"]; }
            set { ViewState["IsUpdate"] = value; }
        }
        /// <summary>
        /// 功能ID标识
        /// </summary>
        private new string ID
        {
            get { return ViewState["ID"] == null ? "" : ViewState["ID"].ToString(); }
            set { ViewState["ID"] = value; }
        }
        /// <summary>
        /// 功能ID
        /// </summary>
        private string FunctionID
        {
            get { return ViewState["FunctionID"] == null ? "10000000" : ViewState["FunctionID"].ToString(); }
            set { ViewState["FunctionID"] = value; }
        }
        #endregion

        #region 有关左边webgrid
        /// <summary>
        /// 获取根节点
        /// </summary>
        protected void wg_RootFunction_BeforeDataBind(object sender, EventArgs e)
        {
            wg_RootFunction.DataSource = _functionBLL.GetRootFunctionList();
        }
        /// <summary>
        /// 获取根节点后获取该根节点的子节点
        /// </summary>
        protected void wg_RootFunction_AfterDataBind(object sender, EventArgs e)
        {
            wg_FunctionManage.DoDataBind();
        }
        /// <summary>
        /// wg_RootFunction单元点击事件
        /// </summary>
        protected void wg_RootFunction_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridDataItem dataItem = e.Item as GridDataItem;
            if (e.CommandName == "OpenLeafFunction")
            {
                FunctionID = dataItem["FunctionID"].Text.Trim();
                wg_FunctionManage.DoDataBind();
            }
        }
        #endregion

        #region 有关右边webgrid
        /// <summary>
        /// 获取数据源并绑定
        /// </summary>
        protected void wg_FunctionManage_BeforeDataBind(object sender, EventArgs e)
        {
            wg_FunctionManage.DataSource = _functionBLL.GetLeafFunctionList(FunctionID);
        }
        /// <summary>
        /// 
        /// </summary>
        //protected void wg_FunctionManage_ItemDataBound(object sender, GridItemEventArgs e)
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
        /// Checkbox选择改变,子随父改变,选中父节点菜单子节点也选中,数据必须已排序
        /// </summary>
        protected void chb_RowCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbBox = (CheckBox)sender;
            GridDataItem dataItem = (GridDataItem)chbBox.NamingContainer;
            string twoZero = "00";
            string fourZero = "0000";
            string sixZero = "000000";
            string eightZero = "00000000";
            string desMatchFigure = "";
            string srcMatch = dataItem["FunctionID"].Text.ToString();
            string desMatch = "";
            if (srcMatch.EndsWith(eightZero))
            {
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 8);
            }
            else if (srcMatch.EndsWith(sixZero))
            {
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 6);
            }
            else if (srcMatch.EndsWith(fourZero))
            {
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 4);
            }
            else if (srcMatch.EndsWith(twoZero))
            {
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 2);
            }
            else
            {
                return;
            }
            bool isCheck = ((CPMis.Web.WebControls.CPMisCheckBox)dataItem.FindControl(wg_FunctionManage.CheckControlID)).Checked;
            do
            {
                if (wg_FunctionManage.Items.Count <= dataItem.ItemIndex + 1)
                {
                    break;
                }
                dataItem = wg_FunctionManage.Items[dataItem.ItemIndex + 1];
                if (null == dataItem)
                {
                    return;
                }
                desMatch = dataItem["FunctionID"].Text.ToString();
                if (desMatch.StartsWith(desMatchFigure))
                {
                    wg_FunctionManage.SetCheckControlState(isCheck, dataItem.ItemIndex);
                }
                else
                {
                    return;
                }

            } while (true);

        }
        /// <summary>
        /// webgrid模板单元点击事件
        /// </summary>
        protected void wg_FunctionManage_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string name=e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (name == "LookRole")
            {
                OpenNewWindow(dataItem, "FunctionRoleList.aspx");
            }
            else if (name == "LookUser")
            {
                OpenNewWindow(dataItem, "FunctionUserList.aspx");
            }
        }
        /// <summary>
        /// 打开功能角色OpenWindow
        /// </summary>
        private void OpenNewWindow(GridDataItem dataItem, string Path)
        {
            CPMis.Model.Sys.FunctionModel functionModel = new CPMis.Model.Sys.FunctionModel();
            functionModel = wg_FunctionManage.GetData<CPMis.Model.Sys.FunctionModel>(dataItem.ItemIndex);
            PagePath = Path;
            SetPageParameter<CPMis.Model.Sys.FunctionModel>(functionModel);
            CPMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 550, 800);
        }
        /// <summary>
        /// 全选或全不选
        /// </summary>
        protected void chb_HeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            CPMis.Web.WebControls.CPMisCheckBox chx = sender as CPMis.Web.WebControls.CPMisCheckBox;
            wg_FunctionManage.SetAllCheckControlState(chx.Checked);
        }

        #endregion

        #region 有关工具条
        /// <summary>
        /// 删除功能
        /// </summary>
        private void btn_Manage_DeleteClick()
        {
            string deleteMessage = "";
            if (wg_FunctionManage.DataSource == null)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("没有数据,不能进行操作!");
                return;
            }
            wg_FunctionManage.PersistCheckState<CPMis.Model.Sys.FunctionModel>();
            IList<CPMis.Model.Sys.FunctionModel> modelList =
                 wg_FunctionManage.GetAllCheckedDataList<CPMis.Model.Sys.FunctionModel>();
            if (modelList.Count == 0)
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请先选择后再进行操作!");
                return;
            }
            deleteMessage = _functionBLL.BatchDeleteFunctions(modelList);
            CPMis.Web.WebClient.ScriptManager.Alert(deleteMessage);
            wg_RootFunction.DoDataBind();
        }
        #endregion
    }
}
