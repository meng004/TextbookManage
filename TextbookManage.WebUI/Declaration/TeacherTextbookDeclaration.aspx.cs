using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//添加引用
using USCTAMis.Web.WebControls;
using Telerik.Web.UI;
using TextbookManage.WebUI.DeclarationService;

namespace TextbookManage.WebUI.Declaration
{
    public partial class TeacherTextbookDeclaration : USCTAMis.Web.WebControls.Page
    {

        #region 字段与构造函数

        //获取登陆用户
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        private readonly string _loginName = HttpContext.Current.User.Identity.Name;

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ccmbSchool.DoDataBind();
            }
        }
        #endregion

        #region 学院

        protected void ccmbSchool_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationApplClient client = new DeclarationApplClient())
            {
                //根据用户ID取学院列表
                ccmbSchool.DataSource = client.GetSchoolByLoginName(_loginName);
            }

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
            using (DeclarationApplClient app = new DeclarationApplClient())
            {
                //根据学院ID和用户名获取教研室列表
                ccmbDepartment.DataSource = app.GetDepartmentByLoginName(_loginName, ccmbSchool.SelectedValue);
            }

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
            using (DeclarationApplClient app = new DeclarationApplClient())
            {
                //根据教研室ID获取课程列表
                ccmbCourse.DataSource = app.GetCourseByDepartmentId(ccmbDepartment.SelectedValue);
            }

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
            using (DeclarationApplClient app = new DeclarationApplClient())
            {
                //根据课程ID和教研室Id获取教学任务列表
                cgrdTeachingClassList.DataSource = app.GetTeachingTaskByDepartmentId(ccmbDepartment.SelectedValue, ccmbCourse.SelectedValue);

            }
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
            if (string.IsNullOrWhiteSpace(textBookName) && string.IsNullOrWhiteSpace(isbn))
            {
                return;
            }
            using (DeclarationApplClient app = new DeclarationApplClient())
            {
                cgrdTextbookList.DataSource = app.GetTextbooksByName(textBookName, isbn);
            }
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
                cgrdTextbookList.PersistCheckState<TextbookForDeclarationView>();
                var books = cgrdTextbookList.GetAllCheckedDataList<TextbookForDeclarationView>();
                if (views.Count > 0 || books.Count > 0)
                {
                    using (DeclarationApplClient app = new DeclarationApplClient())
                    {
                        var view = GetView(views, books);
                        var result = app.SubmitTeacherDeclaration(view);
                        USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);                        
                    }
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

        /// <summary>
        /// 创建申报view
        /// </summary>
        /// <param name="teachingTaskViews"></param>
        /// <param name="textbookViews"></param>
        /// <returns></returns>
        private DeclarationView GetView(IList<TeachingTaskView> teachingTaskViews, IList<TextbookForDeclarationView> textbookViews)
        {
            var notNeedTextbook = chkIsSelfCompile.Checked;
            if (notNeedTextbook)
            {
                return new DeclarationView
                {
                    TeachingTaskNums = teachingTaskViews.Select(t => t.TeachingTaskNum).ToArray(),
                    TextbookId = string.Empty,
                    Declarant = _loginName,
                    Mobile = ctxtMobile.Text.Trim(),
                    Telephone = ctxtHomePhone.Text.Trim(),
                    DeclarationCount = ctxtAmount.Text.Trim(),
                    NotNeedTextbook = chkIsSelfCompile.Checked
                };
            }
            else
            {
                return new DeclarationView
                {
                    TeachingTaskNums = teachingTaskViews.Select(t => t.TeachingTaskNum).ToArray(),
                    TextbookId = textbookViews.First().TextbookId,
                    Declarant = _loginName,
                    Mobile = ctxtMobile.Text.Trim(),
                    Telephone = ctxtHomePhone.Text.Trim(),
                    DeclarationCount = ctxtAmount.Text.Trim(),
                    NotNeedTextbook = chkIsSelfCompile.Checked
                };
            }
        }

        #endregion

        protected void chkIsSelfCompile_BeforeCheckedChange(object sender, EventArgs e)
        {
            if (chkIsSelfCompile.Checked)
            {
                cbtnConfirm.CausesValidation = false;
                ctxtAmount.Text = "0";
                ctxtAmount.ReadOnly = true;
                ctxtAmount.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                cbtnConfirm.CausesValidation = true;
                ctxtAmount.Text = "1";
                ctxtAmount.ReadOnly = false;
                ctxtAmount.BackColor = System.Drawing.Color.White;
            }
        }

        protected void cbtnConfirm_AfterClick(object sender, EventArgs e)
        {
            USCTAMis.Web.WebClient.ScriptManager.ExecuteJs("Sys.Application.add_load(CloseAndRebind);");
        }

    }
}