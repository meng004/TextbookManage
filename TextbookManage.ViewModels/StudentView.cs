namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StudentView : ViewModelBase
    {
        /// <summary>
        /// ѧ��ID
        /// </summary>
        [DataMember]
        public string StudentID { get; set; }
        /// <summary>
        /// ѧ�����
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
        /// <summary>
        /// �༶ID
        /// </summary>
        [DataMember]
        public string Class_ID { get; set; }
        /// <summary>
        /// �༶���
        /// </summary>
        [DataMember]
        public string ClassNum { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        [DataMember]
        public string Grade { get; set; }
        /// <summary>
        /// ѧԺID
        /// </summary>
        [DataMember]
        public string School_ID { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        [DataMember]
        public string SchoolNum { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
    }
}
