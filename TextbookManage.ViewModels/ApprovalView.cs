namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ApprovalView : ViewModelBase
    {
        /// <summary>
        /// ��˼�¼ID
        /// </summary>
        [DataMember]
        public string ApprovalID { get; set; }
        /// <summary>
        /// ��˲���
        /// </summary>
        public string Division { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        [DataMember]
        public string Auditor { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        public string ApprovalDate { get; set; }
        /// <summary>
        /// ��������ͬ���ͬ��
        /// </summary>
        [DataMember]
        public string Suggestion { get; set; }
        /// <summary>
        /// ˵������ע
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
