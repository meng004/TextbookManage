using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public partial class Textbook : IAggregateRoot
    {
        public Textbook()
        {
            this.TextbookApprovals = new List<TextbookApproval>();
            this.Declarations = new List<Declaration>();
            this.Inventories = new List<Inventory>();
            this.Subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// �̲�ID
        /// </summary>
        public int TextbookID { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string Press { get; set; }
        /// <summary>
        /// �������ַ
        /// </summary>
        public string PressAddress { get; set; }
        /// <summary>
        /// �汾
        /// </summary>
        public int Edition { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public int PrintCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public System.DateTime PublishDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        public string TextbookType { get; set; }
        /// <summary>
        /// �Ƿ��Ա�̲�
        /// </summary>
        public bool IsSelfCompile { get; set; }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// �걨��
        /// </summary>
        public System.Guid TeacherId { get; set; }
        /// <summary>
        /// �걨����
        /// </summary>
        public DateTime DeclarationDate { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// �ۿ���
        /// </summary>
        public Nullable<decimal> Discount { get; set; }
        /// <summary>
        /// �ۺ��
        /// </summary>
        public Nullable<decimal> DiscountPrice { get; set; }
        /// <summary>
        /// ��˼�¼
        /// </summary>
        public virtual ICollection<TextbookApproval> TextbookApprovals { get; set; }
        /// <summary>
        /// �����걨
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual ICollection<Inventory> Inventories { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
