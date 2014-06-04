using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ����춯��¼
    /// </summary>
    public class StockRecord : AggregateRoot
    {
        public StockRecord()
        {

        }

        #region ����

        /// <summary>
        /// �������¼ID
        /// </summary>
        public Guid StockRecordId { get; set; }
        /// <summary>
        /// ���ID
        /// </summary>
        public Guid Inventory_Id { get; set; }
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
        public bool IsInStock { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual Inventory Inventory { get; set; }

        #endregion


    }
}
