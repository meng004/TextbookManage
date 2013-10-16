namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// 发放记录
    /// </summary>
    [DataContract]
    public class ReleaseRecordView : TextbookForReleaseView
    {
        /// <summary>
        /// 发放记录ID
        /// </summary>
        [DataMember]
        public string ReleaseRecordId { get; set; }
        /// <summary>
        /// 库存变更记录ID
        /// </summary>
         [DataMember]
        public string StockRecordId { get; set; }
         /// <summary>
        /// 学院ID
        /// </summary>
        [DataMember]
        public string SchoolId { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// 发放日期
        /// </summary>
        [DataMember]
        public string ReleaseDate { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }
        /// <summary>
        /// 书商名称
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
        /// <summary>
        /// 领用人类型
        /// </summary>
        [DataMember]
        public string RecipientType { get; set; }
    }
}
