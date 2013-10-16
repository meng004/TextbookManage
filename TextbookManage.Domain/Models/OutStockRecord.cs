using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 出库记录
    /// </summary>
    public class OutStockRecord : StockRecord
    {
        public OutStockRecord()
        {
            ReleaseRecords = new List<ReleaseRecord>();
        }
        /// <summary>
        /// 发放记录
        /// </summary>
        public virtual ICollection<ReleaseRecord> ReleaseRecords { get; set; }

    }
}
