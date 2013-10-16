namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TextbookFeeForBooksellerProfessionClassView :BaseViewModel
    {
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }

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
        /// 折扣
        /// </summary>
        [DataMember]
        public string Discount { get; set; }

        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }

        /// <summary>
        /// 码洋
        /// </summary>
        [DataMember]
        public string TotalRetailPrice { get; set; }

        /// <summary>
        /// 实洋
        /// </summary>
        [DataMember]
        public string DiscountTotalPrice { get; set; }
    }
}
