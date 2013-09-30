using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface ITeacherService
    {
        /// <summary>
        /// 根据系教研室ID，取教师
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<Teacher> GetByDepartmentId(string departmentId);

        /// <summary>
        /// 根据教师ID，取单个教师
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        Teacher GetById(string teacherId);
    }
}
