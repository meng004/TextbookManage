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
    public partial class IdentityCardTypeDelete : System.Web.UI.Page
    {
        private IIdentityCardTypeBLL idCardTypeBLL = new IdentityCardTypeBLL();//new BLL

        protected void Page_Load(object sender, EventArgs e)
        {
            //处理下拉列表,绑定下拉列表的数据源
            if (!this.IsPostBack)
            {
                clstIdentityCardType.DataSource = idCardTypeBLL.Fn_GetIdCardTypeList();//下拉列表的数据源
                clstIdentityCardType.DataBind();//绑定数据

                clstIdentityCardType.InsertListItem(0, "--请选择--", "-1");//添加第0项       

                clstIdentityCardType.SelectedIndex = 0;//默认选择第0项
            }
        }

        /// <summary>
        /// 删除按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnDelete_Cilck(object sender, EventArgs e)
        {
            IdentityCardTypeModel model = new IdentityCardTypeModel();//new model
            model.IdentityCardTypeNum = Convert.ToInt32(ViewState["lstIdCardType"]);

            string message = "";//底层数据库的message
            idCardTypeBLL.Fn_IdCardTypeDeleteById(model, ref message);//调用BLL层的删除函数

            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户删除是否成功

            //刷新下拉列表
            clstIdentityCardType.DataSource = idCardTypeBLL.Fn_GetIdCardTypeList();//下拉列表的数据源
            clstIdentityCardType.DataValueField = "IdentityCardTypeNum";
            clstIdentityCardType.DataTextField = "IdentityCard";

            clstIdentityCardType.DataBind();//绑定数据
            clstIdentityCardType.InsertListItem(0, "--请选择--", "-1");//添加第0项   

            //将下拉选项改为请选择
            clstIdentityCardType.SelectedIndex = 0;//默认选择第0项
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("IdentityCardTypeDelete.aspx");//刷新本页面
        }

        /// <summary>
        /// 下拉列表的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clstIdCardType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["lstIdCardType"] = clstIdentityCardType.SelectedItem.Value;//先保存IdentityCardType             
        }
    }
}