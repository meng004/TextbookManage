using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IDataSign
    {
        /// <summary>
        /// 获取数据标识列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataSignView> GetDataSignList();

        /// <summary>
        /// 取数据标识
        /// </summary>
        /// <param name="dataSignId"></param>
        /// <returns></returns>
        DataSignView GetDataSignById(string dataSignId);
    }
}
