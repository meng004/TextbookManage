using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IDeclaration : ISchool, IDepartment, ICourse, ITextbook, ITerm, IDataSign
    {
      
        #region 教学任务查询
  
        /// <summary>
        /// 获取教学任务列表
        /// </summary>
        /// <param name="courseId">课程ID</param>
        /// <param name="departmentId">教研室ID</param>
        /// <param name="dataSignNum">数据标识</param>
        /// <returns></returns>
        IEnumerable<TeachingTaskView> GetTeachingTasksByCourseIdAndDepartmentId(string courseId, string departmentId, string dataSignNum);

        #endregion

        #region 弹窗

        /// <summary>
        /// 获取行政班列表
        /// </summary>
        /// <param name="teachingClassNum">教学班编号</param>
        /// <returns></returns>
        IEnumerable<StudentClassView> GetProfessinalClassList(string teachingClassNum);

        /// <summary>
        /// 获取回告
        /// </summary>
        /// <param name="declarationID">用书申报ID</param>
        /// <returns></returns>
        FeedbackView GetFeedbackByDeclarationId(string declarationId);

        /// <summary>
        /// 获取审核记录
        /// </summary>
        /// <param name="declarationID">用书申报ID</param>
        /// <returns></returns>
        IEnumerable<ApprovalView> GetApprovalDeclarationsByDeclarationId(string declarationId);

        /// <summary>
        /// 获取已申报的学生用书信息
        /// </summary>
        /// <param name="teachingClassNum"></param>
        /// <returns></returns>
        IEnumerable<DeclarationView> GetDeclarationsByTeachingClassNum(string teachingClassNum);

        #endregion

        #region 提交用书申报
        
        /// <summary>
        /// 提交学生用书申报
        /// </summary>
        /// <param name="teachingTaskViews">教学任务</param>
        /// <param name="textbookView">教材</param>
        /// <param name="housePhone">家庭电话</param>
        /// <param name="mobile">移动电话</param>
        /// <param name="declarationCount">申报数量</param>
        /// <param name="message">返回操作结果消息</param>
        /// <returns></returns>
        void SubmitDeclarationForStudent(IEnumerable<TeachingTaskView> teachingTaskViews, TextbookView textbookView, string homePhone, string mobile, string declarationCount, ref string message);


        /// <summary>
        /// 提交教师用书申报
        /// </summary>
        /// <param name="teachingTaskViews">教学任务</param>
        /// <param name="textbookView">教材</param>
        /// <param name="housePhone">家庭电话</param>
        /// <param name="mobile">移动电话</param>
        /// <param name="declarationCount">申报数量</param>
        /// <param name="message">返回操作结果消息</param>
        /// <returns></returns>
        void SubmitDeclarationForTeacher(IEnumerable<TeachingTaskView> teachingTaskViews, TextbookView textbookView, string homePhone, string mobile, string declarationCount, ref string message);
         
        #endregion

        #region 查询用书申报
      
        /// <summary>
        /// 获取领用人类型
        /// </summary>
        /// <returns></returns>
         IEnumerable<RecipientTypeView> GetRecipientTypeList();

        /// <summary>
        /// 获取用书申报
        /// </summary>
        /// <param name="term">学年学期</param>
        /// <param name="courseId">课程ID</param>
        /// <param name="departmentId">教研室ID</param>
        /// <param name="recipientTypeId">领用人类型ID</param>
        /// <returns></returns>
        IEnumerable<DeclarationView> GetDeclarations(string term, string courseId, string departmentId, string recipientTypeId);

        /// <summary>
        /// 计算教学任务学生人数
        /// </summary>
        /// <param name="views">教学班</param>
        /// <returns></returns>
        //string CalculateDeclarationCount(IEnumerable<TeachingTaskView> views);

         #endregion

    }
}
