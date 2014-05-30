using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 库存异动记录
    /// </summary>
    public class StockRecord : AggregateRoot
    {
        public StockRecord()
        {

        }

        #region 属性

        /// <summary>
        /// 库存变更记录ID
        /// </summary>
        public int StockRecordId { get; set; }
        /// <summary>
        /// 库存ID
        /// </summary>
        public int Inventory_Id { get; set; }
        /// <summary>
        /// 变更数量
        /// </summary>
        public int StockCount { get; set; }
        /// <summary>
        /// 变更日期
        /// </summary>
        public System.DateTime StockDate { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 变更类型，出库false 或 入库true
        /// </summary>
        public bool IsInStock { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public virtual Inventory Inventory { get; set; }

        #endregion


    }
}
