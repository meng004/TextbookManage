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
        /// �ֿ�ID
        /// </summary>
        public int StorageID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public int Bookseller_ID { get; set; }
        /// <summary>
        /// �ֿ�����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �ֿ��ַ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
