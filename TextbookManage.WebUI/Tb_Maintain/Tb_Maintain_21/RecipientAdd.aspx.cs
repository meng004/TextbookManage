using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_21
{
    public partial class RecipientAdd : System.Web.UI.Page
    {
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_21.IRecipientAddBLL _RecipientAddBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_21.RecipientAddBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存按钮确认新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSave_Click(object sender, EventArgs e)
        {
            string message = "";
            string RecipientType = ctxtRecipient.Text;   //获取文本框的值

            if (RecipientType != "")
            {
                Regex TypeRegex = new Regex(@"^[a-zA-Z0-9\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);//正在表达式判断输入的是否合法
                if (TypeRegex.IsMatch(RecipientType))
                {
                    if (_RecipientAddBLL.Fn_CheckRecipientType(RecipientType))
                    {
                        CPMis.Web.WebClient.ScriptManager.Alert("领用人类型已存在，请重新输入！");
                        ctxtRecipient.Text = "";
                    }
                    else
                    {
                        message = _RecipientAddBLL.Fn_AddRecipientType(RecipientType);//调用函数返回消息
                        CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出提示消息
                    }
                }
                else
                {
                    Web.WebClient.ScriptManager.Alert("领用人类型格式错误，请输入正确的格式！");
                    ctxtRecipient.Text = "";
                }
            }
            else 
            {
                Web.WebClient.ScriptManager.Alert("领用人类型不能为空，请输入后再保存！");
            }
        }

        /// <summary>
        /// 点击取消按钮将内容至为空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e) 
        {
            ctxtRecipient.Text = "";
        }
    }
}