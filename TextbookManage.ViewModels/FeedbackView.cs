namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public  class FeedbackView:ViewModelBase
    {
        /// <summary>
        /// �ظ�ID
        /// </summary>
        [DataMember]
        public string Feedback_ID { get; set; }
        /// <summary>
        /// �ظ���
        /// </summary>
        [DataMember]
        public string Person { get; set; }
        /// <summary>
        /// �ظ�����
        /// </summary>
        [DataMember]
        public string FeedbackDate { get; set; }
        /// <summary>
        /// �ظ�״̬�������ɹ���ʧ�ܣ�δ֪��δ�ظ�
        /// </summary>
        [DataMember]
        public string FeedbackState { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
