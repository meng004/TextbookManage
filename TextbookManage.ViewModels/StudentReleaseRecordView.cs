namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// ѧ�����ż�¼
    /// </summary>
    [DataContract]
    public class StudentReleaseRecordView : BaseViewModel
    {
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// �༶ID
        /// </summary>
        [DataMember]
        public string ClassId { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// ѧ��ID
        /// </summary>
        [DataMember]
        public string StudentId { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        [DataMember]
        public string StudentNum { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        [DataMember]
        public string StudentName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
        /// <summary>
        /// ������1����
        /// </summary>
        [DataMember]
        public string Recipient1Name { get; set; }
        /// <summary>
        /// ������1�绰
        /// </summary>
        [DataMember]
        public string Recipient1Phone { get; set; }
        /// <summary>
        /// ������2����
        /// </summary>
        [DataMember]
        public string Recipient2Name { get; set; }
        /// <summary>
        /// ������2�绰
        /// </summary>
        [DataMember]
        public string Recipient2Phone { get; set; }
    }
}
