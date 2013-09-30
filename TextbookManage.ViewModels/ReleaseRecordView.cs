namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// 发放记录
    /// </summary>
    [DataContract]
    public class ReleaseRecordView : ViewModelBase
    {
        /// <summary>
        /// 发放记录ID
        /// </summary>
        [DataMember]
        public string ReleaseRecordID { get; set; }
        /// <summary>
        /// 库存变更记录ID
        /// </summary>
         [DataMember]
        public string StockRecord_ID { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookID { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        [DataMember]
        public string Isbn { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [DataMember]
        public string Author { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        [DataMember]
        public string Press { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        [DataMember]
        public string PressAddress { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [DataMember]
        public string Edition { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        [DataMember]
        public string PrintCount { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        [DataMember]
        public string PublishDate { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        [DataMember]
        public string Price { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
         [DataMember]
        public string Discount { get; set; }
        /// <summary>
        /// 折后价
        /// </summary>
        [DataMember]
        public string DiscountPrice { get; set; }
        /// <summary>
        /// 教材类型
        /// </summary>
        [DataMember]
        public string TextbookType { get; set; }
        /// <summary>
        /// 是否自编教材
        /// </summary>
        [DataMember]
        public string IsSelfCompile { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public string PageCount { get; set; }
        /// <summary>
        /// 学院ID
        /// </summary>
        [DataMember]
        public string School_ID { get; set; }
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
        /// 联系电话
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
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
