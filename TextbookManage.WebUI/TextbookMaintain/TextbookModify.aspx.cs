using System;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.WebUI.TextbookMaintain
{
    public partial class TextbookModify : CPMis.Web.WebControls.Page
    {
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //跨页面调用传值
                if (!string.IsNullOrWhiteSpace(Request.QueryString["Id"]))
                {
                    var id = Request.QueryString["Id"];
                    ccmbPress.DoDataBind();
                    SetForm(id);
                }
            }
        }

        #region 私有方法

        //取表单教材信息
        private TextbookView GetForm()
        {
            var price = 1.00m;
            decimal.TryParse(ctxtRetailPrice.Text.Trim(), out price);
            return new TextbookView
            {
                TextbookId = clblTextbookId.Text,
                Name = ctxtTextbookName.Text.Trim(),       //教材名称
                Isbn = ctxtISBN.Text.Trim(),              //isbn
                Price = price,        //零售价
                Author = ctxtAuthor.Text.Trim(),    //作者
                PressId = ccmbPress.SelectedValue,
                Press = ccmbPress.Text.Trim(),     //出版社
                PressAddress = ctxtPressAddress.Text.Trim(),//出版社地址
                Edition = ctxtEdition.Text.Trim(),   //版本
                PrintCount = ctxtPrintingCount.Text.Trim(),    //版次
                PageCount = ctxtPage.Text.Trim(),   //页数
                TextbookType = ctxtType.Text.Trim(),   //教材类型
                IsSelfCompile = chkIsSelfCompile.Checked.ToString(),//自编
                PublishDate = (DateTime)ctxtPublishDate.SelectedDate //出版日期
            };
        }

        private void SetForm(string id)
        {

            //取教材
            var view = _impl.GetById(id);

            var isSelf = false;
            bool.TryParse(view.IsSelfCompile, out isSelf);

            //设置教材信息
            clblTextbookId.Text = view.TextbookId;    //教材ID
            ctxtTextbookName.Text = view.Name;       //教材名称
            ctxtISBN.Text = view.Isbn;              //isbn
            ctxtRetailPrice.Text = view.Price.ToString();        //零售价
            ctxtAuthor.Text = view.Author;    //作者
            ccmbPress.SelectedValue = view.PressId;     //出版社
            ctxtPressAddress.Text = view.PressAddress;//出版社地址
            ctxtEdition.Text = view.Edition;   //版本
            ctxtPrintingCount.Text = view.PrintCount;    //版次
            ctxtPage.Text = view.PageCount;   //页数
            ctxtType.Text = view.TextbookType;   //教材类型
            chkIsSelfCompile.Checked = isSelf;//自编
            ctxtPublishDate.SelectedDate = view.PublishDate; //出版日期

        }
        #endregion

        #region 按钮点击

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            //检查是否已验证
            if (IsValid)
            {

                var view = GetForm();
                var result = _impl.Modify(view);
                CPMis.Web.WebClient.ScriptManager.AlertAndClose(result.Message);

            }
        }

        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            //跨页面调用传值
            if (!string.IsNullOrWhiteSpace(Request.QueryString["Id"]))
            {
                var id = Request.QueryString["Id"];
                SetForm(id);
            }
        }

        protected void cbtnSubmit_AfterClick(object sender, EventArgs e)
        {
            CPMis.Web.WebClient.ScriptManager.ExecuteJs("Sys.Application.add_load(CloseAndRebind);");
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

    }
}