namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class SubscriptionForFeedbackView : TextbookForDeclarationView
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [DataMember]
        public string SubscriptionId { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        [DataMember]
        public string DeclarationCount { set; get; }
        /// <summary>
        /// 上抛数量
        /// </summary>
        [DataMember]
        public string SpareCount { set; get; }
        /// <summary>
        /// 合计
        /// </summary>
        [DataMember]
        public string TotalCount { get; set; }
        /// <summary>
        /// 征订日期
        /// </summary>
        [DataMember]
        public string SubscriptionDate { get; set; }

    }
}
