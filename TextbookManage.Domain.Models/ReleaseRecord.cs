using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ���ż�¼
    /// </summary>
    public class ReleaseRecord : AggregateRoot
    {
        /// <summary>
        /// ���ż�¼ID
        /// </summary>
        public System.Guid ReleaseRecordId { get; set; }
        /// <summary>
        /// �������¼ID
        /// </summary>
        public int? StockRecord_Id { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid Textbook_Id { get; set; }
        /// <summary>
        /// �̲ı��
        /// </summary>
        public int Num { get; set; }
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
        /// �ۿ���
        /// </summary>
        public Nullable<decimal> Discount { get; set; }
        /// <summary>
        /// �ۺ��
        /// </summary>
        public Nullable<decimal> DiscountPrice { get; set; }
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
        /// ѧԺID
        /// </summary>
        public System.Guid School_Id { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public System.DateTime ReleaseDate { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public int ReleaseCount { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string BooksellerName { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public RecipientType RecipientType { get; set; }
        //public virtual StudentReleaseRecord ReleaseRecord_Student { get; set; }
        //public virtual TeacherReleaseRecord ReleaseRecord_Teacher { get; set; }
        /// <summary>
        /// �����¼
        /// </summary>
        public virtual OutStockRecord OutStockRecord { get; set; }
    }
}
