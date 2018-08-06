using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_20
{
    public partial class CourseTypeDelete : System.Web.UI.Page
    {
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_20.ICourseType CourseTypeBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_20.CourseTypeBLL();
        /// <summary>
        /// 删除教材类型pageload事件
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cdlstCourseType.DataSource = CourseTypeBLL.Fn_GetCourseTypeList();
                cdlstCourseType.DataBind();
            }
        }

        #region
        /// <summary>
        /// 删除教材类型删除按钮点击事件
        /// </summary>
        public void cbtnDelete_Click(object sender, EventArgs e)
        {
           string checkValue =CourseTypeBLL.Fn_DeleteCourseType(cdlstCourseType.SelectedValue);//获取到BLL删除函数返回的消息
           if ("√" == checkValue.Substring(0, 1))//当消息首字符为√时，删除成功，弹窗提示用户，重新绑定下拉控件的数据源
           {
               CPMis.Web.WebClient.ScriptManager.Alert("√ 教材类型删除成功!");
               cdlstCourseType.DataSource = CourseTypeBLL.Fn_GetCourseTypeList();
               cdlstCourseType.DataBind();
           }
           else
           {
               CPMis.Web.WebClient.ScriptManager.Alert("× 教材类型删除失败!");
           }
        }
        /// <summary>
        /// 删除教材类型取消按钮点击事件，不执行任何操作
        /// </summary>
        public void cbtnCancle_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}