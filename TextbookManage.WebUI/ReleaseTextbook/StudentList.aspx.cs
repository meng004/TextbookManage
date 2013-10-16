using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.WebUI.ReleaseClassBookService;

namespace TextbookManage.WebUI.ReleaseTextbook
{
    public partial class StudentList : USCTAMis.Web.WebControls.Page
    {

        #region Session Key

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

        #endregion

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cgrdStudentList.DoDataBind();
            }
        }
        #endregion

        #region CheckBox

        protected void cchkApplyToAll_CheckedChanged(object sender, EventArgs e)
        {
            //保存是否适用全部课程
            Session[_applyKey] = cchkApplyToAll.Checked;
        }
        #endregion

        #region Grid

        protected void cgrdStudentList_BeforeDataBind(object sender, EventArgs e)
        {
            var inventory = Session[_inveKey] as InventoryForReleaseClassView;
            if (inventory != null)
            {
                cgrdStudentList.DataSource = inventory.Students;
            }
        }

        protected void cchkAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
            cgrdStudentList.SetAllCheckControlState(chk.Checked);
        }
        #endregion

        #region 确定

        protected void btnOk_Click(object sender, EventArgs e)
        {
            var inventory = Session[_inveKey] as InventoryForReleaseClassView;

            if (inventory == null)
            {
                return;
            }
            //保持check状态
            cgrdStudentList.PersistCheckState<StudentView>();
            //保存学生
            IEnumerable<StudentView> students = cgrdStudentList.DataSource as IEnumerable<StudentView>;

            inventory.Students = students.ToArray();
            //写入session
            Session[_inveKey] = inventory;

            //保存是否适用全部课程
            Session[_applyKey] = cchkApplyToAll.Checked;
            //关闭并刷新主窗体
            USCTAMis.Web.WebClient.ScriptManager.ExecuteJs("CloseAndRebind();");

        }

        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //清空session
            Session.Remove(_applyKey);
            Session.Remove(_inveKey);
            //关闭自己
            USCTAMis.Web.WebClient.ScriptManager.ExecuteJs("CloseWindow();");
        }




    }
}