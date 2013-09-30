using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ���
    /// </summary>
    public class Inventory
    {
        public Inventory()
        {
            this.StockRecords = new List<StockRecord>();
        }

        /// <summary>
        /// ���ID
        /// </summary>
        public int InventoryID { get; set; }
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        public int Storage_ID { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public int Textbook_ID { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        public string ShelfNumber { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public int InventoryCount { get; set; }
        /// <summary>
        /// �������¼
        /// </summary>
        public virtual ICollection<StockRecord> StockRecords { get; set; }
        /// <summary>
        /// �ֿ�
        /// </summary>
        public virtual Storage Storage { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        public virtual Textbook Textbook { get; set; }
    }
}
