namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SubscriptionView : BaseViewModel
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [DataMember]
        public string SubscriptionId { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// 回告ID
        /// </summary>
        [DataMember]
        public string FeedbackId { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        [DataMember]
        public string PlanCount { get; set; }
        /// <summary>
        /// 上抛数量
        /// </summary>
        [DataMember]
        public string SpareCount { get; set; }
        /// <summary>
        /// 征订日期
        /// </summary>
        [DataMember]
        public string SubscriptionDate { get; set; }
        /// <summary>
        /// 书商
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
        /// <summary>
        /// 回告
        /// </summary>
        [DataMember]
        public string FeedbackState { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }
    }
}
