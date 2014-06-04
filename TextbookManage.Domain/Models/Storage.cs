using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Storage : AggregateRoot
    {
        public Storage()
        {
            this.Inventories = new List<Inventory>();
        }

        #region 属性

        /// <summary>
        /// 仓库ID
        /// </summary>
        public Guid StorageId { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
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
        #endregion
    }
}
