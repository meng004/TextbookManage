using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface IDataSignService
    {
        /// <summary>
        /// 取全部
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DataSign> GetAll();

        /// <summary>
        /// 根据数据标识编号，取单个
        /// </summary>
        /// <param name="dataSignNum"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        DataSign GetById(string dataSignNum);

    }
}
