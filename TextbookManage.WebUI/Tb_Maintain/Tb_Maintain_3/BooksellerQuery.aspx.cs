using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_3;
using CPMis.Model.Tb_Maintain.Tb_Maintain_3;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_3
{
    public partial class BooksellerQuery : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_3.IBooksellerBLL _booksellerBLL = new BLL.Tb_Maintain.Tb_Maintain_3.BooksellerBLL();
        /// <summary>
        /// 初始化绑定书商列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BooksellerNameDataBind();
            }
            cgrdbooksellerQuery.DoDataBind();
        }
        /// <summary>
        /// 绑定下拉列表方法
        /// </summary>
        protected void BooksellerNameDataBind()
        {
            IList<BooksellerModel> modelList = new List<BooksellerModel>();
            BooksellerModel model = new BooksellerModel();
            model.BooksellerName = "---请选择---";
            modelList.Add(model);
            foreach (BooksellerModel model1 in _booksellerBLL.Fn_CheckBooksellerName())
            {
                modelList.Add(model1);
            }
            ctxtBooksellerName.DataSource = modelList;
            ctxtBooksellerName.DataTextField = "BooksellerName";
            ctxtBooksellerName.DataBind();


        }
        /// <summary>
        /// 点击查询绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbntQuery_Click(object sender, EventArgs e)
        {
            cgrdbooksellerQuery.DoDataBind();
        }


        #region 修改书商信息后刷新grid和下拉列表...
        /// <summary>
        /// 异步刷新Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {

                default:
                    BooksellerNameDataBind();
                    cgrdbooksellerQuery.DoDataBind();
                    break;
            }
        }
        #endregion
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdbooksellerQuery_BeforeDataBind(object sender, EventArgs e)
        {
            cgrdbooksellerQuery.DataSource = _booksellerBLL.Fn_Retrieve(ctxtBooksellerName.SelectedValue);     //调用查询函数

        }
        /// <summary>
        /// 执行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string booksellerID = ((LinkButton)sender).CommandArgument;
            ///执行带有参数的删除功能
            string message = "";
            _booksellerBLL.Fn_BooksellerDelete(booksellerID, ref message);
            if (message != "√ 书商信息删除成功！")
            {
                message = "系统中其他表正在使用该记录，暂时无法删除！";
                CPMis.Web.WebClient.ScriptManager.Alert(message);
            }
            else
                CPMis.Web.WebClient.ScriptManager.AlertAndRedirect(message, "BooksellerQuery.aspx");     //删除书商信息后，刷新页面                
            
        }
    }  
}