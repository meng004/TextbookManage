using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface IDepartmentService
    {
        /// <summary>
        /// 根据学院ID，取系教研室
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<Department> GetBySchoolId(string schoolId);

        /// <summary>
        /// 根据系教研室ID，取单个系教研室
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        Department GetById(string departmentId);
    }
}
