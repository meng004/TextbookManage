using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_22;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_22;
using CPMis.Model.Tb_Maintain.Tb_Maintain_22;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_22
{
    public partial class IdentityCardTypeAdd : System.Web.UI.Page
    {
        private IIdentityCardTypeBLL idCardTypeBLL = new IdentityCardTypeBLL();//new BLL

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSave_Click(object sender, EventArgs e)
        {
            //存在同名的IdentityCardType
            if (idCardTypeBLL.Fn_CheckIdCardType(ctxtIdentityCardType.Text) == true)
            {
                Response.Write("<script>alert('已存在该证件类型名称,请重新输入证件名称!')</script>");
            }
            else
            {
                //不同名
                Fn_AddIdCard();//调用Fn_AddIdCard函数
            }
        }

        /// <summary>
        /// 添加证件类型
        /// </summary>
        public void Fn_AddIdCard()
        {
            IdentityCardTypeModel model = new IdentityCardTypeModel();//new model 
            model.IdentityCard = ctxtIdentityCardType.Text.Trim();//获取页面的IdentityCard,将string前后的空格去掉,存入数据库

            string message = "";//底层数据库的消息
            idCardTypeBLL.Fn_IdCardTypeAdd(model, ref message);//调用BLL层的Fn_IdCardTypeAdd函数    
            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户插入是否成功
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            //将文本框清空
            ctxtIdentityCardType.Text = "";//将文本框清空
        }
    }
}