namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TeachingTaskView : ViewModelBase
    {
        //public int TeachingTaskID { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        [DataMember]
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        [DataMember]
        public string Course_ID { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        [DataMember]
        public string CourseNum { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        [DataMember]
        public string CourseName { get; set; }
        /// <summary>
        /// 数据标识
        /// </summary>
        [DataMember]
        public string DataSign { get; set; }
        /// <summary>
        /// 开课学院ID
        /// </summary>
        [DataMember]
        public string SchoolID { get; set; }
        //public string SchoolNum { get; set; }
        /// <summary>
        /// 开课学院名称
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
        /// <summary>
        /// 开课系教研室ID
        /// </summary>
        [DataMember]
        public string Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// 开课系教研室名称
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 责任教师姓名
        /// </summary>
        [DataMember]
        public string ResponsibleTeacher { get; set; }
        /// <summary>
        /// 理论教师ID
        /// </summary>
        [DataMember]
        public string Teacher_ID { get; set; }
        /// <summary>
        /// 理论教师姓名
        /// </summary>
        [DataMember]
        public string TeacherName { get; set; }
        /// <summary>
        /// 学生班级ID
        /// </summary>
        [DataMember]
        public string Class_ID { get; set; }
        /// <summary>
        /// 学生班级名称
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }
        /// <summary>
        /// 学生总数
        /// </summary>
        [DataMember]
        public string StudentCount { get; set; }
        /// <summary>
        /// 学生用书申报状态
        /// </summary>
        [DataMember]
        public string DeclarationState { get; set; }
    }
}
