using System;
using CPMis.Web.WebControls;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class TextbookDetailMessage : Page
    {
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置控件属性
                foreach (var item in pv_Textbook.Controls)
                {
                    if (item is CPMisTextBox)
                    {
                        var ctl = item as CPMisTextBox;
                        ctl.Enabled = false;
                    }
                }
                //跨页面调用传值
                if (!string.IsNullOrWhiteSpace(Request.QueryString["TextbookID"]))
                {
                    var id = Request.QueryString["TextbookID"];
                    SetForm(id);
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 设置表单信息
        /// </summary>
        /// <param name="id">教材ID</param>
        private void SetForm(string id)
        {

            //取教材
            var view = _impl.GetById(id);

            //设置教材信息
            clblTextbookId.Text = view.TextbookId;    //教材ID
            ctxtTextbookNum.Text = view.Num;          //教材编号
            ctxtTextbookName.Text = view.Name;       //教材名称
            ctxtISBN.Text = view.Isbn;              //isbn
            ctxtRetailPrice.Text = view.Price.ToString();        //零售价
            ctxtAuthor.Text = view.Author;    //作者
            ctxtPress.Text = view.Press;     //出版社
            ctxtPressAddress.Text = view.PressAddress;//出版社地址
            ctxtEdition.Text = view.Edition;   //版本
            ctxtPrintingCount.Text = view.PrintCount;    //版次
            ctxtPage.Text = view.PageCount;   //页数
            ctxtType.Text = view.TextbookType;   //教材类型
            ctxtIsSelfCompile.Text = view.IsSelfCompile;//自编
            ctxtPublishDate.Text = view.PublishDate.ToLongDateString(); //出版日期

        }
        #endregion

    }
}