namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// ���ż�¼
    /// </summary>
    [DataContract]
    public class ReleaseRecordView : ViewModelBase
    {
        /// <summary>
        /// ���ż�¼ID
        /// </summary>
        [DataMember]
        public string ReleaseRecordID { get; set; }
        /// <summary>
        /// �������¼ID
        /// </summary>
         [DataMember]
        public string StockRecord_ID { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        [DataMember]
        public string TextbookID { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        [DataMember]
        public string Isbn { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Author { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [DataMember]
        public string Press { get; set; }
        /// <summary>
        /// �������ַ
        /// </summary>
        [DataMember]
        public string PressAddress { get; set; }
        /// <summary>
        /// �汾
        /// </summary>
        [DataMember]
        public string Edition { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        public string PrintCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string PublishDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Price { get; set; }
        /// <summary>
        /// �ۿ���
        /// </summary>
         [DataMember]
        public string Discount { get; set; }
        /// <summary>
        /// �ۺ��
        /// </summary>
        [DataMember]
        public string DiscountPrice { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        [DataMember]
        public string TextbookType { get; set; }
        /// <summary>
        /// �Ƿ��Ա�̲�
        /// </summary>
        [DataMember]
        public string IsSelfCompile { get; set; }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        [DataMember]
        public string PageCount { get; set; }
        /// <summary>
        /// ѧԺID
        /// </summary>
        [DataMember]
        public string School_ID { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string ReleaseDate { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        [DataMember]
        public string RecipientType { get; set; }
    }
}
