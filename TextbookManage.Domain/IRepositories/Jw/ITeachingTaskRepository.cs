namespace TextbookManage.Domain.IRepositories.Jw
{

    using System.Collections.Generic;
    using TextbookManage.Domain.Models;

    public interface ITeachingTaskRepository : IRepository<TeachingTask>
    {
        /// <summary>
        /// 根据开课教研室ID、数据标识、学年学期
        /// 取课程
        /// </summary>
        /// <param name="departmentId">系教研室ID</param>
        /// <param name="dataSignNum">教学班编号</param>
        /// <param name="term">学年学期</param>
        /// <returns></returns>
        IEnumerable<Course> GetCourseByDepartmentId(System.Guid departmentId, string dataSignNum, string term);

        /// <summary>
        /// 根据教学班编号
        /// 取学生班级ID
        /// </summary>
        /// <param name="teachingTaskNum"></param>
        /// <returns></returns>
        IEnumerable<System.Guid> GetStudentClassIdById(string teachingTaskNum);
    }
}
