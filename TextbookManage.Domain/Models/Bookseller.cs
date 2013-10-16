using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Bookseller : AggregateRoot
    {
        public Bookseller()
        {
            this.BooksellerStaffs = new List<BooksellerStaff>();
            this.Storages = new List<Storage>();
            this.Subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// 书商ID
        /// </summary>
        public Guid BooksellerId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 书商员工
        /// </summary>
        public virtual ICollection<BooksellerStaff> BooksellerStaffs { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public virtual ICollection<Storage> Storages { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
