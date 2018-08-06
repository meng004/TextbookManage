using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_22;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_22;
using CPMis.Model.Tb_Maintain.Tb_Maintain_22;
using System.Data;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_22
{
    public partial class IdentityCardTypeUpdate : System.Web.UI.Page
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
        /// 更新按钮的事件
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
                Fn_UpdateIdCardType();//调用Fn_UpdateIdCardType函数
            }
        }

        /// <summary>
        /// 更新IdCardType表
        /// </summary>
        public void Fn_UpdateIdCardType()
        {
            IdentityCardTypeModel model = new IdentityCardTypeModel();//new model
            model.IdentityCardTypeNum = Convert.ToInt32(ViewState["lstIdCardType"]);//下拉列表的value
            model.IdentityCard = ctxtIdentityCardType.Text.Trim();//去掉文本框前后的空格

            string message = "";//底层数据库的message
            idCardTypeBLL.Fn_IdCardTypeUpdate(model, ref message);//调用BLL层的Fn_IdCardTypeUpdate函数
            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户更新是否成功

            //更新之后再查询一次数据库,刷新各个控件
            Fn_QueryIdCardTypeById(ViewState["lstIdCardType"].ToString());

            //重新绑定数据源
            clstIdentityCardType.DataSource = idCardTypeBLL.Fn_GetIdCardTypeList();//下拉列表的数据源
            clstIdentityCardType.DataValueField = "IdentityCardTypeNum";
            clstIdentityCardType.DataTextField = "IdentityCard";
            clstIdentityCardType.DataBind();//绑定数据

            clstIdentityCardType.DataBind();//激活数据绑定

            //之后选中的项
            clstIdentityCardType.FindItemByValue(ViewState["lstIdCardType"].ToString()).Selected = true;//之后选中的项
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("IdentityCardTypeUpdate.aspx");//刷新本页面
        }

        /// <summary>
        /// 下拉列表的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clstIdCardType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["lstIdCardType"] = clstIdentityCardType.SelectedItem.Value;//先保存IdentityCardType
            Fn_QueryIdCardTypeById(clstIdentityCardType.SelectedItem.Value);//根据下拉列表项的Id去查询   
        }

        /// <summary>
        /// 通过Id查询IdCardType表中的其他字段
        /// </summary>
        /// <param name="id"></param>
        public void Fn_QueryIdCardTypeById(string id)
        {
            //当用户点击请选择的时候
            if (id == "-1")
            {
                ctxtIdentityCardType.Text = "";//清空文本框
            }
            else
            {
                //当用户点击其他的下拉选项的时候
                //ctxtIdentityCardType.Text = clstIdentityCardType.SelectedItem.Text;//文本框的文本为下拉列表中的文本

                //当用户点击其他的下拉选项的时候
                DataSet ds = idCardTypeBLL.Fn_GetIdCardTypeList();//调用Fn_GetIdCardTypeList函数
                DataTable dt = ds.Tables[0];//取出结果集

                //for遍历IdentityCardType字段
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];//Data Row
                    if (id == row["IdentityCardTypeNum"].ToString())
                    {
                        ctxtIdentityCardType.Text = row["IdentityCard"].ToString();//文本框的文本为下拉列表中的文本
                    }
                }
            }
        }
    }
}