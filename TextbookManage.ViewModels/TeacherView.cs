namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TeacherView : ViewModelBase
    {
        /// <summary>
        /// 教师ID
        /// </summary>
        [DataMember]
        public string TeacherID { get; set; }
        /// <summary>
        /// 教师编号
        /// </summary>
        [DataMember]
        public string TeacherNum { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        [DataMember]
        public string TeacherName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
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
        /// <summary>
        /// 系教研室ID
        /// </summary>
        [DataMember]
        public string Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// 系教研室名称
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
    }
}
