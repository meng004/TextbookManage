using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface ITeachingTaskService
    {
        /// <summary>
        /// 根据系教研室ID，取全部开课课程
        /// </summary>
        /// <param name="departmentId">系教研室ID</param>
        /// <param name="dataSignNum">数据标识编号</param>
        /// <param name="term">学年学期</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<Course> GetCourseByDepartmentId(string departmentId, string dataSignNum, string term);

        /// <summary>
        /// 根据课程ID，取教学任务
        /// </summary>
        /// <param name="courseId">课程ID</param>
        /// <param name="departmentId">系教研室ID</param>
        /// <param name="dataSignNum">数据标识编号</param>
        /// <param name="term">学年学期</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TeachingTask> GetByCourseId(string courseId, string departmentId, string dataSignNum, string term);

        /// <summary>
        /// 根据教学任务，取学生班级
        /// </summary>
        /// <param name="teachingTaskNum">教学班编号</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StudentClass> GetStudentClassById(string teachingTaskNum);
    }
}
