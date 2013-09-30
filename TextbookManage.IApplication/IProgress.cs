using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IProgress : ITerm, IDataSign
    {

        #region 学院申报进度

        /// <summary>
        /// 获取学院申报进度
        /// </summary>
        /// <param name="yearTerm">学年学期</param>
        /// <param name="dataSignId">数据标识</param>
        /// <returns></returns>
        IEnumerable<SchoolProgressView> GetSchoolProgress(string yearTerm, string dataSignId);
        #endregion

        #region 教研室申报进度

        /// <summary>
        /// 获取教研室申报进度
        /// </summary>
        /// <param name="yearTerm">学年学期</param>
        /// <param name="dataSignId">数据标识</param>
        /// <param name="schoolId">学院ID</param>
        /// <returns></returns>
        IEnumerable<DepartmentProgressView> GetDepartmentProgress(string yearTerm, string dataSignId, string schoolId);

        #endregion
    }
}
