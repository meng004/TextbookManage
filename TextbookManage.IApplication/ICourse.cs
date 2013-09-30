using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface ICourse
    {
        /// <summary>
        /// 通过教研室Id获取课程列表
        /// </summary>
        /// <param name="departmentId">教研室ID</param>
        /// <returns></returns>
        IEnumerable<CourseView> GetCourseListByDepartmentId(string departmentId);
    }
}
