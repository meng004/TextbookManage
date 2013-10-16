namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 书商实发教材
    /// </summary>
    [DataContract]
    public class BooksellerReleaseDetailView:BaseViewModel
    {
        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }

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
        /// 零售价
        /// </summary>
        [DataMember]
        public string RetailPrice { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [DataMember]
        public string TotalCount { get; set; }

        /// <summary>
        /// 码洋
        /// </summary>
        [DataMember]
        public string TotalRetailCharge { get; set; }

        /// <summary>
        /// 实洋
        /// </summary>
        [DataMember]
        public string TotalDiscountCharge { get; set; }

        /// <summary>
        /// 学院
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }

    }
}
