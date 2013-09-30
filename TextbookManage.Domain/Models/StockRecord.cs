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
        /// �������¼ID
        /// </summary>
        public int StockRecordID { get; set; }
        /// <summary>
        /// ���ID
        /// </summary>
        public int Inventory_ID { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public int StockCount { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public System.DateTime StockDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// ������ͣ�����false �� ���true
        /// </summary>
        public bool StockType { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual Inventory Inventory { get; set; }
        /// <summary>
        /// ���ż�¼
        /// </summary>
        public virtual ICollection<ReleaseRecord> ReleaseRecords { get; set; }
    }
}
