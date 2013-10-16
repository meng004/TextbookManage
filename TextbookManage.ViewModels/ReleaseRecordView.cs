namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// ���ż�¼
    /// </summary>
    [DataContract]
    public class ReleaseRecordView : TextbookForReleaseView
    {
        /// <summary>
        /// ���ż�¼ID
        /// </summary>
        [DataMember]
        public string ReleaseRecordId { get; set; }
        /// <summary>
        /// �������¼ID
        /// </summary>
         [DataMember]
        public string StockRecordId { get; set; }
         /// <summary>
        /// ѧԺID
        /// </summary>
        [DataMember]
        public string SchoolId { get; set; }
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
        /// ����ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }
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
