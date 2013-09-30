using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface ISchool
    {
        /// <summary>
        /// 获取学院列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<SchoolView> GetSchoolList();
    }
}
