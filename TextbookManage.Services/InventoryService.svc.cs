using System;
using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“InventoryService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 InventoryService.svc 或 InventoryService.svc.cs，然后开始调试。
    public class InventoryService : IInventoryAppl
    {
        readonly IInventoryAppl _appl = ServiceLocator.Current.GetInstance<IInventoryAppl>();

        public IEnumerable<StorageView> GetStorages(string loginName)
        {
            return _appl.GetStorages(loginName);
        }

        public IEnumerable<TextbookView> GetTextbooksByName(string name, string isbn)
        {
            return _appl.GetTextbooksByName(name, isbn);
        }

        public InventoryView GetInventory(string storageId, string textbookId)
        {
            return _appl.GetInventory(storageId, textbookId);
        }

        public ResponseView SubmitInStock(InventoryView inventory, string instockCount, string loginName)
        {
            return _appl.SubmitInStock(inventory, instockCount, loginName);
        }

        public IEnumerable<StockRecordView> GetStockRecordsByDate(string storageId, string stockType, string beginDate, string endDate)
        {
            return _appl.GetStockRecordsByDate(storageId, stockType, beginDate, endDate);
        }

        public IEnumerable<StockRecordView> GetStockRecordsByTextbook(string storageId, string stockType, string textbookName, string isbn)
        {
            return _appl.GetStockRecordsByTextbook(storageId, stockType, textbookName, isbn);
        }
    }
}
