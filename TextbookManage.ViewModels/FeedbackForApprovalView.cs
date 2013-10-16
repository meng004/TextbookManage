using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    [DataContract]
    public class FeedbackForApprovalView : FeedbackView
    {

        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// 教材编号
        /// </summary>
        [DataMember]
        public string TextbookNum { get; set; }
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
        /// 征订数量
        /// </summary>
        [DataMember]
        public string SubscriptionCount { get; set; }


    }
}
