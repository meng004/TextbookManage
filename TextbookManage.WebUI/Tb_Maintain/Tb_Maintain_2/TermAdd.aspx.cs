using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_2;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_2;
using CPMis.Model.Tb_Maintain.Tb_Maintain_2;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_2
{
    public partial class TermAdd : System.Web.UI.Page
    {
        private CPMis.Model.Tb_Maintain.Tb_Maintain_2.TermModel _termAddModel = new Model.Tb_Maintain.Tb_Maintain_2.TermModel();//new Model
        private ITermBLL _termAddBLL = new TermBLL();//new BLL

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 新增按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnAdd_Click(object sender, EventArgs e)
        {            
            if (_termAddBLL.Fn_CheckIsExistTerm(ctxtTerm.Text) != null)
            {
                Response.Write("<script>alert('已经存在该学年学期!');</script>");//弹出窗口提醒用户该学年学期已经存在
                //CPMis.Web.WebClient.ScriptManager.Alert("已经存在该学年学期!");//弹出窗口提醒用户该学年学期已经存在
            }
            else
            {
                _termAddModel.Term = ctxtTerm.Text;//获取页面Term文本框的内容
                _termAddModel.IsCurrentTerm = Convert.ToInt16(chkIsCurrentTerm.Checked).ToString();//获取是否为当前学期复选框的内容
                _termAddModel.BeginDate = cdateBeginDate.SelectedDate.ToString();//开始日期
                _termAddModel.EndDate = cdateEndDate.SelectedDate.ToString();//结束日期

                string message = "";//底层数据库的消息
                _termAddBLL.Fn_TermInsert(_termAddModel, ref message);//调用BLL层的Fn_TermInsert方法
                CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户插入是否成功                           
            }
            //}
        }

        /// <summary>
        /// 取消按钮的事件,刷新本页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TermAdd.aspx");//刷新本页面
        }
    }
}