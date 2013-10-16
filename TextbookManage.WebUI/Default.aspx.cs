using System;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace USCTAMis.WebPage
{
    public partial class Default : USCTAMis.Web.WebControls.Page
    {
        private USCTAMis.IBLL.Sys.INewsManage _newsManageBLL = new USCTAMis.BLL.Sys.NewsManage();
        private USCTAMis.IBLL.Sys.IHaveSentEmail _noReadMailList = new BLL.Sys.HaveSentEmail();
        private USCTAMis.IBLL.Sys.IMailReceiveList _signEmail = new BLL.Sys.MailReceiveList();
        private USCTAMis.IBLL.Sys.IUser _userBLL = new USCTAMis.BLL.Sys.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_News.DoDataBind();
                wd_MailList.DoDataBind();
                txt_OldName.Text = HttpContext.Current.User.Identity.Name;
                if (wd_MailList.MasterTableView.Items.Count >= 1)
                    USCTAMis.Web.WebClient.ScriptManager.Alert("您有好友给你的重要新邮件，请赶快查收哦！^-^");              
            }
        }

        #region 私有属性

        private string TeacherID
        {
            get
            {
                USCTAMis.Web.WebClient.ProfileManger profile = new USCTAMis.Web.WebClient.ProfileManger(
                    HttpContext.Current.User.Identity.Name);
                return profile.UserAccountID;
            }
        }
        private string UserLevel
        {
            get
            {
                USCTAMis.Web.WebClient.ProfileManger profile = new USCTAMis.Web.WebClient.ProfileManger(
                    HttpContext.Current.User.Identity.Name);
                return profile.UserLevel;
            }
        }
        #endregion

        #region 新闻
        protected void wg_News_BeforeDataBind(object sender, EventArgs e)
        {
            wg_News.DataSource = _newsManageBLL.GetTeacherLoginNews(TeacherID);
        }

        protected void wg_News_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string name = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (name == "ViewNews")
            {
                Model.Sys.NewsModel model = new USCTAMis.Model.Sys.NewsModel();
                model = wg_News.GetData<Model.Sys.NewsModel>(e.Item.ItemIndex);
                string NewslID = model.NewsID;
                PagePath = "NewsView.aspx";
                SetPageParameter<string>(NewslID);
                USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 650, 850);
            }
        }

        #endregion

        #region 收信箱
        /// <summary>
        /// 收件箱的绑定的数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wd_MailList_BeforeDataBind(object sender, EventArgs e)
        {
            wd_MailList.DataSource = _noReadMailList.GetNoReadSelectEmail(TeacherID);
        }

        /// <summary>
        /// 点击标题
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wd_MailList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string name = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (name == "ViewEmail")
            {
                string message = "";
                Model.Sys.EmailModel model = wd_MailList.GetData<Model.Sys.EmailModel>(e.Item.ItemIndex);
                string emailID = model.EmailID;
                //如果已经签收，则不更新签收时间
                if (model.EmailReveivedTag == "0")
                {
                    if (_signEmail.SignOffEmail(emailID, TeacherID, ref message))
                    {
                    }
                    else
                    {
                        USCTAMis.Web.WebClient.ScriptManager.Alert("签收失败，请重新点击查看！");
                    }
                }
                //传值
                PagePath = "InfoManageUI/MailManageUI/MailView.aspx";
                SetPageParameter(emailID, "EmailID");
                SetPageParameter("0", "Flag");//标识这是从收信箱中连接过去的
                USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 650, 850);
                wd_MailList.DoDataBind();
            }
        }

        #endregion

        #region 密码修改
        protected void btn_SaveName_Click(object sender, EventArgs e)
        {
            if (txt_NewName.Text.Trim() == "")
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("用户名不能为空!");
                return;
            }
            string message = string.Empty;
            bool isSuccess = _userBLL.UpdateUserName(txt_OldName.Text.Trim(), txt_NewName.Text.Trim(), ref message);
            if (isSuccess)
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert(message + ",请重新登录!");
            }
            else
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert(message);
            }
        }

        protected void btn_SavePass_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userBLL.GetPassword() != txt_OldPass.Text.Trim())
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert("原密码错误!");
                    return; 
                }
                if (txt_NewPass.Text.Trim() == "")
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert("密码不能为空!");
                    return;
                }
                if (_userBLL.ChangePassword(txt_OldPass.Text.Trim(), txt_NewPass.Text.Trim()))
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert("密码更新成功!");
                }
                else
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert("密码更新失败!");
                }
            }
            catch (Exception er)
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert(er.Message);
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