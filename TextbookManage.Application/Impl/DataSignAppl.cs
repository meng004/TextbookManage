using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.Models;

namespace TextbookManage.Applications.Impl
{
    public class DataSignAppl
    {

        #region 私有变量

        private readonly IDataSignRepository _repo = ServiceLocator.Current.GetInstance<IDataSignRepository>();

        #endregion

        #region 共有方法

        /// <summary>
        /// 全部数据标识
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataSign> GetAll()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// 由数据标识ID，取数据标识名称
        /// </summary>
        /// <param name="DataSignId"></param>
        /// <returns></returns>
        public string GetDataSignName(string DataSignId)
        {
            return _repo.First(t => t.DataSignId == DataSignId).Name;
        }
        #endregion

    }
}
