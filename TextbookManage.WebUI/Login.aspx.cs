using System;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Web.UI;
//using TextbookManage.WebUI.CasMapperService;
using CPMis.Web.WebClient;

namespace CPMis.WebPage
{
    public partial class Login : Page//USCTAMis.Web.WebControls.Page
    {
        private readonly CPMis.IBLL.Sys.IUser logUser = new CPMis.BLL.Sys.User();

        //cas认证服务地址
        //private const string CASHOST = "https://ecamp-sso.usc.edu.cn:443/cas/";
        private const string url = "casLoginURL";
        private readonly string CASHOST = ConfigurationManager.AppSettings[url];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validate();
            }
        }



        //protected void bt_Login_Click(object sender, EventArgs e)
        //{
        //    //if (!logUser.ValidateUser(txt_UserName.Text.Trim(), txt_Password.Text.Trim()))
        //    //{
        //    //    USCTAMis.Web.WebClient.ScriptManager.Alert("您输入的用户名或密码不正确！");
        //    //    return;
        //    //}
        //    Redirect(txt_UserName.Text.Trim());
        //}

        /// <summary>
        /// 单点登录验证
        /// </summary>
        //private void Validate()
        //{

        //    CasClientValidate.CasClientValidateImpl casClient = new CasClientValidate.CasClientValidateImpl(Request, Response, CASHOST);
        //    var casNetId = casClient.Authenticate();
        //    if (string.IsNullOrWhiteSpace(casNetId))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        //是否与cas存在匹配关系
        //        var username = GetUserName(casNetId);
        //        //存在匹配关系
        //        if (!string.IsNullOrWhiteSpace(username))
        //        {
        //            //页面跳转
        //            Redirect(username);
        //        }
        //        else    //不存在，使用教务登录
        //        {
        //            Response.Redirect("UscTamisLogin.aspx");
        //            return;
        //        }
        //    }
        //}

        /// <summary>
        /// 根据用户名重定向功能页面
        /// </summary>
        /// <param name="userName"></param>
        private void Redirect(string userName)
        {
            //检查是否存在用户名
            if (string.IsNullOrWhiteSpace(userName))
            {
                Response.Write("没有对应的用户");
                return;
            }

            //创建用户配置文件
            ProfileManger currentUserProfile = new CPMis.Web.WebClient.ProfileManger(userName);
            //currentUserProfile.SetUserProfile();
            //创建授权证书
            System.Web.Security.FormsAuthentication.SetAuthCookie(userName, true);

            //由其他页面跳转过来
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                return;
            }

            Response.Redirect("~/Main.aspx");
        }

        /// <summary>
        /// 根据数字身份证号，找用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //private string GetUserName(string userId)
        //{
        //    using (CasMapperApplClient client = new CasMapperApplClient())
        //    {
        //        var username = client.GetUsernameByCasNetId(userId);
        //        return username;
        //    }
        //}
        protected void LoginCPMis_OnLoggedIn(object sender, EventArgs e)
        {
            ProfileManger CurrentUserProfile = new ProfileManger(LoginCPMis.UserName.Trim());
            CurrentUserProfile.SetUserProfile();
            //此处可设置登录成功后跳转的页面
            //Login1.DestinationPageUrl = "Tb_SystemManage/Tb_UserManage/SystemUserManage.aspx";
            LoginCPMis.DestinationPageUrl = "Main.aspx";
        }

        protected void LoginCPMis_OnLoginError(object sender, EventArgs e)
        {
            LoginCPMis.FindControl("UserName").Focus();
            if (LoginCPMis.UserName.Trim() != "")
                LoginCPMis.FindControl("Password").Focus();
            CPMis.Web.WebClient.ScriptManager.Alert("用户名或密码不正确");
        }
    }
}