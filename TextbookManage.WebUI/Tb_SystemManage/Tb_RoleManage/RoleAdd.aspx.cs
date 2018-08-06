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
    public partial class RoleAdd : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IRole _role = new CPMis.BLL.Sys.Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsUpdate = bool.Parse(Request.QueryString["IsUpdate"]);
                OldRoleName = Request.QueryString["OldRoleName"];
                OldRoleName = Server.UrlDecode(OldRoleName);
                SetControlVisible();
            }
        }
        /// <summary>
        /// 是否是更新 更新时为true
        /// </summary>
        private bool IsUpdate
        {
            get => ViewState["IsUpdate"] != null && bool.Parse(ViewState["IsUpdate"].ToString());
            set => ViewState["IsUpdate"] = value;
        }
        /// <summary>
        /// 旧的角色名称
        /// </summary>
        private string OldRoleName
        {
            get => ViewState["OldRoleName"] == null ? "" : ViewState["OldRoleName"].ToString();
            set => ViewState["OldRoleName"] = value;
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
                this.Title = "编辑角色";

                txt_RoleName.Text = OldRoleName;
            }
            else
            {
                btn_Add.Visible = true;
                btn_Save.Visible = false;
                this.Title = "添加角色";
            }
        }
        #region 添加/编辑dialog
        /// <summary>
        /// 添加前
        /// </summary>
        protected void btn_Add_BeforeClick(object sender, EventArgs e)
        {
            string roleName = txt_RoleName.Text.Trim();
            if (roleName.Length.Equals(0))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("角色名不能为空");
                return;
            }
            //string message = "";
            try
            {
                _role.CreateRole(roleName);
                CPMis.Web.WebClient.ScriptManager.Alert("添加角色成功!");
            }
            catch (Exception er)
            {
                CPMis.Web.WebClient.ScriptManager.Alert(er.Message);
            }
        }
        /// <summary>
        /// 添加后
        /// </summary>
        protected void btn_Add_AfterClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRebind);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseAndRebind", script); 
        }
        /// <summary>
        /// 保存前
        /// </summary>
        protected void btn_Save_BeforeClick(object sender, EventArgs e)
        {
            string roleName = txt_RoleName.Text.Trim();
            if (roleName.Length.Equals(0))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("角色名不能为空");
                return;
            }
            string message = "";
            _role.UpdateRole(OldRoleName, roleName, ref message);
            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }
        /// <summary>
        /// 保存后
        /// </summary>
        protected void btn_Save_AfterClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRebind);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseAndRebind", script); 
        }
        #endregion
    }
}
