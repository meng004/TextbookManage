using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface ITermService
    {
        /// <summary>
        /// 取全部
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<string> GetAll();

        /// <summary>
        /// 取当前学年学期
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        string GetCurrent();
    }
}
