using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_3;
using CPMis.Common.ToDBC;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_3
{
    public partial class BooksellerAdd : System.Web.UI.Page
    {
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_3.IBooksellerBLL _booksellerBLL = new BLL.Tb_Maintain.Tb_Maintain_3.BooksellerBLL();
        private CPMis.Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel _booksellerModel = new Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel();
        private CPMis.Common.ToDBC.ToDBC _toDBC = new ToDBC();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbtnSumbit_Click(object sender, EventArgs e)
        {
            _booksellerModel.BooksellerName = _toDBC.Fn_ToDBC(ctxtBooksellerName.Text);  //将不含有全角字符的书商名称传给model
            _booksellerModel.Contact = ctxtContact.Text;        //传联系人给model
            _booksellerModel.Telephone = ctxtTelephone.Text;    //传联系电话给model

            ///执行带有参数的添加功能
            string message = "";
            _booksellerBLL.Fn_BooksellerAdd(_booksellerModel, ref message);
            CPMis.Web.WebClient.ScriptManager.Alert(message);
            //修改人：程爱爽
            //修改时间：8月17日
            //解决问题：提交数据后清空文本框
            if (message.StartsWith("√"))
            {
                ctxtBooksellerName.Text="";  
                ctxtContact.Text="";        
                ctxtTelephone.Text="";    
            }
        }

        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            //点击取消刷新自己
            Response.Redirect("BooksellerAdd.aspx");
        }
    }
}