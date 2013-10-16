namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DepartmentProgressView : SchoolProgressView
    {
        /// <summary>
        /// 教研室Id
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 教研室名称
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 数据标识名称
        /// </summary>
        [DataMember]
        public string DataSignName { get; set; }
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
    }
}
