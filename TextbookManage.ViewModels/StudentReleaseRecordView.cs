namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// ѧ�����ż�¼
    /// </summary>
    [DataContract]
    public class StudentReleaseRecordView : ViewModelBase
    {
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// �༶ID
        /// </summary>
        [DataMember]
        public string Class_ID { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// ѧ��ID
        /// </summary>
        [DataMember]
        public string Student_ID { get; set; }
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
    }
}
