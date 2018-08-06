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
    public partial class AlertAdd : System.Web.UI.Page
    {
        //private AlertModel model = new AlertModel();//new Model
        private IAlertBLL alertBLL = new AlertBLL();//new BLL

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 新增按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSubmit_Click(object sender, EventArgs e)
        {
            IList<AlertModel> modelList = new List<AlertModel>();//new model list
            modelList = alertBLL.Fn_CheckAlertName();//获取所有的AlertName

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
                Fn_AddAlert();//调用Fn_AddAlert函数,向Alert表中添加记录                
            }
        }

        /// <summary>
        /// 添加Alert
        /// </summary>
        public void Fn_AddAlert()
        {
            AlertModel model = new AlertModel();//new model
            model.AlertName = ctxtAlertName.Text.Trim();//获取页面的AlertName,将string前后的空格去掉,存入数据库
            model.BeginDate = cdateBeginDate.SelectedDate.ToString();//开始日期
            model.EndDate = cdateEndDate.SelectedDate.ToString();//结束日期

            string message = "";//底层数据库的消息
            alertBLL.Fn_AlertAdd(model, ref message);//调用BLL层的Fn_AlertAdd函数            
            CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出消息框,提示用户插入是否成功                       
        }

        /// <summary>
        /// 取消按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e)
        {
            //将文本框,两个日历控件置空
            ctxtAlertName.Text = "";
            cdateBeginDate.DbSelectedDate = null;//开始日期置空
            cdateEndDate.DbSelectedDate = null;//结束日期置空
        }
    }
}