namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StudentClassView : ViewModelBase
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        [DataMember]
        public string ClassID { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        [DataMember]
        public string ClassNum { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        [DataMember]
        public string Grade { get; set; }
        /// <summary>
        /// 学生总人数
        /// </summary>
        [DataMember]
        public string StudentCount { get; set; }
        /// <summary>
        /// 所属学院ID
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
