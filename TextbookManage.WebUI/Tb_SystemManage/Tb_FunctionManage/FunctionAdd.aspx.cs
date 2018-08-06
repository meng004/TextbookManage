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

namespace CPMis.WebPage.SystemManageUI.FunctionManageUI
{
    public partial class FunctionAdd : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IFunction _functionBLL = new CPMis.BLL.Sys.Function();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsUpdate = bool.Parse(Request.QueryString["IsUpdate"]);
                ID = Request.QueryString["ID"];
                SetControlVisible();
            }
        }
        /// <summary>
        /// 是否是更新 更新时为true
        /// </summary>
        private bool IsUpdate
        {
            get { return ViewState["IsUpdate"] == null ? false : bool.Parse(ViewState["IsUpdate"].ToString()); }
            set { ViewState["IsUpdate"] = value; }
        }
        /// <summary>
        /// 标识
        /// </summary>
        private new string ID
        {
            get { return ViewState["ID"] == null ? "" : ViewState["ID"].ToString(); }
            set { ViewState["ID"] = value; }
        }
        /// <summary>
        /// 设置按钮显示状态
        /// </summary>
        private void SetControlVisible()
        {
            if (IsUpdate)
            {
                btn_Add.Visible = false;
                btn_Save.Visible = true;
                this.Title = "编辑功能";

                CPMis.Model.Sys.FunctionModel functionModel = _functionBLL.Retrieve(ID);
                txt_FunctionID.Text = functionModel.FunctionID;
                txt_FunctionName.Text = functionModel.FunctionName.ToString();
                txt_FunctionURL.Text = functionModel.FunctionURL;
            }
            else
            {
                btn_Add.Visible = true;
                btn_Save.Visible = false;
                this.Title = "添加功能";
            }
        }

        #region 有关添加/编辑dialog
        /// <summary>
        /// DialogWindow添加按钮添加(更新)事件
        /// </summary>
        protected void btn_Add_BeforeClick(object sender, EventArgs e)
        {
            string FunctionID = txt_FunctionID.Text.Trim();
            string FunctionName = txt_FunctionName.Text.Trim();
            string FunctionURL = txt_FunctionURL.Text.Trim();
            if (FunctionID.Length.Equals(0))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("功能编号不能为空");
                return;
            }
            else if(!FunctionID.Length.Equals(8))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("功能编号请填写8位数字");
                return;
            }   
            if (FunctionName.Length.Equals(0))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("功能名称不能为空");
                return;
            }
            CPMis.Model.Sys.FunctionModel functionModel = new CPMis.Model.Sys.FunctionModel();
            functionModel.ID = Guid.NewGuid();
            functionModel.FunctionID = FunctionID;
            functionModel.FunctionName = FunctionName;
            functionModel.FunctionURL = FunctionURL;
            string message = "";
            if (_functionBLL.Insert(functionModel, ref message))
            {
                txt_FunctionID.Text = "";
                txt_FunctionName.Text = "";
                txt_FunctionURL.Text = "";
            }
            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        protected void btn_Save_BeforeClick(object sender, EventArgs e)
        {
            string FunctionID = txt_FunctionID.Text.Trim();
            string FunctionName = txt_FunctionName.Text.Trim();
            string FunctionURL = txt_FunctionURL.Text.Trim();
            if (FunctionID.Length.Equals(0))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("功能编号不能为空");
                return;
            }
            if (FunctionName.Length.Equals(0))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("功能名称不能为空");
                return;
            }
            CPMis.Model.Sys.FunctionModel functionModel = new CPMis.Model.Sys.FunctionModel();
            functionModel.ID = new Guid(ID);
            functionModel.FunctionID = FunctionID;
            functionModel.FunctionName = FunctionName;
            functionModel.FunctionURL = FunctionURL;
            string message = "";
            _functionBLL.Update(functionModel, ref message);
            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }
        /// <summary>
        /// 添加点击事件后
        /// </summary>
        protected void btn_Add_AfterClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(AddAndRebind);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "AddAndRebind", script); 
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        protected void btn_Save_AfterClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(UpdateAndRebind);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateAndRebind", script); 
        }
        #endregion
    }
}
