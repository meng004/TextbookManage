using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ¿â´æ
    /// </summary>
    public class Inventory:AggregateRoot
    {
        public Inventory()
        {
            this.StockRecords = new List<StockRecord>();
        }

        #region ÊôÐÔ

        /// <summary>
        /// ¿â´æID
        /// </summary>
        public int InventoryId { get; set; }
        /// <summary>
        /// ²Ö¿âID
        /// </summary>
        public int Storage_Id { get; set; }
        /// <summary>
        /// ½Ì²ÄID
        /// </summary>
        public Guid Textbook_Id { get; set; }
        /// <summary>
        /// ¼ÜÎ»ºÅ
        /// </summary>
        public string ShelfNumber { get; set; }
        /// <summary>
        /// ¿â´æÊýÁ¿
        /// </summary>
        public int InventoryCount { get; set; }
        /// <summary>
        /// ¿â´æ±ä¸ü¼ÇÂ¼
        /// </summary>
        public virtual ICollection<StockRecord> StockRecords { get; set; }
        /// <summary>
        /// ²Ö¿â
        /// </summary>
        public virtual Storage Storage { get; set; }
        /// <summary>
        /// ½Ì²Ä
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        #endregion

    }
}
