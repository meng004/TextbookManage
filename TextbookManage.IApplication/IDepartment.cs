using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IDepartment
    {
        /// <summary>
        /// 获取教研室列表
        /// </summary>
        /// <param name="schoolId">学院ID</param>
        /// <returns></returns>
        IEnumerable<DepartmentView> GetDepartmentListBySchoolId(string schoolId);
    }
}
