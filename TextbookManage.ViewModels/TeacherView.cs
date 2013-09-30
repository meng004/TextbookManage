namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TeacherView : ViewModelBase
    {
        /// <summary>
        /// ��ʦID
        /// </summary>
        [DataMember]
        public string TeacherID { get; set; }
        /// <summary>
        /// ��ʦ���
        /// </summary>
        [DataMember]
        public string TeacherNum { get; set; }
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
        /// <summary>
        /// ϵ������ID
        /// </summary>
        [DataMember]
        public string Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// ϵ����������
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
    }
}
