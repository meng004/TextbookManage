namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ApprovalView : BaseViewModel
    {
        /// <summary>
        /// ��˼�¼ID
        /// </summary>
        [DataMember]
        public string ApprovalId { get; set; }
        /// <summary>
        /// ��˲���
        /// </summary>
        [DataMember]
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
