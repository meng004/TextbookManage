namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CourseView:ViewModelBase
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        [DataMember]
        public string CourseID { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
