namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TeachingTaskView : ViewModelBase
    {
        //public int TeachingTaskID { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        [DataMember]
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// �γ�ID
        /// </summary>
        [DataMember]
        public string Course_ID { get; set; }
        /// <summary>
        /// �γ̱��
        /// </summary>
        [DataMember]
        public string CourseNum { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        [DataMember]
        public string CourseName { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// </summary>
        [DataMember]
        public string DataSign { get; set; }
        /// <summary>
        /// ����ѧԺID
        /// </summary>
        [DataMember]
        public string SchoolID { get; set; }
        //public string SchoolNum { get; set; }
        /// <summary>
        /// ����ѧԺ����
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
        /// <summary>
        /// ����ϵ������ID
        /// </summary>
        [DataMember]
        public string Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// ����ϵ����������
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
        /// <summary>
        /// ���ν�ʦ����
        /// </summary>
        [DataMember]
        public string ResponsibleTeacher { get; set; }
        /// <summary>
        /// ���۽�ʦID
        /// </summary>
        [DataMember]
        public string Teacher_ID { get; set; }
        /// <summary>
        /// ���۽�ʦ����
        /// </summary>
        [DataMember]
        public string TeacherName { get; set; }
        /// <summary>
        /// ѧ���༶ID
        /// </summary>
        [DataMember]
        public string Class_ID { get; set; }
        /// <summary>
        /// ѧ���༶����
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        [DataMember]
        public string StudentCount { get; set; }
        /// <summary>
        /// ѧ�������걨״̬
        /// </summary>
        [DataMember]
        public string DeclarationState { get; set; }
    }
}
