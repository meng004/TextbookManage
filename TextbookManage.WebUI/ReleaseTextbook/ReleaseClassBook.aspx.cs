using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.ReleaseClassBookService;

namespace TextbookManage.WebUI.ReleaseTextbook
{
    public partial class ReleaseClassBook : USCTAMis.Web.WebControls.Page
    {

        #region 属性

        readonly string _loginName = HttpContext.Current.User.Identity.Name;
        //readonly string _loginName = "dongxb";

        /// <summary>
        /// Session key
        /// 发放计划
        /// </summary>
        private const string _inveKey = "Inventory";
        /// <summary>
        /// Session key
        /// 是否应用全部发放计划
        /// </summary>
        private const string _applyKey = "ApplyToAll";
        /// <summary>
        /// 数据集键值
        /// </summary>
        private const string _dataSetKey = "ReportForClassBook";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ccmbSchool.DataBind();
                ccmbStorage.DataBind();
            }
        }

        #region Ajax

        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            var argu = e.Argument;
            switch (argu)
            {
                case "update":
                    UpdateInventory();
                    break;
                default:
                    cgrdInventory.DoDataBind();
                    break;
            }
        }

        private void UpdateInventory()
        {
            var inventory = Session[_inveKey] as InventoryForReleaseClassView;
            bool applyToAll;

            if (inventory == null)
            {
                return;
            }
            //取是否适用全部课程
            if (Session[_applyKey] != null)
                applyToAll = (bool)Session[_applyKey];
            else
                applyToAll = false;

            //取出发放计划
            var inventories = cgrdInventory.DataSource as InventoryForReleaseClassView[];
            //取出学生id
            var ids = inventory.Students.Select(t => t.StudentId);

            IEnumerable<InventoryForReleaseClassView> views;

            //适用全部课程
            if (applyToAll)
            {
                //取全部发放计划
                views = inventories;
            }
            else
            {
                views = inventories.Where(t => t.InventoryId == inventory.InventoryId);
            }

            foreach (var inve in views)
            {
                var stus = inve.Students.Where(t => ids.Contains(t.StudentId));
                //设置学生的选中标志
                foreach (var stu in stus)
                {
                    var student = inventory.Students.First(t => t.StudentId == stu.StudentId);
                    if (student != null)
                    {
                        stu.CheckFlag = student.CheckFlag;
                    }
                }

                //重新计算发放数量
                //人均数 * 应发放人数
                var count = inve.Students.Count(t => t.CheckFlag == true);
                inve.ReleaseCount = inve.AverageCount * count;
            }


            if (applyToAll)
            {
                //更新整个计划
                inventories = views.ToArray();
            }
            else
            {
                //只更新单个计划
                var index = Array.FindIndex(inventories, t => t.InventoryId == inventory.InventoryId);
                inventories.SetValue(views.First(), index);
            }

            //重新绑定数据
            cgrdInventory.DataSource = inventories;
            cgrdInventory.DataBind();
            //注销session
            Session.Remove(_applyKey);
            Session.Remove(_inveKey);

        }

        #endregion

        #region 学院

        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            using (ReleaseClassBookApplClient client = new ReleaseClassBookApplClient())
            {
                ccmbSchool.DataSource = client.GetSchoolByLoginName(_loginName);
            }
        }

        protected void ccmbSchool_DataBound(object sender, EventArgs e)
        {
            ccmbGrade.DataBind();
        }

        protected void ccmbSchool_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ccmbGrade.DataBind();
        }
        #endregion

        #region 年级

        protected void ccmbGrade_BeforeDataBind(object sender, EventArgs e)
        {
            using (var client = new ReleaseClassBookApplClient())
            {
                var schoolId = ccmbSchool.SelectedValue;
                ccmbGrade.DataSource = client.GetGradeBySchoolId(schoolId);
            }
        }

        protected void ccmbGrade_DataBound(object sender, EventArgs e)
        {
            ccmbProfessionalClass.DataBind();
        }

        protected void ccmbGrade_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ccmbProfessionalClass.DataBind();
        }
        #endregion

        #region 班级

        protected void ccmbProfessionalClass_BeforeDataBind(object sender, EventArgs e)
        {
            using (var client = new ReleaseClassBookApplClient())
            {
                var schoolId = ccmbSchool.SelectedValue;
                var grade = ccmbGrade.SelectedValue;
                ccmbProfessionalClass.DataSource = client.GetClassBySchoolId(schoolId, grade);
            }
        }

        protected void ccmbProfessionalClass_DataBound(object sender, EventArgs e)
        {
            cgrdInventory.DoDataBind();
        }

        protected void ccmbProfessionalClass_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdInventory.DoDataBind();
        }
        #endregion

        #region 仓库

        protected void ccmbStorage_BeforeDataBind(object sender, EventArgs e)
        {
            using (var client = new ReleaseClassBookApplClient())
            {
                ccmbStorage.DataSource = client.GetStorages(_loginName);
            }
        }

        protected void ccmbStorage_DataBound(object sender, EventArgs e)
        {
            cgrdInventory.DoDataBind();
        }

        protected void ccmbStorage_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdInventory.DoDataBind();
        }
        #endregion

        #region 查询

        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdInventory.DoDataBind();
        }
        #endregion

        #region 学号检测

        protected void lbtnCheck1_Click(object sender, EventArgs e)
        {

            var num = ctxtStudentNum1.Text.Trim();

            ctxtStudentName1.Text = GetStudentName(num);

        }

        protected void lbtnCheck2_Click(object sender, EventArgs e)
        {
            var num = ctxtStudentNum2.Text.Trim();

            ctxtStudentName2.Text = GetStudentName(num);
        }

        private string GetStudentName(string studentNum)
        {
            if (string.IsNullOrWhiteSpace(studentNum))
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请输入学号");
                return string.Empty;
            }
            using (var client = new ReleaseClassBookApplClient())
            {
                var result = client.GetStudentNameByStudentNum(studentNum);
                if (result.IsSuccess)
                {
                    return result.Message;
                }
                else
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);
                    return string.Empty;
                }
            }
        }

        #endregion

        #region 发放

        protected void cbtnRelease_Click(object sender, EventArgs e)
        {
            //是否通过验证
            if (IsValid)
            {
                using (var client = new ReleaseClassBookApplClient())
                {
                    //取选中的教材
                    cgrdInventory.PersistCheckState<InventoryForReleaseClassView>();
                    IEnumerable<InventoryForReleaseClassView> inventoryViews = cgrdInventory.GetGridCheckedDataList<InventoryForReleaseClassView>();
                    if (inventoryViews.Count() > 0)
                    {
                        //取发放信息
                        var releaseView = GetForm();
                        //发放教材
                        var result = client.SubmitReleaseClass(inventoryViews.ToArray(), releaseView);

                        USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);

                        cgrdInventory.DoDataBind();
                    }
                    else
                    {
                        USCTAMis.Web.WebClient.ScriptManager.Alert("请选中待发放的教材");
                    }
                }
            }

        }

        protected void cbtnRelease_AfterClick(object sender, EventArgs e)
        {
            cgrdInventory.DoDataBind();
        }

        private ReleaseBookForClassView GetForm()
        {
            return new ReleaseBookForClassView
            {
                Operator = _loginName,
                RecipientName = ctxtStudentName1.Text.Trim(),
                RecipientTelephone = ctxtTelephone1.Text.Trim(),
                Recipient2Name = ctxtStudentName2.Text.Trim(),
                Recipient2Telephone = ctxtTelephone2.Text.Trim()
            };
        }
        #endregion

        #region 打印

        protected void cbtnPrint_Click(object sender, EventArgs e)
        {
            //取数据集
            cgrdInventory.PersistCheckState<InventoryForReleaseClassView>();

            var dataset = cgrdInventory.GetGridCheckedDataList<InventoryForReleaseClassView>();
            if (dataset==null)
            {
                return;
            }
            //写session
            Session[_dataSetKey] = dataset;
        }

        protected void cbtnPrint_AfterClick(object sender, EventArgs e)
        {
            var schoolName = ccmbSchool.Text;
            var className = ccmbProfessionalClass.Text;
            if (string.IsNullOrWhiteSpace(schoolName)||string.IsNullOrWhiteSpace(className))
            {
                return;
            }
            //打开报表
            //var js = string.Format("OnRequestPrint('{0}','{1}');", schoolName, className);
            var path = string.Format("../ReportViewUI/ReportForClassBook.aspx?SchoolName={0}&ClassName={1}", schoolName, className);
            USCTAMis.Web.WebClient.ScriptManager.OpenWindow(path, 400, 800);

            //USCTAMis.Web.WebClient.ScriptManager.ExecuteJs(string.Format("Sys.Application.add_load(OnRequestPrint('{0}','{1}'));", schoolName, className));

        }
        #endregion

        #region Grid

        protected void cchkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
            cgrdInventory.SetAllCheckControlState(chk.Checked);
        }

        protected void cgrdInventory_BeforeDataBind(object sender, EventArgs e)
        {
            using (var client = new ReleaseClassBookApplClient())
            {
                var classId = ccmbProfessionalClass.SelectedValue;
                var storageId = ccmbStorage.SelectedValue;
                //避免有空值
                if (string.IsNullOrWhiteSpace(classId) || string.IsNullOrWhiteSpace(storageId))
                {
                    return;
                }
                cgrdInventory.DataSource = client.GetInventoriesByClassId(classId, storageId);
            }
        }

        /// <summary>
        /// 检测库存数量
        /// 库存不足，显示红色，且禁止发放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdInventory_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is Telerik.Web.UI.GridDataItem)
            {
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                var inventory = cgrdInventory.GetData<InventoryForReleaseClassView>(item.ItemIndex);
                var checkbox = item.FindControl(cgrdInventory.CheckControlID) as USCTAMis.Web.WebControls.UTMisCheckBox;

                //发放数量小于库存数，可发放，绿色；否则不允许发放，红色
                if (inventory.ReleaseCount <= inventory.InventoryCount)
                {
                    item["InventoryCount"].BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    item["InventoryCount"].BackColor = System.Drawing.Color.Salmon;
                    checkbox.Enabled = false;
                }

                //发放数量 大于 申报数量，红色
                if (inventory.ReleaseCount>inventory.DeclarationCount)
                {
                    item["ReleaseCount"].BackColor = System.Drawing.Color.Salmon;
                }
            }


        }

        protected void cgrdInventory_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.Item is Telerik.Web.UI.GridDataItem)
            {
                //对属性SchoolId赋值，用于跨页面传值
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                //取出数据，写session
                Session[_inveKey] = cgrdInventory.GetData<InventoryForReleaseClassView>(item.ItemIndex);

                //弹窗
                USCTAMis.Web.WebClient.ScriptManager.ExecuteJs("OnRequestStudent();");
            }
        }

        #endregion



    }
}