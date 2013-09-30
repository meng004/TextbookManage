namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SubscriptionView:ViewModelBase
    {
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string SubscriptionID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        [DataMember]
        public string Textbook_ID { get; set; }
        /// <summary>
        /// �ظ�ID
        /// </summary>
        [DataMember]
        public string Feedback_ID { get; set; }
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
