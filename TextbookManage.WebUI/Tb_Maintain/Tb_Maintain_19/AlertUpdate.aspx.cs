using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_19;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_19;
using CPMis.Model.Tb_Maintain.Tb_Maintain_19;
using Telerik.Web.UI;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_19
{
    public partial class AlertUpdate : System.Web.UI.Page
    {
        private IAlertBLL alertBLL = new AlertBLL();//new BLL

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Fn_BindingAlertName();//绑定AlertName下拉列表

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
            cdropAlertName.DataBind();
        }

        /// <summary>
        /// 更新按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnUpdate_Click(object sender, EventArgs e)
        {
            IList<AlertModel> modelList = new List<AlertModel>();//new model list
            modelList = alertBLL.Fn_CheckAlertName();//获取所有的AlertName

            //不修改AlertName,只修改两个日期. 即AlertName不变
            if (ViewState["AlertName"].ToString().Trim() == ctxtAlertName.Text.Trim())
            {
                Fn_UpdateAlert();//调用Fn_UpdateAlert函数,更新Alert表中记录         
            }
            else
            {
                //AlertName变了
                bool isDifferent = true;//初始化变量isDifferent为true
                foreach (AlertModel model in modelList)
                {
                    //去掉string的前后空格,进行比较
                    if (model.AlertName.Trim() == ctxtAlertName.Text.Trim())
                    {
                        isDifferent = false;//相同,存在同名的AlertName                    
                        Response.Write("<script>alert('已存在该提醒名称,请重新输入提醒名称!')</script>");
                    }
                }
                //不存在同名的AlertName
                if (isDifferent == true)
                {
                    Fn_UpdateAlert();//调用Fn_UpdateAlert函数,更新Alert表中记录                
                }
            }//end else
        }

        /// <summary>
        /// 更新Alert表中记录的事件
        /// </summary>
        public void Fn_UpdateAlert()
        {
            AlertModel model = new AlertModel();//new model
            model.AlertNum = Convert.ToInt32(ViewState["AlertId"]);//下拉列表的value
            model.AlertName = ctxtAlertName.Text.Trim();//新的提醒名称,去掉前后的空格
            model.BeginDate = cdateBeginDate.SelectedDate.ToString();//开始日期
            model.EndDate = cdateEndDate.SelectedDate.ToString();//结束日期  

            string message = "";//底层数据库的message
            alertBLL.Fn_AlertUpdate(model, ref message);//调用BLL层的Fn_AlertUpdate函数
            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户更新是否成功

            //更新之后再查询一次数据库,刷新各个控件
            Fn_QueryAlertByAlertId(ViewState["AlertId"].ToString());//调用Fn_QueryAlertByAlertId函数

            Fn_BindingAlertName();//刷新AlertName下拉列表
            cdropAlertName.FindItemByValue(ViewState["AlertId"].ToString()).Selected = true;//之后选中的项
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlertUpdate.aspx");//刷新本页面
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
                    ctxtAlertName.Text = model.AlertName;//读取到文本框当中
                    ViewState["AlertName"] = model.AlertName;//将数据库中的AlertName保存到ViewState中
                    cdateBeginDate.DbSelectedDate = (Convert.ToDateTime(model.BeginDate)).ToShortDateString();//将年月日转换为对应的开始日期
                    cdateEndDate.DbSelectedDate = (Convert.ToDateTime(model.EndDate)).ToShortDateString();//将年月日转换为对应的结束日期 
                }
            }//end foreach

            //当用户点击请选择的时候
            if (cdropAlertName.SelectedItem.Value == "-1")
            {
                //清空文本框及日历控件
                ctxtAlertName.Text = "";
                cdateBeginDate.DbSelectedDate = null;//开始日期清空
                cdateEndDate.DbSelectedDate = null;//结束日期清空
            }
        }
    }
}