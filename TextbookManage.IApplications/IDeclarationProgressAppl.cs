using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 申报进度
    /// </summary>
    [ServiceContract]
    public interface IDeclarationProgressAppl
    {
        /// <summary>
        /// 取数据标识
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DataSignView> GetDataSign();

        /// <summary>
        /// 由数据标识，取学院申报进度
        /// </summary>
        /// <param name="dataSignId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SchoolProgressView> GetSchoolProgress(string dataSignId);

        /// <summary>
        /// 由学院ID，获取教研室
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DepartmentView> GetDepartments(string schoolId);

        /// <summary>
        /// 由学院ID，取系教研室申报进度
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DepartmentProgressView> GetDepartmentProgress(string dataSignId, string departmentId);

    }
}
