using System;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain
{
    public class InventoryService
    {

        /// <summary>
        /// 创建库存变动记录
        /// </summary>
        /// <typeparam name="T">出库/入库</typeparam>
        /// <param name="inventoryId">库存ID</param>
        /// <param name="person">操作人</param>
        /// <param name="stockCount">变动数量</param>
        /// <returns></returns>
        public static T CreateStockRecord<T>(Inventory inventory, string person, int stockCount)
            where T : StockRecord, new()
        {
            var stockRecord = new T
            {           
                Inventory_Id=inventory.InventoryId,
                Operator = person,
                StockCount = stockCount,
                StockDate = DateTime.Now
            };

            inventory.StockRecords.Add(stockRecord);

            return stockRecord;
        }
    }
}
