using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.Application.Factory;
using TextbookManage.Application.Interface;
using TextbookManage.Application.ViewModel;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class TextbookDetailMessage : USCTAMis.Web.WebControls.Page
    {
        readonly ITextbook _declaration = new PopWindowFactory().CreateTextbookApplication();

        //页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查传入参数
            if (!string.IsNullOrWhiteSpace(Request.QueryString["TextbookID"]))
            {
                string textbookID = Request.QueryString["TextbookID"];

                //获取对应教材ID的教材
                TextbookView textbookDetail = _declaration.GetTextbookById(textbookID);
                //显示教材详细信息
                SetTextbookInfo(textbookDetail);
            }
        }

        /// <summary>
        /// 设置教材详细信息
        /// </summary>
        private void SetTextbookInfo(TextbookView textbook)
        {
            ctxtTextbookName.Text = textbook.TextbookName;
            ctxtTextbookNum.Text = textbook.TextbookNum;
            ctxtISBN.Text = textbook.Isbn;
            ctxtAuthor.Text = textbook.Author;
            ctxtPress.Text = textbook.Press;
            ctxtEdition.Text = textbook.Edition;
            ctxtPrintCount.Text = textbook.PrintCount;
            ctxtPrice.Text = textbook.Price;
            ctxtType.Text = textbook.TextbookType;
        }
    }
}