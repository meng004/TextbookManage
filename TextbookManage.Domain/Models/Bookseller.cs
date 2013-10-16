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
        /// ����ID
        /// </summary>
        public Guid BooksellerId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// ����Ա��
        /// </summary>
        public virtual ICollection<BooksellerStaff> BooksellerStaffs { get; set; }
        /// <summary>
        /// �ֿ�
        /// </summary>
        public virtual ICollection<Storage> Storages { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
