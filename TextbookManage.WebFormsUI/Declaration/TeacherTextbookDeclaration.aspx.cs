using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//添加引用
using TextbookManage.Application.Interface;
using TextbookManage.Application.Factory;

using USCTAMis.Web.WebControls;
using Telerik.Web.UI;
using TextbookManage.Application.ViewModel;

namespace TextbookManage.WebUI.Declaration
{
    public partial class TeacherTextbookDeclaration : USCTAMis.Web.WebControls.Page
    {

        #region 字段与构造函数

        //获取登陆用户
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        readonly string _loginName = "46010";
        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;
                
        //创建申报实例
        IDeclaration _declaration;

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _declaration = new ApplicationFactory(_loginName, _ipAddress).CreateDeclarationApplication();
            if (!IsPostBack)
            {
                ccmbSchool.DoDataBind();
            }
        }
        #endregion

        #region 学院

        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            //根据用户ID取学院列表
            ccmbSchool.DataSource = _declaration.GetSchoolList();
        }

        /// <summary>
        /// ccmbSchool改变索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccmbDepartment.DoDataBind();
        }
        #endregion

        #region 教研室

        protected void ccmbDepartment_BeforeDataBind(object sender, EventArgs e)
        {
            //根据学院ID和用户名获取教研室列表
            ccmbDepartment.DataSource = _declaration.GetDepartmentListBySchoolId(ccmbSchool.SelectedValue);
        }


        /// <summary>
        /// ccmbDepartment改变索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ccmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccmbCourse.DoDataBind();
        }
        #endregion

        #region 课程

        protected void ccmbCourse_BeforeDataBind(object sender, EventArgs e)
        {
            //根据教研室ID获取课程列表
            ccmbCourse.DataSource = _declaration.GetCourseListByDepartmentId(ccmbDepartment.SelectedValue);
        }

        protected void ccmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cgrdTeachingClassList.DoDataBind();
        }
        #endregion

        #region 教学班列表数据绑定

        /// <summary>
        /// 选教学班查询按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdTeachingClassList.DoDataBind();
        }

        /// <summary>
        /// 选教学班数据绑定前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdTeachingClassList_BeforeDataBind(object sender, EventArgs e)
        {
            //根据课程ID和教研室Id获取教学任务列表
            cgrdTeachingClassList.DataSource = _declaration.GetTeachingTasksByCourseIdAndDepartmentId(ccmbCourse.SelectedValue, ccmbDepartment.SelectedValue);
        }

        /// <summary>
        /// 单选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkTeachingClass_CheckedChanged(object sender, EventArgs e)
        {
            //保存状态
            UTMisCheckBox chk = sender as UTMisCheckBox;
            bool checkState = chk.Checked;
            GridDataItem item = chk.Parent.Parent as GridDataItem;
            //全部Unchecked
            cgrdTeachingClassList.SetAllCheckControlState(false);
            //对当前数据进行Check
            cgrdTeachingClassList.SetCheckControlState(checkState, item.ItemIndex);
        }

        #endregion

        #region 教材数据绑定

        /// <summary>
        /// 选教材查询按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnQueryBook_Click(object sender, EventArgs e)
        {
            cgrdTextbookList.DoDataBind();
        }

        /// <summary>
        /// 选教材Grid绑定数据前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdTextbookList_BeforeDataBind(object sender, EventArgs e)
        {
            string textBookName = ctxtTextBookName.Text.Trim();
            string isbn = ctxtISBN.Text.Trim();
            cgrdTextbookList.DataSource = _declaration.GetTextbooksByTextbookNameOrISBN(textBookName, isbn);
        }

        /// <summary>
        /// 实现单选功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkTextbook_CheckedChanged(object sender, EventArgs e)
        {
            //保存状态
            UTMisCheckBox chk = sender as UTMisCheckBox;
            bool checkState = chk.Checked;
            GridDataItem item = chk.Parent.Parent as GridDataItem;
            //全部Unchecked
            cgrdTextbookList.SetAllCheckControlState(false);
            //对当前数据进行Check
            cgrdTextbookList.SetCheckControlState(checkState, item.ItemIndex);
        }

        #endregion

        #region 保存申报信息

        /// <summary>
        /// 保存申报信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnConfirm_Click(object sender, EventArgs e)
        {
            //检查申报信息是否合法
            if (CheckDeclarationInfo())
            {
                //取选中教学任务
                cgrdTeachingClassList.PersistCheckState<TeachingTaskView>();
                var views = cgrdTeachingClassList.GetAllCheckedDataList<TeachingTaskView>();
                //取教材
                cgrdTextbookList.PersistCheckState<TextbookView>();
                var books = cgrdTextbookList.GetAllCheckedDataList<TextbookView>();
                if (views.Count > 0 || books.Count > 0)
                {
                    var message = string.Empty;
                    _declaration.SubmitDeclarationForTeacher(views, books.First(), ctxtHomePhone.Text.Trim(), ctxtMobile.Text.Trim(), ctxtAmount.Text.Trim(), ref message);
                    USCTAMis.Web.WebClient.ScriptManager.Alert(message);
                }
                else
                {
                    USCTAMis.Web.WebClient.ScriptManager.Alert("请选择教学任务或教材");
                }
            }
            else
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请填写完整信息！");
            }
        }

        /// <summary>
        /// 点击后，刷新父窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnConfirm_AfterClick(object sender, EventArgs e)
        {
            USCTAMis.Web.WebClient.ScriptManager.ExecuteJs("Sys.Application.add_load(CloseAndRebind);");
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 检测申报信息的合法性
        /// </summary>
        /// <returns></returns>
        protected bool CheckDeclarationInfo()
        {
            if (string.IsNullOrWhiteSpace(ctxtAmount.Text) || string.IsNullOrWhiteSpace(ctxtMobile.Text) || string.IsNullOrWhiteSpace(ctxtHomePhone.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion



    }
}