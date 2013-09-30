using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class StockRecord
    {
        public StockRecord()
        {
            this.ReleaseRecords = new List<ReleaseRecord>();
        }

        /// <summary>
        /// 库存变更记录ID
        /// </summary>
        public int StockRecordID { get; set; }
        /// <summary>
        /// 库存ID
        /// </summary>
        public int Inventory_ID { get; set; }
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
        public bool StockType { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public virtual Inventory Inventory { get; set; }
        /// <summary>
        /// 发放记录
        /// </summary>
        public virtual ICollection<ReleaseRecord> ReleaseRecords { get; set; }
    }
}
