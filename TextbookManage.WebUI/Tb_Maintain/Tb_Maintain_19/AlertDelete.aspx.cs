using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_19;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_19;
using CPMis.Model.Tb_Maintain.Tb_Maintain_19;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_19
{
    public partial class AlertDelete : System.Web.UI.Page
    {
        private IAlertBLL alertBLL = new AlertBLL();//new BLL

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // CPMis.WebPage.Tb_Maintain.Tb_Maintain_19.AlertUpdate.Fn_BindingAlertName();//绑定AlertName下拉列表
                Fn_BindingAlertName();//绑定AlertName下拉列表
                //确保在下拉列表中没有任何一个列表项被选中
                //cdropAlertName.SelectedIndex = -1;
                cdropAlertName.SelectedIndex = 0;//默认选择第0项
            }
        }

        /// <summary>
        /// 绑定AlertName下拉列表
        /// </summary>
        public void Fn_BindingAlertName()
        {
            IList<AlertModel> modelList = new List<AlertModel>();//new list
            AlertModel model = new AlertModel();//new model

            //添加第0项
            model.AlertNum = -1;//第一项的AlertNum设置为-1
            model.AlertName = "--请选择--";
            modelList.Add(model);//添加第0项

            foreach (AlertModel model1 in alertBLL.Fn_AlertNameList())
            {
                //model.AlertNo=alertBLL.Fn_AlertNameList()
                modelList.Add(model1);//添加其他项
            }
            cdropAlertName.DataSource = modelList;//绑定数据源
            cdropAlertName.DataValueField = "AlertNum";//value 字段
            cdropAlertName.DataTextField = "AlertName";//文本字段

            //激活数据绑定
            //this.DataBind();
            cdropAlertName.DataBind();
        }

        /// <summary>
        /// 删除按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnDelete_Click(object sender, EventArgs e)
        {
            AlertModel model = new AlertModel();//new model
            model.AlertNum = Convert.ToInt32(ViewState["AlertId"]);

            string message = "";//底层数据库的message
            alertBLL.Fn_AlertDeleteByAlertNo(model, ref message);//调用BLL的删除函数

            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户删除是否成功 

            //将下拉列表改为请选择
            Fn_BindingAlertName();//刷新AlertName下拉列表
            //cdropAlertName.FindItemByValue(((Convert.ToInt32(ViewState["AlertId"])) + 1).ToString()).Selected = true;//之后选中它的下一项
            //将日历控件清空
            cdateBeginDate.DbSelectedDate = null;//开始日期置空
            cdateEndDate.DbSelectedDate = null;//结束日期置空
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlertDelete.aspx");//刷新本页面
        }

        /// <summary>
        /// 提醒下拉列表的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbAlert_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["AlertId"] = cdropAlertName.SelectedItem.Value;//先保存AlertId
            Fn_QueryAlertByAlertId(cdropAlertName.SelectedItem.Value);//调用Fn_QueryAlertByAlertId函数
        }//end function

        /// <summary>
        /// 通过AlertId查询Alert表中的其他字段
        /// </summary>
        /// <param name="alertId"></param>
        public void Fn_QueryAlertByAlertId(string alertId)
        {
            IList<AlertModel> modelList = new List<AlertModel>();//new model list
            modelList = alertBLL.Fn_QueryAlert();//调用BLL层的Fn_QueryAlert函数
            //AlertModel model = new AlertModel();//new model

            foreach (AlertModel model in modelList)
            {
                if (model.AlertNum.ToString() == cdropAlertName.SelectedItem.Value)
                {
                    //ctxtAlertName.Text = model.AlertName;//读取到文本框当中
                    cdateBeginDate.DbSelectedDate = (Convert.ToDateTime(model.BeginDate)).ToShortDateString();//将年月日转换为对应的开始日期
                    cdateEndDate.DbSelectedDate = (Convert.ToDateTime(model.EndDate)).ToShortDateString();//将年月日转换为对应的结束日期 
                }
            }//end foreach

            //当用户点击请选择的时候
            if (cdropAlertName.SelectedItem.Value == "-1")
            {
                //清空日历控件                
                cdateBeginDate.DbSelectedDate = null;//开始日期清空
                cdateEndDate.DbSelectedDate = null;//结束日期清空
            }
        }
    }
}