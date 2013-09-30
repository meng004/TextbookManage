using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Storage : IAggregateRoot
    {
        public Storage()
        {
            this.Inventories = new List<Inventory>();
        }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int StorageID { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public int Bookseller_ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 所属书商
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
