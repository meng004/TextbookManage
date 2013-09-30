namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public  class FeedbackView:ViewModelBase
    {
        /// <summary>
        /// 回告ID
        /// </summary>
        [DataMember]
        public string Feedback_ID { get; set; }
        /// <summary>
        /// 回告人
        /// </summary>
        [DataMember]
        public string Person { get; set; }
        /// <summary>
        /// 回告日期
        /// </summary>
        [DataMember]
        public string FeedbackDate { get; set; }
        /// <summary>
        /// 回告状态，征订成功、失败，未知，未回告
        /// </summary>
        [DataMember]
        public string FeedbackState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
