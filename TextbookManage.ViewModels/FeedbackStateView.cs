namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class FeedbackStateView : BaseViewModel
    {
        /// <summary>
        /// 回告状态编号
        /// </summary>
        [DataMember]
        public string Id { set; get; }

        /// <summary>
        /// 回告状态名称
        /// </summary>
        [DataMember]
        public string Name { set; get; }
    }
}
