namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class TextbookForReleaseView : TextbookView
    {

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
