namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TeacherReleaseRecordView : ViewModelBase
    {

        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// ϵ������ID
        /// </summary>
        [DataMember]
        public string Department_ID { get; set; }
        /// <summary>
        /// ϵ����������
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
        /// <summary>
        /// ��ʦID
        /// </summary>
        [DataMember]
        public string Teacher_ID { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        [DataMember]
        public string TeacherName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// ����֤������
        /// </summary>
        [DataMember]
        public string IDCardType { get; set; }
        /// <summary>
        /// ֤�����
        /// </summary>
        [DataMember]
        public string IDCardNum { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [DataMember]
        public string Barcode { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
