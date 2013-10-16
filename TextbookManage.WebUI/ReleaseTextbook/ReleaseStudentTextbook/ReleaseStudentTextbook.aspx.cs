using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;
using System.Drawing;
using CPMis.Model.Tb_PSS.Tb_PSS_02;
using System.Text.RegularExpressions;
using CPMis.Web.WebControls;
using System.Data;

namespace CPMis.WebPage.Tb_PSS.Tb_PSS_02
{
    public partial class ReleaseStudentTextbook : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger userProfile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        IBLL.Tb_PSS.Tb_PSS_02.IReleaseStudentTextbookBLL _releaseStudentTextbookBLL = new BLL.Tb_PSS.Tb_PSS_02.ReleaseStudentTextbookBLL();
        StudentRecipientInfoModel _studentRecipientInfoModel = new StudentRecipientInfoModel();
        private CPMis.IBLL.ReportViews.ITextbookHandlerBLL _textbookRecordRow = new CPMis.BLL.ReportViews.TextbookHandlerBLL();

        public static string recipientId = "";//领用人1ID
        public static string recipientId2 = "";//领用人2ID
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbSchool.DataSourceID = "SqlDataSource_School";
                ccmbSchool.DataBind();
                ccmbSchool.InsertListItem(0, "---请选择---",Guid.Empty.ToString());
                ccmbGrade.DataSourceID = "SqlDataSource_Grade";
                ccmbGrade.DataBind();
                ccmbProfessionalClass.DataSourceID = "ControlDataSource_Class";
                ccmbProfessionalClass.DataBind();
                ccmbProfessionalClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");              
            }   
        }
        /// <summary>
        /// 查询按钮事件响应
        /// </summary>
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            ctxtStudentName1.Text = "";
            ctxtStudentNum1.Text = "";
            ctxtStudentName2.Text = "";
            ctxtStudentNum2.Text = "";
            ctxtTelephone1.Text = "";
            ctxtTelephone2.Text = "";
            cgrdStudentTbSet.DoDataBind();
        }
        public void RebindGridView(object sender, AjaxRequestEventArgs e)
        {
            string cmd = e.Argument;
            if (cmd == "Rebind")
            {
                cgrdStudentTbSet.DoDataBind();
            }
        }
        /// <summary>
        /// 发放按钮事件响应
        /// </summary>
        protected void cbtnRelease_Click(object sender, EventArgs e)
        {
            if (ctxtStudentName1.Text != ""
                && ctxtTelephone1.Text != ""
                && ctxtStudentName2.Text != ""
                && ctxtTelephone2.Text != "")//&& ctxtStudentNum1.Text != ctxtStudentNum2.Text)
            {
                HttpCookie cookie = new HttpCookie("ReleaseRecord");
                cookie["ClassID"] = ccmbProfessionalClass.SelectedValue;
                cookie["ClassName"] = ccmbProfessionalClass.SelectedText;
                cookie["School"] = ccmbSchool.SelectedText;
                cookie["Grade"] = ccmbGrade.SelectedText;

                cookie["TextbookIdSet"] = "";

                ArrayList inventoryId = new ArrayList();
                //ArrayList planCount = new ArrayList();
                ArrayList TextbookId = new ArrayList();
                for (int i = 0; i <= cgrdStudentTbSet.MasterTableView.Items.Count - 1; i++)
                {
                    CheckBox cbox = (CheckBox)cgrdStudentTbSet.MasterTableView.Items[i].FindControl("chbTemplate");
                    if (cbox.Checked)
                    {
                       
                        inventoryId.Add(cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["InventoryID"].ToString());//取得被选中行的记录ID
                        // planCount.Add(cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["PlanCount"].ToString());//取得被选中行的计划数
                        string textbookID=cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["TextbookId"].ToString();
                        string releaseCount = cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["ReleaseCount"].ToString();
                        string courseName = cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["CourseName"].ToString();
                        string shelfNumber = cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["ShelfNumber"].ToString();
                        TextbookId.Add(textbookID);//取得被选中行的教材Id

                        cookie[textbookID] = releaseCount;
                        cookie[textbookID + "CourseName"] = courseName;
                        cookie[textbookID + "ShelfNumber"] = shelfNumber;
                        cookie["TextbookIdSet"] = cookie["TextbookIdSet"] + "#" + cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["TextbookId"].ToString();//用#符号分隔多个textbookID
                    }
                }
                Response.Cookies.Add(cookie);
                string[] inventoryID = (string[])inventoryId.ToArray(typeof(string));
                //string[] PlanCount = (string[])planCount.ToArray(typeof(string));  
                string[] textbookId = (string[])TextbookId.ToArray(typeof(string));

                if (inventoryID.Length > 0)//当数组inventoryID长度大于0，即选择的记录数大于等于1是给与发放教材
                {
                    _studentRecipientInfoModel.ProfessionalClassId = ccmbProfessionalClass.SelectedValue;//班级ID
                    _studentRecipientInfoModel.InventoryId = inventoryID;//库存ID
                    //_studentRecipientInfoModel.PlantCount = PlanCount;//计划数
                    _studentRecipientInfoModel.BooksellerStaffId = userProfile.StaffID;//书商员工ID
                    _studentRecipientInfoModel.TextbookId = textbookId;
                    //_studentRecipientInfoModel.StockId = ccmbStockName.SelectedValue;//仓库ID
                    _studentRecipientInfoModel.RecipientTypeNum = "2";//领用人类型编号  
                    _studentRecipientInfoModel.RecipientId = recipientId;//领用人1Id
                    _studentRecipientInfoModel.Recipient = ctxtStudentName1.Text.Trim();//领用人1姓名
                    _studentRecipientInfoModel.Telephone = ctxtTelephone1.Text.ToString();//领用人1联系电话
                    _studentRecipientInfoModel.RecipientId2 = recipientId2;//领用人1Id
                    _studentRecipientInfoModel.Recipient2 = ctxtStudentName2.Text.Trim();//领用人1姓名
                    _studentRecipientInfoModel.Telephone2 = ctxtTelephone2.Text.ToString();//领用人1联系电话

                    string message = "";
                    _releaseStudentTextbookBLL.Fn_ReleaseStudentTextbook(_studentRecipientInfoModel, ref message);
                    cgrdStudentTbSet.DoDataBind();

                    CPMis.Web.WebClient.ScriptManager.Alert(message);
                   
                }
                else
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("请选中要操作的数据！");
                }
            }
            else
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请填写完整且符合要求的领用信息！");   
            }
        }

        protected void cbtnPrint_Click(object sender, EventArgs args)
        {
             CPMis.Web.WebClient.ScriptManager.ExecuteJs("popPrintWindow()");
 //          Response.Redirect("~/ReportViewsUI/StudentTextbookRelease.aspx", false);
 //          this.Server.Transfer("~/ReportViewsUI/StudentTextbookRelease.aspx", true);
        }
        #region 报表参数
        public DataTable ReleaseResult {
            get { 
                  string []columns = { "TextbookID","TextbookName", "ISBN", "Author", "Press", "ReleaseCount", "ShelfNumber", "CourseName"};
                  DataTable result = new DataTable();
                  foreach (string s in columns)
                  {
                      result.Columns.Add(s);
                  }
                  for (int i = 0, index = 0; i < cgrdStudentTbSet.MasterTableView.Items.Count; i++)
                  {
                    CheckBox cbox = (CheckBox)cgrdStudentTbSet.MasterTableView.Items[i].FindControl("chbTemplate");
                    if (cbox.Checked)
                    {
                        result.Rows.Add();
                        result.Rows[index]["TextbookID"] = cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["TextbookID"].ToString();
                        result.Rows[index]["ReleaseCount"] = Convert.ToInt32(cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["ReleaseCount"].ToString());
                        result.Rows[index]["CourseName"] = cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["CourseName"].ToString();
                        result.Rows[index]["ShelfNumber"] = cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["ShelfNumber"].ToString();
                        DataRow dr = _textbookRecordRow.TextbookRecord(result.Rows[index]["TextbookID"].ToString());
                        result.Rows[index]["TextbookName"] = dr["TextbookName"];
                        result.Rows[index]["Author"] = dr["Author"];
                        result.Rows[index]["ISBN"] = dr["ISBN"];
                        result.Rows[index]["Press"] = dr["Press"];
                        index++;
                    }
                  }                  
                 return result;        
            }
        
        }
        public string SchoolName {
            get {
                return ccmbSchool.SelectedText;
            }
        }
        public string ClassName {
            get {
                return ccmbProfessionalClass.SelectedText;
            }
        }
        public string ClassID {
            get {
                return ccmbProfessionalClass.SelectedValue;
            }
        }
       
        #endregion
        /// <summary>
        /// cgrdStudentTbSet数据绑定前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdStudentTbSet_OnBeforeDataBind(object sender, EventArgs e)
        {           
            cgrdStudentTbSet.DataSource = _releaseStudentTextbookBLL.Fn_GetListReleaseStudentTextbook(ccmbProfessionalClass.SelectedValue, ccmbStockName.SelectedValue);        
        }

        /// <summary>
        /// 班级下拉框联动事件
        /// </summary>
        protected void ccmbProfessionalClass_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ctxtStudentName1.Text = "";
            ctxtStudentNum1.Text = "";
            ctxtStudentName2.Text = "";
            ctxtStudentNum2.Text = "";
            ctxtTelephone1.Text = "";
            ctxtTelephone2.Text = "";
            cgrdStudentTbSet.DoDataBind();
        }

        protected void ccmbSchool_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ccmbGrade.DataSourceID = "SqlDataSource_Grade";
            ccmbGrade.DataBind();
            ccmbProfessionalClass.DataSourceID = "ControlDataSource_Class";
            ccmbProfessionalClass.DataBind();
            ccmbProfessionalClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }
        protected void ccmbGrade_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {           
            ccmbProfessionalClass.DataSourceID = "ControlDataSource_Class";
            ccmbProfessionalClass.DataBind();
            ccmbProfessionalClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");     
        }
        /// <summary>
        /// 仓库名称下拉框联动事件
        /// </summary>
        protected void ccmbStockName_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdStudentTbSet.DoDataBind();
        }

        /// <summary>
        /// cgrdStudentTbSet数据绑定时的数据处理
        /// </summary>
        protected void cgrdStudentTbSet_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                int planCount = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PlanCount"].ToString());
                int storeCount = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StoreCount"].ToString());
                if ((storeCount-planCount)<0)
                {
                    e.Item.ForeColor = Color.Red;//改变该行字体的颜色
                    //(e.Item.FindControl("chbTemplate") as CheckBox).Enabled = false; //禁用CheckBox              
                }
            }
        }
        /// <summary>
        /// cgrdStudentTbSet中更改链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnChange_Click(object sender, EventArgs e)
        {
            GridDataItem Item = (GridDataItem)((CPMisLinkButton)sender).Parent.Parent;
            string textbookId = Item.OwnerTableView.DataKeyValues[Item.ItemIndex]["TextbookId"].ToString();
            string inventoryId = Item.OwnerTableView.DataKeyValues[Item.ItemIndex]["InventoryID"].ToString();
            string classId = ccmbProfessionalClass.SelectedValue;

            string js = "OnRecipientStudent('" + inventoryId + "','" + textbookId + "', '" + classId + "','Release')";

            CPMis.Web.WebClient.ScriptManager.ExecuteJs(js);
        }
        /// <summary>
        /// 检测领用人编号的合法性
        /// </summary>
        protected void lbtnCheck1_Click(object sender, EventArgs e)
        {
            string recipientName = String.Empty;
            
            _releaseStudentTextbookBLL.Fn_CheckRecipientNum(ctxtStudentNum1.Text.ToString().Trim(), ccmbProfessionalClass.SelectedValue, ref recipientName, ref recipientId);

            if (recipientName == "" || recipientName == null)//判断领用人是否存在
            {
                CPMis.Web.WebClient.ScriptManager.Alert("不存在编号:" + ctxtStudentNum1.Text.Trim() + "对应的用户名！请重新输入！");
                ctxtStudentNum1.Text = "";
               // Page.SetFocus(ctxtStudentNum1);//将焦点设置到领用人编号文本框
            }
            else
            {
                ctxtStudentName1.Text = recipientName;
               // CPMis.Web.WebClient.ScriptManager.Alert("编号" + ctxtStudentNum1.Text.Trim() + "对应的用户名为:" + recipientName);                       
            }
        }
        protected void lbtnCheck2_Click(object sender, EventArgs e)
        {
            string recipientName = String.Empty;
          
                _releaseStudentTextbookBLL.Fn_CheckRecipientNum(ctxtStudentNum2.Text.ToString().Trim(), ccmbProfessionalClass.SelectedValue,ref recipientName,ref recipientId2);


                if (recipientName == String.Empty || recipientName == null)//判断领用人是否存在
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("不存在编号:" + ctxtStudentNum2.Text.Trim() + "对应的用户名！请重新输入！");
                    ctxtStudentNum2.Text = "";
                  //  Page.SetFocus(ctxtStudentNum1);//将焦点设置到领用人编号文本框
                }
                else
                {               
                    ctxtStudentName2.Text = recipientName;
                   // CPMis.Web.WebClient.ScriptManager.Alert("编号" + ctxtStudentNum2.Text.Trim() + "对应的用户名为:" + recipientName);
                }
        }
        ///// <summary>
        ///// 检测学号是否格式正确
        ///// </summary>
        ///// <param name="para_stuNum">学号</param>
        ///// <returns>true/false</returns>
        //protected bool Fn_CheckStuNum(string para_stuNum)
        //{
        //    string reg = @"^[0-9]{11,15}$";
        //    if (Regex.IsMatch(para_stuNum, reg))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}               
    }
}