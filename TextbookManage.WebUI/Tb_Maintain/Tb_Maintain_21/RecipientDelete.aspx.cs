using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_21
{
    public partial class RecipientDelete : System.Web.UI.Page
    {
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_21.IRecipientUpdateBLL _RecipientUpdateBLL=new CPMis.BLL.Tb_Maintain.Tb_Maintain_21.RecipientUpdateBLL();
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_21.IRecipientDeleteBLL _RecipientDeleteBLL=new CPMis.BLL.Tb_Maintain.Tb_Maintain_21.RecipientDeleteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉列表绑定数据源
                cdlstRecipient.DataSource = _RecipientUpdateBLL.Fn_GetRecipientType();
                cdlstRecipient.DataBind();
            }
        }

        /// <summary>
        /// 删除按钮删除所选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnDelete_Cilck(object sender, EventArgs e) 
        {
            string message = "";
            string a = cdlstRecipient.SelectedText;
            message = _RecipientDeleteBLL.Fn_DeleteRecipientType(cdlstRecipient.SelectedValue);
            Web.WebClient.ScriptManager.Alert(message);
            //删除后刷新页面
            cdlstRecipient.DataSource = _RecipientUpdateBLL.Fn_GetRecipientType();
            cdlstRecipient.DataBind();
        }

        protected void cbtnCancle_Click(object sender, EventArgs e) 
        {

        }
    }
}