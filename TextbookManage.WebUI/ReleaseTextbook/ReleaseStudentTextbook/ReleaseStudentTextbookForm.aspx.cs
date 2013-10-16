using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;

namespace TextbookManage.WebUI.ReleaseTextbook.ReleaseStudentTextbook
{
    public partial class ReleaseStudentTextbookForm : System.Web.UI.Page
    {
        IBLL.Tb_PSS.Tb_PSS_02.IReleaseStudentTextbookBLL _releaseStudentTextbookBLL = new BLL.Tb_PSS.Tb_PSS_02.ReleaseStudentTextbookBLL();
       // public static IList<Model.Tb_PSS.Tb_PSS_02.ExceptionRecipientStudentModel> _exceptionRecipientStudentModelList = new List<Model.Tb_PSS.Tb_PSS_02.ExceptionRecipientStudentModel>();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cgrdStudentList.DoDataBind();               
            }
        }

        protected void toolBar_Click(object sender,RadToolBarEventArgs e)
        {
            string commandName = e.Item.Text.Trim();

            switch (commandName)
            {
                case "确定": cbtnConfirm_Click();
                              break;
                //case "关闭": cbtnClose_Click();
                //              break;
                default: break  ;
            }
        
        }
        /// <summary>
        /// cgrdStudentList绑定数据前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdStudentList_OnBeforeDataBind(object sender, EventArgs e)
        {
            string commandName = Request.QueryString["CommandName"].ToString();
            string classId=Request.QueryString["ClassId"].ToString();
            string textbookId = Request.QueryString["TextbookId"].ToString();          
            cgrdStudentList.DataSource = _releaseStudentTextbookBLL.Fn_GetListRecipientStudent(classId,textbookId,commandName);
        }
        /// <summary>
        /// 确定按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnConfirm_Click()
        {
            ArrayList StudentSubscriptionPlanId = new ArrayList();
            string classId=Request.QueryString["ClassId"].ToString();
            string textbookId = Request.QueryString["TextbookId"].ToString();
            string isAllTextbook = "0";
            string message = "";
            for(int i=0;i<cgrdStudentList.MasterTableView.Items.Count;i++)
            {
                 CheckBox cbox = (CheckBox)cgrdStudentList.MasterTableView.Items[i].FindControl("chbTemplate");
                if (!cbox.Checked)
                {
                    StudentSubscriptionPlanId.Add(cgrdStudentList.MasterTableView.DataKeyValues[i]["StudentSubscriptionPlanId"].ToString());//取得被选中行的记录ID                      
                }
            }
            string[] studentSubscriptionPlanId=(string[])StudentSubscriptionPlanId.ToArray(typeof(string));
            if (cchkApplyToAll.Checked == true)//判断是否适用于全班
            {
                isAllTextbook = "1";
            }
            else
            {
                isAllTextbook = "0";
            }

             _releaseStudentTextbookBLL.Fn_UnReceiveStudent(studentSubscriptionPlanId, classId, textbookId, isAllTextbook, ref message);
          
            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }
        /// <summary>
        /// 关闭按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnClose_Click()
        {
            string js="var oWindow = null;if (window.radWindow) oWindow = window.radWindow;else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;oWindow.close();";
           CPMis.Web.WebClient.ScriptManager.ExecuteJs(js);
        }

        protected void cgrdStudentList_OnItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                string isChecked = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IsChecked"].ToString();

                if (isChecked == "1")
                {
                    (e.Item.FindControl("chbTemplate") as CheckBox).Checked = true; //勾选CheckBox              
                }
                else 
                {
                    (e.Item.FindControl("chbTemplate") as CheckBox).Checked = false; //不勾选CheckBox  
                }
            }
        }
    }
}