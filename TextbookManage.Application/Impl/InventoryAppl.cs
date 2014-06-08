using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Domain.Models;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;


namespace TextbookManage.Applications.Impl
{
    public class InventoryAppl : IInventoryAppl
    {

        #region 私有变量
        private readonly ITypeAdapter _adapter;
        private readonly IStorageRepository _storageRepo;
        private readonly IInventoryRepository _inventoryRepo;
        private readonly ITextbookRepository _textbookRepo;
        #endregion

        #region 构造函数

        public InventoryAppl(ITypeAdapter adapter,
                       IStorageRepository storage,
                     IInventoryRepository inventory,
                      ITextbookRepository textbook)
        {
            _adapter = adapter;
            _storageRepo = storage;
            _inventoryRepo = inventory;
            _textbookRepo = textbook;
        }
        #endregion

        #region 实现接口

        public IEnumerable<StorageView> GetStorages(string loginName)
        {
            var storages = new StorageAppl(_adapter, _storageRepo).GetByLoginName(loginName);

            return storages;
        }

        public IEnumerable<TextbookView> GetTextbooksByName(string name, string isbn)
        {

            IEnumerable<Textbook> models = new List<Textbook>();

            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                }
                else
                {
                    models = _textbookRepo.Find(t => t.Isbn.Contains(isbn));
                }
            }
            else
            {
                models = _textbookRepo.Find(t => t.Name.Contains(name));
            }
            return _adapter.Adapt<TextbookView>(models);
        }

        public InventoryView GetInventory(string storageId, string textbookId)
        {
            var storId = storageId.ConvertToGuid();
            var textId = textbookId.ConvertToGuid();

            var inventory = _inventoryRepo.First(t =>
                t.Storage_Id == storId &&
                t.Textbook_Id == textId
                );

            //未入库
            if (inventory == null)
            {
                var book = _textbookRepo.First(t => t.ID == textId);

                var inve = _adapter.Adapt<InventoryView>(book);
                inve.StorageId = storageId;

                return inve;
            }
            else
            {
                return _adapter.Adapt<InventoryView>(inventory);
            }

        }

        public ResponseView SubmitInStock(InventoryView inventory, string instockCount, string loginName)
        {
            var count = instockCount.ConvertToInt();
            var person = new TbmisUserAppl(loginName).GetUser().TbmisUserName;
            var inve = _adapter.Adapt<Inventory>(inventory);
            var inveNew = new Inventory();
            //var inveNew = inve;
            var repo = ServiceLocator.Current.GetInstance<IInventoryRepository>();
            var result = new ResponseView();

            //是否已存在库存
            if (inve.ID != null && inve.ID != Guid.Empty)
            {
                //取出库存
                inveNew = repo.First(t => t.ID == inve.ID);
                //更新架位号
                inveNew.ShelfNumber = inve.ShelfNumber;
            }
            else
            {
                inveNew = inve;
            }

            //修改库存数量
            inveNew.InventoryCount += count;
            //创建库存异动记录
            InventoryService.CreateStockRecord<InStockRecord>(inveNew, person, count);

            try
            {
                if (inveNew.ID == null || inve.ID == Guid.Empty)
                {
                    repo.Add(inveNew);
                }
                else
                {
                    repo.Modify(inveNew);
                }

                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "入库操作失败";
                return result;
            }
        }

        public IEnumerable<StockRecordView> GetStockRecordsByDate(string storageId, string stockType, string beginDate, string endDate)
        {
            var id = storageId.ConvertToGuid();
            var type = stockType.ConvertToBool();
            var begin = beginDate.ConvertToDateTime();
            var end = endDate.ConvertToDateTime();

            IEnumerable<StockRecord> records = new List<StockRecord>();

            if (type)
            {
                records = GetInStockRecordsByDate(id, begin, end);
            }
            else
            {
                records = GetOutStockRecordsByDate(id, begin, end);
            }

            return _adapter.Adapt<StockRecordView>(records);
        }

        public IEnumerable<StockRecordView> GetStockRecordsByTextbook(string storageId, string stockType, string textbookName, string isbn)
        {
            var id = storageId.ConvertToGuid();
            var type = stockType.ConvertToBool();
            IEnumerable<StockRecord> records = new List<StockRecord>();

            if (type)
            {
                records = GetInStockRecordsByTextbook(id, textbookName, isbn);
            }
            else
            {
                records = GetOutStockRecordsByTextbook(id, textbookName, isbn);
            }

            return _adapter.Adapt<StockRecordView>(records);
        }

        #endregion

        #region 私有方法

        private IEnumerable<StockRecord> GetOutStockRecordsByDate(Guid storageId, DateTime beginDate, DateTime endDate)
        {
            //取仓库的出库记录
            var records = _inventoryRepo.Find(t =>
                t.Storage_Id == storageId    //仓库
                ).SelectMany(t =>
                    t.StockRecords
                    ).OfType<OutStockRecord>()  //出库记录
                    .Where(t =>
                        t.StockDate >= beginDate &&
                        t.StockDate <= endDate
                        );

            return records;
        }

        private IEnumerable<StockRecord> GetInStockRecordsByDate(Guid storageId, DateTime beginDate, DateTime endDate)
        {
            //取仓库的入库记录
            var records = _inventoryRepo.Find(t =>
                t.Storage_Id == storageId    //仓库
                ).SelectMany(t =>
                    t.StockRecords
                    ).OfType<InStockRecord>()  //入库记录
                    .Where(t =>
                        t.StockDate >= beginDate &&
                        t.StockDate <= endDate
                        );

            return records;
        }

        private IEnumerable<StockRecord> GetOutStockRecordsByTextbook(Guid storageId, string textbookName, string isbn)
        {
            IEnumerable<StockRecord> records = new List<StockRecord>();

            if (string.IsNullOrWhiteSpace(textbookName))
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    //无
                }
                else
                {
                    records = _inventoryRepo.Find(t =>
                        t.Storage_Id == storageId &&
                        t.Textbook.Isbn.Contains(isbn)
                        ).SelectMany(t =>
                            t.StockRecords
                            ).OfType<OutStockRecord>();
                }
            }
            else
            {
                records = _inventoryRepo.Find(t =>
                        t.Storage_Id == storageId &&
                        t.Textbook.Name.Contains(textbookName)
                        ).SelectMany(t =>
                            t.StockRecords
                            ).OfType<OutStockRecord>();
            }
            return records;
        }

        private IEnumerable<StockRecord> GetInStockRecordsByTextbook(Guid storageId, string textbookName, string isbn)
        {
            IEnumerable<StockRecord> records = new List<StockRecord>();

            if (string.IsNullOrWhiteSpace(textbookName))
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    //无
                }
                else
                {
                    records = _inventoryRepo.Find(t =>
                        t.Storage_Id == storageId &&
                        t.Textbook.Isbn.Contains(isbn)
                        ).SelectMany(t =>
                            t.StockRecords
                            ).OfType<InStockRecord>();
                }
            }
            else
            {
                records = _inventoryRepo.Find(t =>
                        t.Storage_Id == storageId &&
                        t.Textbook.Name.Contains(textbookName)
                        ).SelectMany(t =>
                            t.StockRecords
                            ).OfType<InStockRecord>();
            }
            return records;
        }
        #endregion

    }
}
