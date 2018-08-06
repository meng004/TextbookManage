using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.Model.Tb_Maintain.Tb_Maintain_2;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_2;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_2;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_2
{
    public partial class TermDelete : System.Web.UI.Page
    {
        private ITermBLL termBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_2.TermBLL();//new BLL      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //为Term下拉列表绑定数据源
                cdropTerm.DataSource = termBLL.Fn_GetAllTerm();//下拉列表的数据源
                cdropTerm.DataBind();//绑定数据

                cdropTerm.InsertListItem(0, "--请选择--", "-1");//添加第0项    
                cdropTerm.SelectedIndex = 0;//默认选择第0项
            }
        }

        /// <summary>
        /// 删除按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnDelete_Click(object sender, EventArgs e)
        {
            //删除之前进行判断
            if (Fn_AllowDel() == true)
            {
                //是1
                Response.Write("<script>alert('该学年学期为当前的学年学期,不可以删除!');</script>");//弹出窗口提醒用户该学年学期为当前的学年学期,不可以删除
            }
            else
            {
                TermModel model = new TermModel();//new Model
                model.TermNum = Convert.ToInt32(cdropTerm.SelectedItem.Value);//填入下拉列表项的value

                string message = "";//底层数据库的message
                termBLL.Fn_TermDelByTermNo(model, ref message);//调用BLL的删除函数
                CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户删除是否成功     

                //重新绑定下拉列表
                cdropTerm.DataSource = termBLL.Fn_GetAllTerm();//下拉列表的数据源
                cdropTerm.DataTextField = "Term";//绑定下拉列表上面显示的文本
                cdropTerm.DataValueField = "TermNum";//绑定绑定下拉列表上面的value

                //激活数据绑定
                cdropTerm.DataBind();

                cdropTerm.InsertListItem(0, "--请选择--", "-1");//添加第0项    
                cdropTerm.SelectedIndex = 0;//默认选择第0项
                lblStatus.Text = "";//将第0项的文本清空
            }
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TermDelete.aspx");//刷新本页面
        }

        /// <summary>
        /// 下拉列表的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbTerm_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //当用户点击请选择的时候
            if (cdropTerm.SelectedItem.Value == "-1")
            {
                lblStatus.Text = "";//将label上的文本清空
            }
            else
            {
                //当用户点击其他选项的时候
                TermModel model = new TermModel();//new Model
                model = termBLL.Fn_GetIsCurrentTermByTermNo(Convert.ToInt32(cdropTerm.SelectedItem.Value));//根据下拉列表项的ID去查询
                //chkIsCurrentTerm.Checked = Convert.ToBoolean(model.IsCurrentTerm);//将IsCurrentTerm转换为bool类型
                ViewState["lstTerm"] = cdropTerm.SelectedItem.Value;//将下拉列表的value放到ViewState当中去
                //chkIsCurrentTerm.Checked = model.IsCurrentTerm == "1" ? true : false;//将IsCurrentTerm转换为bool类型
                bool isOne = model.IsCurrentTerm == "1" ? true : false;//是否为1
                ViewState["isOne"] = model.IsCurrentTerm == "1" ? true : false;//是否为1            

                if (isOne == false)
                {
                    lblStatus.Text = "否";
                    lblStatus.ForeColor = System.Drawing.Color.Black;//用红色提示用户是当前学期
                }
                else
                {
                    lblStatus.Text = "是";//提升用户是当前学期
                    lblStatus.ForeColor = System.Drawing.Color.Red;//用红色提示用户是当前学期

                    //ViewState["txtAlert"] = "是";//提醒文本
                }
            }
        }

        /// <summary>
        /// 判断一下是否可以删除
        /// </summary>
        /// <returns></returns>
        public bool Fn_AllowDel()
        {
            if (Convert.ToBoolean(ViewState["isOne"]) == true)
            {
                //是1
                return true;//不可以删除
            }
            else
            {
                //是0
                return false;//可以删除
            }
        }
    }
}
