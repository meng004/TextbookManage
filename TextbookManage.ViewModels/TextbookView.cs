namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TextbookView : ViewModelBase
    {
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
        /// 申报人
        /// </summary>
        [DataMember]
        public string Teacher { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        [DataMember]
        public string DeclarationDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember]
        public string ApprovalState { get; set; }
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
    }
}
