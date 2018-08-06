using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.Model.Tb_Maintain.Tb_Maintain_3;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_3
{
    public partial class BooksellerUpdate : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_3.IBooksellerBLL _booksellerBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_3.BooksellerBLL();
        private CPMis.Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel _booksellerModel = new BooksellerModel();
        private CPMis.WebPage.Tb_Maintain.Tb_Maintain_3.BooksellerQuery _booksellerQuery = new BooksellerQuery();
        private CPMis.Common.ToDBC.ToDBC _toDBC = new Common.ToDBC.ToDBC();
        string booksellerId = "";

        /// <summary>
        /// 存储载入页面时的书店名称
        /// </summary>
        string booksellernNameOnLoad
        {
            set { this.ViewState["booksellernNameOnLoad"] = value; }
            get { return ViewState["booksellernNameOnLoad"].ToString(); }

        }


        /// <summary>
        /// 载入页面，调用查询书商信息函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fn_Query();
            }
        }
        /// <summary>
        /// 接收查询页面参数，查询书商信息
        /// </summary>
        protected void Fn_Query()
        {
            if (Request["booksellerID"] != null)
            {
                booksellerId = Request["booksellerID"].ToString();
                _booksellerModel = _booksellerBLL.Fn_BooksellerRetrieveByBooksellerID(booksellerId);
                ctxtBooksellerNum.Text = Convert.ToString(_booksellerModel.BooksellerNum);
                ctxtBooksellerName.Text = _booksellerModel.BooksellerName;
                booksellernNameOnLoad = _booksellerModel.BooksellerName;
                ctxtContact.Text = _booksellerModel.Contact;
                ctxtTelephone.Text = _booksellerModel.Telephone;
            }
        }
        /// <summary>
        /// 更新书商信息的方法
        /// </summary>
        protected void Fn_UpdateBookseller()
        {
            _booksellerModel.BooksellerID = Request["booksellerID"].ToString();
            _booksellerModel.BooksellerName = _toDBC.Fn_ToDBC(ctxtBooksellerName.Text);
            _booksellerModel.Contact = ctxtContact.Text;
            _booksellerModel.Telephone = ctxtTelephone.Text;
            string message = "";
            _booksellerBLL.Fn_BooksellerUpdate(_booksellerModel, ref message);
            CPMis.Web.WebClient.ScriptManager.Alert(message);

            //判断修改是否成功，成功后关闭弹出窗，调用刷新
            if (message == "√ 书商信息修改成功！")
            {
                string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRebind);</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "CloseAndRebind", script);

            }
        }
        /// <summary>
        /// 修改书商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSumbit_Click(object sender, EventArgs e)
        {
            IList<BooksellerModel> modelList = new List<BooksellerModel>();
            modelList = _booksellerBLL.Fn_CheckBooksellerName();                  //获取所有书店名称
            //不修改书店名称，只修改其他信息
            if (booksellernNameOnLoad == _toDBC.Fn_ToDBC(ctxtBooksellerName.Text))
            {

                Fn_UpdateBookseller();
            }
            else
            {

                bool isDeffrent = true;
                foreach (BooksellerModel model in modelList)            //判断数据库里面是否存在同名书店
                {
                    if (model.BooksellerName == _toDBC.Fn_ToDBC(ctxtBooksellerName.Text))
                    {
                        isDeffrent = false;
                        Response.Write("<script>alert('已存在该书店名称，请重新填写书店名称！');</script>");
                    }

                }
                if (isDeffrent)
                {
                    Fn_UpdateBookseller();
                }

            }


        }


        /// <summary>
        /// 取消操作，恢复页面数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Fn_Query();
        }
    }
}