using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_21
{
    public partial class RecipientUpdate : System.Web.UI.Page
    {
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_21.IRecipientUpdateBLL _RecipientType = new CPMis.BLL.Tb_Maintain.Tb_Maintain_21.RecipientUpdateBLL();
        CPMis.Model.Tb_Maintain.Tb_Maintain_21.RecipientTypeModel _RecipientTypeModel = new Model.Tb_Maintain.Tb_Maintain_21.RecipientTypeModel();
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_21.IRecipientAddBLL _CheckRecipientType = new CPMis.BLL.Tb_Maintain.Tb_Maintain_21.RecipientAddBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fn_Query();                                                            
            }            
        }

        /// <summary>
        /// 下拉列表绑定数据源
        /// </summary>
        protected void Fn_Query() 
        {
            //下拉列表绑定数据源
            cdlstRecipient.DataSource = _RecipientType.Fn_GetRecipientType();
            cdlstRecipient.DataBind(); 
            //修改框中显示下拉列表所选中的值  
            ctxtRecipient.Text = cdlstRecipient.SelectedText;                               
        }

        /// <summary>
        /// 文本框的值随下拉列表选定值变动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdlstRecipient_IndexChanged(object sender, EventArgs e) 
        {
            ctxtRecipient.Text = "";
            ctxtRecipient.Text = cdlstRecipient.SelectedText;
        }

        /// <summary>
        /// 保存按钮保存修改的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSave_Click(object sender, EventArgs e)
        {
            //判断修改的领用人类型名是否已经存在
            if (ctxtRecipient.Text == cdlstRecipient.SelectedText)//没改的话什么都不做
            {

            }
            else
            {
                string message = "";
                _RecipientTypeModel.RecipientType = ctxtRecipient.Text;                   //获取更新的值 
                _RecipientTypeModel.RecipientTypeID = cdlstRecipient.SelectedValue;       //获取所选的ID
                
                if (ctxtRecipient.Text != "")
                {
                    Regex RecipientRegex = new Regex(@"^[a-zA-Z0-9\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);
                    if (RecipientRegex.IsMatch(_RecipientTypeModel.RecipientType))
                    {
                        if (_CheckRecipientType.Fn_CheckRecipientType(ctxtRecipient.Text))//改了判断是否已经存在
                        {
                            Web.WebClient.ScriptManager.Alert("领用人类型已存在，请重新输入！");
                            ctxtRecipient.Text = "";
                        }
                        else
                        {
                            message = _RecipientType.Fn_UpdateRecipient(_RecipientTypeModel);
                            CPMis.Web.WebClient.ScriptManager.Alert(message);

                            Fn_Query();//刷新页面
                            cdlstRecipient.SelectedText = _RecipientTypeModel.RecipientType;//下拉列表显示刚刚修改的值
                            ctxtRecipient.Text = _RecipientTypeModel.RecipientType;//文本框显示刚刚修改的值
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
                    Web.WebClient.ScriptManager.Alert("领用人类型不能为空，请输入再后保存！");
                }
            }
        }

        /// <summary>
        /// 取消按钮，页面恢复初始状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e) 
        {
            Fn_Query();            
        }
    }
}