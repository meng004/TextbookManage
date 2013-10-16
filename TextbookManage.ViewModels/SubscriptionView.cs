namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SubscriptionView : BaseViewModel
    {
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string SubscriptionId { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// �ظ�ID
        /// </summary>
        [DataMember]
        public string FeedbackId { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// �ƻ�����
        /// </summary>
        [DataMember]
        public string PlanCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string SpareCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string SubscriptionDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
        /// <summary>
        /// �ظ�
        /// </summary>
        [DataMember]
        public string FeedbackState { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }
    }
}
