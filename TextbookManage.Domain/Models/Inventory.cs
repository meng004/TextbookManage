using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ���
    /// </summary>
    public class Inventory : AggregateRoot
    {
        public Inventory()
        {
            this.StockRecords = new List<StockRecord>();
        }

        #region ����

        /// <summary>
        /// ���ID
        /// </summary>
        //public Guid InventoryId { get; set; }
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        public Guid Storage_Id { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid Textbook_Id { get; set; }
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
        #endregion

    }
}
