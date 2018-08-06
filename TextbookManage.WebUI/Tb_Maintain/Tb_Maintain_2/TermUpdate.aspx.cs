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
    public partial class TermUpdate : System.Web.UI.Page
    {
        private ITermBLL termBLL = new TermBLL();//new BLL      

        protected void Page_Load(object sender, EventArgs e)
        {
            //在页面加载的时候
            if (!this.IsPostBack)
            {
                cdropTerm.DataSource = termBLL.Fn_GetAllTerm();//下拉列表的数据源
                cdropTerm.DataBind();//绑定数据

                cdropTerm.InsertListItem(0, "--请选择--", "-1");//添加第0项    
                cdropTerm.SelectedIndex = 0;//默认选择第0项
            }
        }

        /// <summary>
        /// 更新按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnUpdate_Click(object sender, EventArgs e)
        {
            TermModel model = new TermModel();//new Model
            model.TermNum = Convert.ToInt32(cdropTerm.SelectedItem.Value);//填入下拉列表项的value
            model.IsCurrentTerm = Convert.ToInt16(chkIsCurrentTerm.Checked).ToString();//转换为string类型
            model.BeginDate = cdateBeginDate.SelectedDate.ToString();//开始日期
            model.EndDate = cdateEndDate.SelectedDate.ToString();//结束日期                        

            TermModel queryModel = new TermModel();//查询用到的Model
            //处理开始日期为空的情况
            if (cdateBeginDate.SelectedDate.ToString() == "" && cdateEndDate.SelectedDate.ToString() != "")
            {
                //处理开始日期为空的情况
                queryModel = termBLL.Fn_GetIsCurrentTermByTermNo(Convert.ToInt32(ViewState["lstTerm"]));//根据下拉列表项的Id去查询
                model.BeginDate = queryModel.BeginDate;//将查出来的放到更新的Model中
                model.EndDate = cdateEndDate.SelectedDate.ToString();//结束日期的时间不变
            }
            if (cdateBeginDate.SelectedDate.ToString() != "" && cdateEndDate.SelectedDate.ToString() == "")
            {
                //处理结束日期为空的情况
                queryModel = termBLL.Fn_GetIsCurrentTermByTermNo(Convert.ToInt32(ViewState["lstTerm"]));//根据下拉列表项的ID去查询
                model.BeginDate = cdateBeginDate.SelectedDate.ToString();//开始日期的时间不变
                model.EndDate = queryModel.EndDate;//结束日期的时间变
            }
            if (cdateBeginDate.SelectedDate.ToString() == "" && cdateEndDate.SelectedDate.ToString() == "")
            {
                //开始日期与结束日期都为空
                queryModel = termBLL.Fn_GetIsCurrentTermByTermNo(Convert.ToInt32(ViewState["lstTerm"]));//根据下拉列表项的ID去查询
                model.BeginDate = queryModel.BeginDate;//开始日期
                model.EndDate = queryModel.EndDate;//结束日期
            }

            chkIsCurrentTerm.Enabled = true;//可以使用复选框
            string message = "";//底层数据库的message
            termBLL.Fn_TermUpdate(model, ref message);//调用BLL层的Fn_TermUpdate方法
            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户更新是否成功               
            chkIsCurrentTerm.Enabled = false;//不可以使用复选框

            Fn_QueryTermByTermId(ViewState["lstTerm"].ToString());//根据下拉列表项的ID去查询  
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TermUpdate.aspx");//刷新本页面
        }

        /// <summary>
        /// 下拉列表的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbTerm_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["lstTerm"] = cdropTerm.SelectedItem.Value;//先保存termId
            Fn_QueryTermByTermId(cdropTerm.SelectedItem.Value);//根据下拉列表项的ID去查询            
        }

        /// <summary>
        /// 通过termId去查询Term表中的其他字段
        /// </summary>
        /// <param name="termId"></param>
        public void Fn_QueryTermByTermId(string termId)
        {
            //当用户点击请选择的时候
            if (termId == "-1")
            {
                chkIsCurrentTerm.Enabled = true;//复选框控件
                chkIsCurrentTerm.Checked = false;//不勾选
                cdateBeginDate.DbSelectedDate = null;//开始日期清空
                cdateEndDate.DbSelectedDate = null;//结束日期清空
            }
            else
            {
                //当用户点击其他的下拉选项的时候,进行查询
                TermModel model = new TermModel();//new Model
                model = termBLL.Fn_GetIsCurrentTermByTermNo(Convert.ToInt32(termId));//根据下拉列表项的ID去查询            
                chkIsCurrentTerm.Checked = model.IsCurrentTerm == "1" ? true : false;//将IsCurrentTerm转换为bool类型
                cdateBeginDate.DbSelectedDate = (Convert.ToDateTime(model.BeginDate)).ToShortDateString();//将年月日转换为对应的日期
                cdateEndDate.DbSelectedDate = (Convert.ToDateTime(model.EndDate)).ToShortDateString();//将年月日转换为对应的日期                        

                //处理复选框的勾选问题
                if (chkIsCurrentTerm.Checked == false)
                {
                    chkIsCurrentTerm.Enabled = true;//未勾选的时候,可以使用复选框控件
                }
                else
                {
                    chkIsCurrentTerm.Enabled = false;//选中的时候,则禁用复选框控件
                }
            }
        }
    }
}