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

        #region ����

        /// <summary>
        /// �ֿ�ID
        /// </summary>
        public Guid StorageId { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
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
        #endregion
    }
}
