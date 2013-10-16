using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.ViewModels;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 创建者：陈海宾
    /// </summary>
    [ServiceContract]
    public interface IInventoryAppl
    {
        /// <summary>
        /// 根据书商ID获得该书商拥有的所有仓库
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StorageView> GetStorages(string loginName);

        /// <summary>
        /// 由教材名称、ISBN，取教材
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TextbookView> GetTextbooksByName(string name, string isbn);

        /// <summary>
        /// 由仓库ID、教材ID，取库存信息
        /// </summary>
        /// <param name="storageId"></param>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        InventoryView GetInventory(string storageId, string textbookId);

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="inventory"></param>        
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitInStock(InventoryView inventory, string instockCount, string loginName);

        /// <summary>
        /// 按时间查询出入库记录
        /// </summary>
        /// <param name="storageId"></param>
        /// <param name="stockType"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StockRecordView> GetStockRecordsByDate(string storageId, string stockType, string beginDate, string endDate);

        /// <summary>
        /// 按教材查询出入库记录
        /// </summary>
        /// <param name="storageId"></param>
        /// <param name="stockType"></param>
        /// <param name="textbookName"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StockRecordView> GetStockRecordsByTextbook(string storageId, string stockType, string textbookName, string isbn);
    }
}
