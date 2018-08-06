using System;
using System.Web;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

//添加引用



namespace TextbookManage.WebUI.Tb_Maintain.Tb_Maintain_1
{
    public partial class TextbookAdd : CPMis.Web.WebControls.Page
    {
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();
        //private readonly string _loginName = "46010";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //取教材ID
                TextbookId = Request.QueryString["Id"];
                TextbookId = Server.UrlDecode(TextbookId);
                //绑定数据
                BindTextbookData();
            }
        }

        #region 私有方法

        /// <summary>
        /// 教材ID
        /// </summary>
        private string TextbookId
        {
            get => ViewState["TextbookId"].ToString();
            set => ViewState["TextbookId"] = value;
        }

        /// <summary>
        /// 是否为编辑
        /// </summary>
        private bool IsModify => !string.IsNullOrWhiteSpace(TextbookId);
        /// <summary>
        /// 教材ID是否为空
        /// </summary>
        private bool IsNotNull => !string.IsNullOrWhiteSpace(TextbookId);
        /// <summary>
        /// 教材ID是否等于空GUID
        /// </summary>
        private bool IsNotEmpty => !string.Equals(TextbookId, Guid.Empty.ToString());

        /// <summary>
        /// 清空表单的信息
        /// </summary>
        private void ResetForm()
        {
            TextbookId = Guid.Empty.ToString();

            ctxtTextbookName.Text = string.Empty;       //教材名称
            ctxtISBN.Text = string.Empty;              //isbn
            ctxtRetailPrice.Text = "1.00";        //零售价
            ctxtAuthor.Text = string.Empty;    //作者
            ctxtPress.Text = string.Empty;     //出版社
            ctxtPressAddress.Text = "北京";//出版社地址
            ctxtEdition.Text = "1";     //版本
            ctxtPrintingCount.Text = "1";    //版次
            ctxtPage.Text = "0";   //页数
            ctxtType.Text = string.Empty;   //教材类型
            chkIsSelfCompile.Checked = false;//清空自编
            ctxtPublishDate.SelectedDate = DateTime.Now;
        }

        private void SetForm(TextbookView book)
        {
            if (object.Equals(book, null)) return;

            TextbookId = book.TextbookId;

            ctxtTextbookName.Text = book.Name;       //教材名称
            ctxtISBN.Text = book.Isbn;              //isbn
            ctxtRetailPrice.Text = book.Price;        //零售价
            ctxtAuthor.Text = book.Author;    //作者
            ctxtPress.Text = book.Press;     //出版社
            ctxtPressAddress.Text = "北京";//出版社地址
            ctxtEdition.Text = book.Edition;     //版本
            ctxtPrintingCount.Text = book.PrintCount;    //版次
            ctxtPage.Text = "1";   //页数
            ctxtType.Text = book.TextbookType;   //教材类型
            chkIsSelfCompile.Checked = book.IsSelfCompile; //是否自编教材
            ctxtPublishDate.SelectedDate = DateTime.Now; //出版日期
        }

        /// <summary>
        /// 提取表单信息
        /// </summary>
        /// <returns></returns>
        private TextbookView GetForm()
        {

            return new TextbookView
            {
                TextbookId = TextbookId,
                Name = ctxtTextbookName.Text.Trim(),       //教材名称
                Isbn = ctxtISBN.Text.Trim(),              //isbn
                Price = ctxtRetailPrice.Text.Trim(),        //零售价
                Author = ctxtAuthor.Text.Trim(),    //作者
                //PressId = ccmbPress.SelectedValue,
                Press = ctxtPress.Text.Trim(),     //出版社
                //PressAddress = ctxtPressAddress.Text.Trim(),//出版社地址
                Edition = ctxtEdition.Text.Trim(),   //版本
                PrintCount = ctxtPrintingCount.Text.Trim(),    //版次
                PageCount = ctxtPage.Text.Trim(),   //页数
                TextbookType = ctxtType.Text.Trim(),   //教材类型
                IsSelfCompile = chkIsSelfCompile.Checked,//自编
                PublishDate = ctxtPublishDate.SelectedDate.ToString()  //出版日期
            };
        }

        private void BindTextbookData()
        {
            //检查id
 
            //存在，加载数据
            if (IsModify && IsNotEmpty && IsNotNull)
            {
                var data = _impl.GetById(TextbookId);
                SetForm(data);
            }
            else  //不存在，重置表单
            {
                ResetForm();
            }
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
            ResetForm();
        }

        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            //输入数据验证状态
            if (!IsValid) return;
            //取输入
            var view = GetForm();
            //依据是否编辑，完成编辑或新增
            ResponseView result;

            if (IsModify && IsNotNull && IsNotEmpty)
            {
                result = _impl.Modify(view);
            }
            else 
            {
                result = _impl.Add(view);
            }
            //显示结果信息
            CPMis.Web.WebClient.ScriptManager.AlertAndClose(result.Message);
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