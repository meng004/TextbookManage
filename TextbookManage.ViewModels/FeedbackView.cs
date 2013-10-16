namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 回告View
    /// </summary>
    [DataContract]
    public class FeedbackView : BaseViewModel
    {
        /// <summary>
        /// 回告id
        /// </summary>
        [DataMember]
        public string FeedbackId { get; set; }
        /// <summary>
        /// 书商名称
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
        /// <summary>
        /// 回告人
        /// </summary>
        [DataMember]
        public string Person { set; get; }
        /// <summary>
        /// 回告时间
        /// </summary>
        [DataMember]
        public string FeedbackDate { set; get; }
        /// <summary>
        /// 回告状态
        /// </summary>
        [DataMember]
        public string FeedbackState { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember] 
        public string Remark { set; get; }

    }
}
