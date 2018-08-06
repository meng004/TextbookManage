using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_20
{
    public partial class CourseTypeUpdate : System.Web.UI.Page
    {
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_20.ICourseType CourseTypeBLL =new CPMis.BLL.Tb_Maintain.Tb_Maintain_20.CourseTypeBLL();

        /// <summary>
        /// 修改课程类型pageload事件
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cdlstCourseType.DataSource = CourseTypeBLL.Fn_GetCourseTypeList();//课程类型下拉控件获取数据源
                cdlstCourseType.DataBind();                                       //下拉控件绑定数据源
                ctxtCourseType.Text = cdlstCourseType.SelectedText;               //将修改控件的text设置为下拉控件当前的选择项
            }
        }

        /// <summary>
        /// 新增课程类型下拉控件IndexChange事件
        /// </summary>
        #region
        public void cdlstCourseType_IndexChanged(object sender, EventArgs e)
        {
            ctxtCourseType.Text = cdlstCourseType.SelectedText;//将下拉控件和修改控件的文本显示信息同步
        }

        /// <summary>
        /// 修改课程类型保存按钮点击事件
        /// </summary>
        public void cbtnSave_click(object sender, EventArgs e)
        {
            if (ctxtCourseType.Text != cdlstCourseType.SelectedText)
            {
                string courseType = ctxtCourseType.Text;
                if ("" == courseType)
                {
                    CPMis.Web.WebClient.ScriptManager.Alert("获取到的字符为空串，请输入正确的课程类型!");
                    ctxtCourseType.Text = cdlstCourseType.SelectedText;
                }
                else
                {
                    Regex TypeRegex = new Regex(@"^[a-zA-Z0-9\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);//正在表达式判断输入的是否合法;
                    if (TypeRegex.IsMatch(courseType))
                    {
                        bool check = CourseTypeBLL.Fn_GetCourseTypeChecked(courseType);          //声明dataset变量ds用于接收DAL查询函数返回的dataset
                        if (false == check)  //当for循环判断为不存在时，允许插入，调用插入接口
                        {
                            string checkValue = CourseTypeBLL.Fn_UpdateCourseType(courseType, cdlstCourseType.SelectedValue);//获取到BLL层的新增函数的返回的消息
                            if ("√" == checkValue.Substring(0, 1))//当消息首字符为√时，插入成功，弹窗提示用户
                            {
                                CPMis.Web.WebClient.ScriptManager.Alert("√ 课程类型信息更新成功!");

                            }
                            else
                            {
                                CPMis.Web.WebClient.ScriptManager.Alert("× 课程类型信息更新失败!");
                            }
                            cdlstCourseType.DataSource = CourseTypeBLL.Fn_GetCourseTypeList();
                            cdlstCourseType.DataBind();
                            ctxtCourseType.Text = courseType;
                            cdlstCourseType.SelectedText = courseType;

                        }
                        else     //当for循环判断为存在时，不允许插入，弹窗提示用户，将新增控件中的text置空
                        {
                            CPMis.Web.WebClient.ScriptManager.Alert("该课程类型已经存在，请重新输入!");
                            ctxtCourseType.Text = cdlstCourseType.SelectedText;
                        }
                    }
                    else
                    {
                        CPMis.Web.WebClient.ScriptManager.Alert("课程类型格式错误，请输入正确的课程类型!");
                        ctxtCourseType.Text = cdlstCourseType.SelectedText;
                    }
                }
            }
        }

        /// <summary>
        /// 修改课程类型取消按钮点击事件，将文本栏置原始状态
        /// </summary>
        public void cbtnCancle_click(object sender, EventArgs e)
        {
            ctxtCourseType.Text = cdlstCourseType.SelectedText;
        }
        #endregion
    }
}