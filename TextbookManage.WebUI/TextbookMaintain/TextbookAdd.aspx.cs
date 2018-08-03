using System;
using System.Web;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

//添加引用



namespace TextbookManage.WebUI.TextbookMaintain
{
    public partial class TextbookAdd : CPMis.Web.WebControls.Page
    {

        private readonly string _loginName = HttpContext.Current.User.Identity.Name;
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();
        //private readonly string _loginName = "46010";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearForm();
                ccmbPress.DoDataBind();
            }
        }

        #region 私有方法

        /// <summary>
        /// 清空表单的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearForm()
        {
            ctxtTextbookName.Text = "";       //教材名称
            ctxtISBN.Text = "";              //isbn
            ctxtRetailPrice.Text = "1.00";        //零售价
            ctxtAuthor.Text = "";    //作者
            ccmbPress.SelectedIndex = 0;     //出版社
            ctxtPressAddress.Text = "北京";//出版社地址
            ctxtEdition.Text = "1";     //版本
            ctxtPrintingCount.Text = "1";    //版次
            ctxtPage.Text = "1";   //页数
            ctxtType.Text = "";   //教材类型
            chkIsSelfCompile.Checked = false;//清空自编
            ctxtPublishDate.SelectedDate = DateTime.Now;
        }

        /// <summary>
        /// 提取表单信息
        /// </summary>
        /// <returns></returns>
        private TextbookView GetForm()
        {
            var price = 1.00m;
            decimal.TryParse(ctxtRetailPrice.Text.Trim(), out price);

            return new TextbookView
            {
                Name = ctxtTextbookName.Text,       //教材名称
                Isbn = ctxtISBN.Text,              //isbn
                Price = price,        //零售价
                Author = ctxtAuthor.Text,    //作者
                PressId = ccmbPress.SelectedValue,
                Press = ccmbPress.Text,     //出版社
                PressAddress = ctxtPressAddress.Text,//出版社地址
                Edition = ctxtEdition.Text,   //版本
                PrintCount = ctxtPrintingCount.Text,    //版次
                PageCount = ctxtPage.Text,   //页数
                TextbookType = ctxtType.Text,   //教材类型
                IsSelfCompile = chkIsSelfCompile.Checked.ToString(),//自编
                PublishDate = (DateTime)ctxtPublishDate.SelectedDate//出版日期
            };
        }
        #endregion

        #region 出版社

        protected void ccmbPress_BeforeDataBind(object sender, EventArgs e)
        {

            ccmbPress.DataSource = _impl.GetPresses();

        }

        protected void ccmbPress_AfterDataBind(object sender, EventArgs e)
        {
            var press = ccmbPress.GetData<PressView>();
            ctxtPressAddress.Text = press.Address;
        }

        protected void ccmbPress_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            var press = ccmbPress.GetData<PressView>();
            ctxtPressAddress.Text = press.Address;
        }
        #endregion

        #region 按钮点击

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                TextbookView view = GetForm();
                var result = _impl.Add(view, _loginName);
                CPMis.Web.WebClient.ScriptManager.AlertAndClose(result.Message);

            }
        }

        /// <summary>
        /// 点击后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_AfterClick(object sender, EventArgs e)
        {
            CPMis.Web.WebClient.ScriptManager.ExecuteJs("Sys.Application.add_load(CloseAndRebind);");
        }
        #endregion




    }
}