namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StudentView : ViewModelBase
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        [DataMember]
        public string StudentID { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        [DataMember]
        public string StudentNum { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        [DataMember]
        public string StudentName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        [DataMember]
        public string Class_ID { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        [DataMember]
        public string ClassNum { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        [DataMember]
        public string Grade { get; set; }
        /// <summary>
        /// 学院ID
        /// </summary>
        [DataMember]
        public string School_ID { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        [DataMember]
        public string SchoolNum { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
    }
}
