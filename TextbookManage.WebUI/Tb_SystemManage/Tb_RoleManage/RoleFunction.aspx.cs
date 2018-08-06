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
    public partial class RoleFunction : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IFunction _function = new CPMis.BLL.Sys.Function();
        private CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_RoleName.DoDataBind();
            }
        }
        private string FunctionID
        {
            get { return ViewState["FunctionID"] == null ? "0100000000" : ViewState["FunctionID"].ToString(); }
            set { ViewState["FunctionID"] = value; }
        }
        /// <summary>
        /// AJAX异步回调
        /// </summary>
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                case "Save":
                    btn_Manage_SaveClick();//保存
                    break;
                case "Help":
                    //OpenHelpFile("/Help/SystemManage/系统管理.htm");//帮助
                    break;
                case "OK":
                    btn_Sure.DoClick();
                    break;

                default:
                    wg_RootFunctionList.DoDataBind();
                    break;
            }
        }

        #region wg_RootFunctionList事件
        /// <summary>
        /// 获取根节点
        /// </summary>
        protected void wg_RootFunctionList_BeforeDataBind(object sender, EventArgs e)
        {
            wg_RootFunctionList.DataSource = _function.GetRootFunctionList();
        }
        /// <summary>
        /// 获取根节点后获取该根节点的子节点
        /// </summary>
        protected void wg_RootFunctionList_AfterDataBind(object sender, EventArgs e)
        {
            wg_FunctionRoleList.DoDataBind();
        }
        /// <summary>
        /// wg_RootFunction单元点击事件
        /// </summary>
        protected void wg_RootFunctionList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string commandName = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (commandName == "FunctionName")//功能名称
            {
                FunctionID = dataItem["FunctionID"].Text.Trim();
                wg_FunctionRoleList.DoDataBind();
            }
        }
        #endregion
        #region wg_FunctionRoleList事件
        /// <summary>
        /// webgrid绑定前,获取该根节点下所有节点，然后要去勾选已有功能
        /// </summary>
        protected void wg_FunctionRoleList_BeforeDataBind(object sender, EventArgs e)
        {
            wg_FunctionRoleList.DataSource = _function.GetLeafFunctionList(FunctionID);
        }

        //protected void wg_FunctionRoleList_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item is GridDataItem)
        //    {
        //        GridDataItem dateItem = e.Item as GridDataItem;
        //        dateItem["IsShow"].Text = dateItem["IsShow"].Text.Trim() == "1" ? "是" : "否";
        //    }
        //}
        /// <summary>
        /// 获取该根节点，该角色下所有节点，然后要去勾选已有功能
        /// </summary>
        protected void wg_FunctionRoleList_AfterDataBind(object sender, EventArgs e)
        {
            IList<CPMis.Model.Sys.FunctionModel> functionList = _role.GetRoleInLeafFunctionList(ddl_RoleName.SelectedText.Trim(), FunctionID);
            foreach (GridDataItem item in wg_FunctionRoleList.Items)
            {
                int count = 0;
                while (count < functionList.Count)
                {
                    if (functionList.ElementAt(count).FunctionID.Equals(item["FunctionID"].Text.ToString()))
                    {
                        wg_FunctionRoleList.SetCheckControlState(true, item.ItemIndex);
                        //row.Style.BackColor = System.Drawing.Color.BlueViolet;
                        functionList.RemoveAt(count);
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
        /// <summary>
        /// 选中复选，前提是功能列表已按FunctionID已经排好序,选中父亲儿子也自动选中，选中儿子,该儿子父亲也选中
        /// </summary>
        protected void wg_FunctionRoleList_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbBox = (CheckBox)sender;
            GridDataItem dataItem = (GridDataItem)chbBox.NamingContainer;
            string twoZero = "00";
            string fourZero = "0000";
            string sixZero = "000000";
            string eightZero = "00000000";
            string desMatchFigure = "";//1001 03 如果是1001 0300
            string srcMatch = dataItem["FunctionID"].Text.ToString();
            string desMatch = "";
            int srcLen = srcMatch.Length;
            int len = 0;
            if (srcMatch.EndsWith(eightZero))
            {
                len = 8;
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 8);
            }
            else if (srcMatch.EndsWith(sixZero))
            {
                len = 6;
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 6);
            }
            else if (srcMatch.EndsWith(fourZero))
            {
                len = 4;
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 4);
            }
            else if (srcMatch.EndsWith(twoZero))
            {
                len = 2;
                desMatchFigure = srcMatch.Substring(0, srcMatch.Length - 2);
            }
            else
            {
                len = 0;
                desMatchFigure = srcMatch;
            }
            GridDataItem tmpDataItem = dataItem;
            //UltraGridRow row = e.Cell.Row;
            //UltraGridRow tempRow = row;
            //bool isCheck = (bool)row.Cells.FromKey(wg_FunctionRoleList.CheckControlID).Value;
            bool isCheck = ((CPMis.Web.WebControls.CPMisCheckBox)dataItem.FindControl(wg_FunctionRoleList.CheckControlID)).Checked;
            do//往下匹配
            {
                if (wg_FunctionRoleList.Items.Count <= dataItem.ItemIndex + 1)
                {
                    break;
                }
                dataItem = wg_FunctionRoleList.Items[dataItem.ItemIndex + 1];
                if (null == dataItem)
                {
                    break;
                }
                desMatch = dataItem["FunctionID"].Text.ToString();
                if (desMatch.StartsWith(desMatchFigure))
                {
                    wg_FunctionRoleList.SetCheckControlState(isCheck, dataItem.ItemIndex);
                }
                else//如果没有匹配的则往下肯定也没有匹配的了
                {
                    break;
                }

            } while (true);

            //row = tempRow;
            dataItem = tmpDataItem;
            do//往上匹配
            {
                if (dataItem.ItemIndex == 0)
                {
                    break;
                }
                dataItem = wg_FunctionRoleList.Items[dataItem.ItemIndex - 1];
                if (null == dataItem || len == 8)
                {
                    break;
                }
                desMatch = dataItem["FunctionID"].Text.ToString();
                if (desMatch.StartsWith(srcMatch.Substring(0, srcLen - len - 2)) &&
                    desMatch.EndsWith(new string('0', len + 2)))
                {
                    len = len + 2;
                    if (isCheck)//
                    {
                        wg_FunctionRoleList.SetCheckControlState(isCheck, dataItem.ItemIndex);
                    }
                }
            } while (true);
        }
        /// <summary>
        /// 全选或全不选
        /// </summary>
        protected void chb_HeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            CPMis.Web.WebControls.CPMisCheckBox chx = sender as CPMis.Web.WebControls.CPMisCheckBox;
            wg_FunctionRoleList.SetAllCheckControlState(chx.Checked);
        }
        #endregion
        #region ddl_RoleName事件
        /// <summary>
        /// 角色下拉列表绑定前
        /// </summary>
        protected void ddl_RoleName_BeforeDataBind(object sender, EventArgs e)
        {
            ddl_RoleName.DataSource = _role.Retrieve();
        }
        /// <summary>
        /// 角色下拉列表绑定后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_RoleName_AfterDataBind(object sender, EventArgs e)
        {
            btn_Sure.DoClick();
        }
        #endregion 
        #region btn_Sure事件
        /// <summary>
        /// 确定点击前,将复选框状态全部置为不选中
        /// </summary>
        protected void btn_Sure_BeforeClick(object sender, EventArgs e)
        {
            wg_RootFunctionList.DoDataBind();
        }
        /// <summary>
        /// 确定点击后,检索数据，如果该角色存在这个功能，则该功能复选框选中
        /// </summary>
        protected void btn_Sure_AfterClick(object sender, EventArgs e)
        {
            IList<CPMis.Model.Sys.FunctionModel> functionList = _role.GetRoleFunctionList(ddl_RoleName.SelectedText.Trim());
            foreach (GridDataItem item in wg_RootFunctionList.Items)
            {
                int count = 0;
                while (count < functionList.Count)
                {
                    if (functionList.ElementAt(count).FunctionID.Substring(0,2).Equals(item["FunctionID"].Text.ToString().Substring(0,2)))
                    {
                        item.ForeColor = System.Drawing.Color.Blue;
                        functionList.RemoveAt(count);
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
        #endregion
        #region 工具条事件
        /// <summary>
        /// 保存
        /// </summary>
        private void btn_Manage_SaveClick()
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
            deleteMessage = _role.BatchInsertRoleInLeafFunctions(modelList, ddl_RoleName.SelectedValue, FunctionID);
            //wg_FunctionRoleList.DoDataBind();
            btn_Sure.DoClick();
            CPMis.Web.WebClient.ScriptManager.Alert(deleteMessage);
        }
        #endregion
        
    }
}
