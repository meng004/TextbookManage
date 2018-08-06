using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.SystemManageUI.UserManageUI
{
    public partial class UserNamePasswordUpdate : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IUser _userBLL = new CPMis.BLL.Sys.User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_OldName.Text = HttpContext.Current.User.Identity.Name;
            }
        }

        #region 密码修改
        protected void btn_SaveName_Click(object sender, EventArgs e)
        {
            if (txt_NewName.Text.Trim() == "")
            {
                CPMis.Web.WebClient.ScriptManager.Alert("用户名不能为空!");
                return;
            }
            string message = string.Empty;
            bool isSuccess = _userBLL.UpdateUserName(txt_OldName.Text.Trim(), txt_NewName.Text.Trim(), ref message);
            if (isSuccess)
            {
                CPMis.Web.WebClient.ScriptManager.Alert(message + ",请重新登录!");
            }
            else
            {
                CPMis.Web.WebClient.ScriptManager.Alert(message);
            }
        }

        protected void btn_SavePass_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userBLL.GetPassword() != txt_OldPass.Text.Trim())
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("原密码错误!");
                    return;
                }
                if (txt_NewPass.Text.Trim() == "")
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("密码不能为空!");
                    return;
                }
                if (_userBLL.ChangePassword(txt_OldPass.Text.Trim(), txt_NewPass.Text.Trim()))
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("密码更新成功!");
                }
                else
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("密码更新失败!");
                }
            }
            catch (Exception er)
            {
                CPMis.Web.WebClient.ScriptManager.Alert(er.Message);
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_OldPass.Text = "";
            txt_NewPass.Text = "";
            txt_CheckPass.Text = "";
        }
        #endregion
    }
}