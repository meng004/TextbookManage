using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{    
    [ServiceContract]
    public interface ISchoolService
    {
        /// <summary>
        /// 取全部学院
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<School> GetAll();

        /// <summary>
        /// 根据学院ID，取单个学院
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        School GetById(string schoolId);
    }
}
