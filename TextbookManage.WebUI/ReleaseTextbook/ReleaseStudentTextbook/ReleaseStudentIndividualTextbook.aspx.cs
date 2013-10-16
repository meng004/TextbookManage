using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;
using System.Drawing;

namespace TextbookManage.WebUI.ReleaseTextbook.ReleaseStudentTextbook
{
    public partial class ReleaseStudentIndividualTextbook : USCTAMis.Web.WebControls.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbSchool.DataSourceID = "SqlDataSource_School";
                ccmbSchool.DataBind();
                ccmbSchool.InsertListItem(0, "---请选择---", Guid.Empty.ToString());
                ccmbProfessionalClass.DataSourceID = "ControlDataSource_Class";
                ccmbProfessionalClass.DataBind();
                ccmbProfessionalClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
                ccmbStudentName.DataSourceID = "SessionDataSource_ccmbStudentName";
                ccmbStudentName.DataBind();
                ccmbStudentName.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
            }   
        }
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdReleaseStudentTextbook.DoDataBind();
        }

        protected void cbtnRelease_Click(object sender, EventArgs e)
        {
            if (ctxtTelephone.Text!="")
            {
                ArrayList inventoryId = new ArrayList();
                //ArrayList planCount = new ArrayList();
               // ArrayList TextbookId = new ArrayList();
                for (int i = 0; i <= cgrdReleaseStudentTextbook.MasterTableView.Items.Count - 1; i++)
                {
                    CheckBox cbox = (CheckBox)cgrdReleaseStudentTextbook.MasterTableView.Items[i].FindControl("chbTemplate");
                    if (cbox.Checked)
                    {
                        inventoryId.Add(cgrdReleaseStudentTextbook.MasterTableView.DataKeyValues[i]["InventoryID"].ToString());//取得被选中行的记录ID
                        // planCount.Add(cgrdStudentTbSet.MasterTableView.DataKeyValues[i]["PlanCount"].ToString());//取得被选中行的计划数
                       // TextbookId.Add(cgrdReleaseStudentTextbook.MasterTableView.DataKeyValues[i]["TextbookId"].ToString());//取得被选中行的教材Id
                    }
                }
                string[] inventoryID = (string[])inventoryId.ToArray(typeof(string));
                //string[] PlanCount = (string[])planCount.ToArray(typeof(string));  
                //string[] textbookId = (string[])TextbookId.ToArray(typeof(string));

                if (inventoryID.Length > 0)//当数组inventoryID长度大于0，即选择的记录数大于等于1是给与发放教材
                {
                    _studentRecipientInfoModel.StudentId = ccmbStudentName.SelectedValue;//学生Id
                   _studentRecipientInfoModel.InventoryId = inventoryID;//库存ID
                    //_studentRecipientInfoModel.PlantCount = 1;//计划数
                    _studentRecipientInfoModel.BooksellerStaffId = userProfile.StaffID;//书商员工ID
                    //_studentRecipientInfoModel.TextbookId = textbookId;
                    //_studentRecipientInfoModel.StockId = ccmbStockName.SelectedValue;//仓库ID
                    //_studentRecipientInfoModel.RecipientTypeNum = "2";//领用人类型编号  
                    _studentRecipientInfoModel.RecipientId =ccmbStudentName.SelectedValue;//领用人1Id
                    _studentRecipientInfoModel.Recipient = ccmbStudentName.SelectedText.Substring(0, ccmbStudentName.SelectedText.IndexOf("(")); ;//领用人1姓名
                    _studentRecipientInfoModel.Telephone = ctxtTelephone.Text.ToString();//领用人1联系电话                   

                    string message = "";
                    _releaseStudentTextbookBLL.Fn_ReleaseStudentTextbookByPersonal(_studentRecipientInfoModel, ref message);
                    cgrdReleaseStudentTextbook.DoDataBind();

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

        protected void cgrdReleaseStudentTextbook_OnBeforeDataBind(object sender, EventArgs e)
        {
            cgrdReleaseStudentTextbook.DataSource = _releaseStudentTextbookBLL.Fn_GetListStudentTextbookByPersonal(ccmbStudentName.SelectedValue,ccmbStockName.SelectedValue);
        }

        protected void ccmbSchool_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ctxtTelephone.Text = "";
            ccmbProfessionalClass.DataSourceID = "ControlDataSource_Class";
            ccmbProfessionalClass.DataBind();
            ccmbProfessionalClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
            ccmbStudentName.DataSourceID = "SessionDataSource_ccmbStudentName";
            ccmbStudentName.DataBind();
            ccmbStudentName.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }
        protected void ccmbGrade_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ctxtTelephone.Text = "";
            ccmbProfessionalClass.DataSourceID = "ControlDataSource_Class";
            ccmbProfessionalClass.DataBind();
            ccmbProfessionalClass.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
            ccmbStudentName.DataSourceID = "SessionDataSource_ccmbStudentName";
            ccmbStudentName.DataBind();
            ccmbStudentName.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }
        protected void ccmbProfessionalClass_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ctxtTelephone.Text = "";
            ccmbStudentName.DataSourceID = "SessionDataSource_ccmbStudentName";
            ccmbStudentName.DataBind();
            ccmbStudentName.InsertListItem(0, "---请选择---", "00000000-0000-0000-0000-000000000000");
        }
        protected void ccmbStudentName_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ctxtTelephone.Text = "";
            cgrdReleaseStudentTextbook.DoDataBind();
        }

        protected void ccmbStockName_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdReleaseStudentTextbook.DoDataBind();
        }
       
        protected void cgrdReleaseStudentTextbook_OnItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {               
                string storeCount = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StoreCount"].ToString();
                if (storeCount == "未入库")
                {                   
                    e.Item.ForeColor = Color.Red;//改变该行字体的颜色
                    //(e.Item.FindControl("chbTemplate") as CheckBox).Enabled = false; //禁用CheckBox              
                }
            }
        }
    }
}