using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;

namespace USCTAMis.WebPage
{
    public partial class NewsList : USCTAMis.Web.WebControls.Page
    {
        #region 变量
        IBLL.Sys.IInfoView _infoView = new BLL.Sys.InfoView();

        #endregion
        /// <summary>
        /// 加载页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            IsAnony = true;
            btn_Login1.Attributes.Add("onmouseover", "this.src='Img/HomeLogButtonOver.gif'");
            btn_Login1.Attributes.Add("onmouseout ", "this.src='Img/HomeLogButton.gif'");
            AddLinkButtonForDynamic();
            if (!IsPostBack)
            {
                wg_NewsDataBind(); 
            }
        }

        #region 系统事件
        protected void lnk_StudentList_Click(object sender, EventArgs e)
        {
            PagePath = "StudentList.aspx";
            SetPageParameter<string>("1");
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 700, 1000);
        }

        protected void lnk_TableDown_Click(object sender, EventArgs e)
        {
            PagePath = "TableDownLoad.aspx";
            SetPageParameter<string>("1");
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 700, 1000);
        }

        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_AfterClick(object sender, EventArgs e)
        {
            Common.SimpleDictionary para = new USCTAMis.Common.SimpleDictionary(1);
            para.Add(Common.ParameterList.Sys.NewsRelease.NewsTitle, txt_News.Text);
            wg_News.DataSource = _infoView.Retrieve(para);
            wg_News.DoDataBind();
        }

        /// <summary>
        /// 点击标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wg_News_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string name = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (name == "ScanCommand")
            {
                ScanCommand(sender, e);
            }
        }

        /// <summary>
        /// 更多的所有新闻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lb_MoreNews_AfterClick(object sender, EventArgs e)
        {
            PagePath = "NewsList.aspx";
            SetPageParameter<string>("1");
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 650, 850);
        }

        /// <summary>
        /// 更多的教务新闻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lb_MoreTeachingNews_AfterClick(object sender, EventArgs e)
        {
            PagePath = "NewsList.aspx";
            SetPageParameter<string>("0");
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 650, 850);
        }

        /// <summary>
        /// 登陆按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Login_AfterClick(object sender, EventArgs e)
        {
            try
            {
                //USCTAMis.Web.WebClient.ScriptManager.Alert("将要跳转！");
                Response.Redirect("~/USCTAMisLogin.aspx");
            }
            catch (Exception ex)
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert(ex.Message.ToString());
            }
        }

        #endregion

        #region 自定义方法

        /// <summary>
        /// 新闻列表绑定
        /// </summary>
        private void wg_NewsDataBind()
        {
            wg_News.DataSource = _infoView.RetrievePreTwenty();
            wg_News.DataBind();
        }

        /// <summary>
        /// 动态显示教务新闻
        /// </summary>
        protected void AddLinkButtonForDynamic()
        {
            IList<Model.Sys.NewsModel> TeachingNews = _infoView.RetrievePreFiveTeachingNews();
            for (int startNews = 0; startNews < TeachingNews.Count; startNews++)
            {
                USCTAMis.Web.WebControls.UTMisLinkButton TeachingNewsLink = new USCTAMis.Web.WebControls.UTMisLinkButton();
                TeachingNewsLink.Text = TeachingNews[startNews].NewsTitle;
                TeachingNewsLink.ID = TeachingNews[startNews].NewsID;
                TeachingNewsLink.AfterClick += new EventHandler(TeachingNewsLink_AfterClick);
                this.Teaching.Controls.Add(TeachingNewsLink);
                this.Teaching.Controls.Add(new LiteralControl(" <br/><br/> "));
            }
        }

        /// <summary>
        /// 点击滚动的标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TeachingNewsLink_AfterClick(object sender, EventArgs e)
        {
            USCTAMis.Web.WebControls.UTMisLinkButton clickLink = sender as
            USCTAMis.Web.WebControls.UTMisLinkButton;
            PagePath = "NewsView.aspx";
            SetPageParameter<string>(clickLink.ID.ToString());
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 650, 850);
        }

        #endregion

        /// <summary>
        /// 查看新闻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ScanCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            Model.Sys.NewsModel model = new USCTAMis.Model.Sys.NewsModel();
            model = wg_News.GetData<Model.Sys.NewsModel>(e.Item.ItemIndex);
            string NewslID = model.NewsID;
            PagePath = "NewsView.aspx";
            SetPageParameter<string>(NewslID);
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(PathBuilder, 650, 850);
        }
    }
}