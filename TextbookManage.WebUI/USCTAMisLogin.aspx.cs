using System;
using System.Linq;
using USCTAMis.Web.WebClient;


namespace USCTAMis.WebPage
{
    public partial class USCTAMisLogin : System.Web.UI.Page
    {


        protected void Login_LoggedIn(object sender, EventArgs e)
        {
            //ProfileManger CurrentUserProfile = new ProfileManger(Login.UserName.Trim());

            ProfileManger CurrentUserProfile = new ProfileManger("nhu_lemon");
            CurrentUserProfile.SetUserProfile();

            Response.Write(CurrentUserProfile.UserLevel);
            if (CurrentUserProfile.UserLevel == USCTAMis.Common.UserInfo.StudentLevel)
            {
                Login.DestinationPageUrl = "StudentMain.aspx";
            }
            else
            {
                Login.DestinationPageUrl = "Main.aspx";
            }
        }

        protected void Login_LoginError(object sender, EventArgs e)
        {
            USCTAMis.Web.WebClient.ScriptManager.Alert("您输入的用户名和密码不正确！");
        }



    }
}