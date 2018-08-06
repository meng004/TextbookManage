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

namespace CPMis.WebPage.SystemManageUI.UserManageUI
{
    public partial class TeacherUserUpdate : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IUser _userBLL = new CPMis.BLL.Sys.User();
        private CPMis.IBLL.Sys.IRole _roleBLL = new CPMis.BLL.Sys.Role();
        //private CPMis.IBLL.BaseInfo.IPoliceManBLL _policeBLL = new CPMis.BLL.BaseInfo.PoliceManBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserName = Request.QueryString["UserName"];
                UserName = Server.UrlDecode(UserName);
                SysUserID = Request["SysUserID"];
                ddl_UserLevel.DoDataBind();
                cbl_Role.DoDataBind();
                InitialUserInfo();
            }
        }
        /// <summary>
        /// 系统用户ID
        /// </summary>
        private string SysUserID
        {
            get { return ViewState["SysUserID"] == null ? "" : ViewState["SysUserID"].ToString(); }
            set { ViewState["SysUserID"] = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private new string UserName
        {
            get { return ViewState["UserName"] == null ? "" : ViewState["UserName"].ToString(); }
            set { ViewState["UserName"] = value; }
        }
        /// <summary>
        /// 保存用户原角色
        /// </summary>
        private string PreRoleString
        {
            get { return ViewState["PreRoleString"] == null ? "" : ViewState["PreRoleString"].ToString(); }
            set { ViewState["PreRoleString"] = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        private string UserID
        {
            get { return ViewState["UserID"] == null ? "" : ViewState["UserID"].ToString(); }
            set { ViewState["UserID"] = value; }
        }
        #region 有关dialog
        /// <summary>
        /// 角色CheckBoxList数据源绑定
        /// </summary>
        protected void cbl_Role_BeforeDataBind(object sender, EventArgs e)
        {
            cbl_Role.DataSource = _roleBLL.Retrieve();
        }
        /// <summary>
        /// 添加修改用户
        /// </summary>
        private void InitialUserInfo()
        {
            CPMis.Model.Sys.SystemUsersInfoModel commonUserModel = _userBLL.RetrieveSystemUserInfo(SysUserID);
            txt_Name.Text = commonUserModel.UserTruelyName;
            txt_Institution.Text = commonUserModel.SchoolName;
            txt_Sex.Text = commonUserModel.Sex;
            if (string.IsNullOrEmpty(UserName))//添加用户
            {
                this.Title = "添加用户";
                btn_AddNews.Visible = true;
                btn_Save.Visible = false;
                txt_UserName.ReadOnly = false;
            }
            else                                                       //修改用户
            {
                //CPMis.Model.Sys.SystemUsersInfoModel userModel = _userBLL.GetSystemUserInfo(UserName);
                UserID = commonUserModel.UserID;
                this.Title = "修改用户";
                btn_AddNews.Visible = false;
                btn_Save.Visible = true;
                txt_UserName.ReadOnly = true;
                txt_UserName.Text = commonUserModel.UserName;
                txt_Password.Text = _userBLL.GetUser(txt_UserName.Text.Trim()).GetPassword();
                //txt_Password.TextMode = Telerik.Web.UI.InputMode.Password;
                ddl_UserLevel.SelectedValue = commonUserModel.UserLevelCode;
                var roles = _roleBLL.GetRolesForUser(commonUserModel.UserName);
                cbl_Role.PreOperateString = GetPreOperateString(roles);
                PreRoleString = cbl_Role.PreOperateString;
                string roleIDList = GetPreOperateString(roles);
                cbl_Role.DataBindToControl(roleIDList);
            }
        }
        /// <summary>
        /// 将获取的角色名称数组转化为满足条件的字符串
        /// </summary>
        private string GetPreOperateString(string[] roles)
        {
            string preOperate = "";
            foreach (string role in roles)
            {
                preOperate += role + ",";
            }
            if (roles.Length != 0)
            {
                preOperate = preOperate.Remove(preOperate.Length - 1);
            }
            return preOperate;
        }
        /// <summary>
        /// 点击保存前进行数据保存,要对系统用户表和Membership里面数据进行修改
        /// </summary>
        protected void btn_Save_BeforeClick(object sender, EventArgs e)
        {
            CPMis.Model.Sys.UserModel user = CreateUserModel();
            string message = "";
            message = _userBLL.UpdateUser(user, txt_UserName.Text.Trim(), txt_Password.Text.Trim(), 
                cbl_Role.GetResult(), PreRoleString);
            PreRoleString = cbl_Role.GetResult();
            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }
        /// <summary>
        /// 点击保存后并不关闭dialogwindow,只进行数据显示更新
        /// </summary>
        protected void btn_Save_AfterClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(UpdateAndRebind);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateAndRebind", script); 
        }
        /// <summary>
        /// 点击添加前进行数据保存,要对系统用户表和Membership里面数据进行添加
        /// </summary>
        protected void btn_AddNews_BeforeClick(object sender, EventArgs e)
        {
            CPMis.Model.Sys.UserModel user = CreateUserModel();
            user.ID = Guid.NewGuid();//XTYHID
            user.SysUserID = SysUserID;//YHID(ZGID,XJID)
            string message = _userBLL.InsertUser(user, txt_UserName.Text.Trim(), txt_Password.Text.Trim(), 
                cbl_Role.GetResult());
            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }
        /// <summary>
        /// 点击添加后进行数据显示更新
        /// </summary>
        protected void btn_AddNews_AfterClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(AddAndRebind);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "AddAndRebind", script); 
        }
        /// <summary>
        /// 从页面信息中获取一个UserModel
        /// </summary>
        /// <returns></returns>
        private CPMis.Model.Sys.UserModel CreateUserModel()
        {
            CPMis.Model.Sys.UserModel user = new CPMis.Model.Sys.UserModel();
            user.UserID = UserID;
            user.UserLevel = ddl_UserLevel.SelectedValue.Trim();
            return user;
        }
        #endregion
    }
}
