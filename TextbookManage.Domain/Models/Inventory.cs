using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ¿â´æ
    /// </summary>
    public class Inventory
    {
        public Inventory()
        {
            this.StockRecords = new List<StockRecord>();
        }

        /// <summary>
        /// ¿â´æID
        /// </summary>
        public int InventoryID { get; set; }
        /// <summary>
        /// ²Ö¿âID
        /// </summary>
        public int Storage_ID { get; set; }
        /// <summary>
        /// ½Ì²ÄID
        /// </summary>
        public int Textbook_ID { get; set; }
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
    }
}
