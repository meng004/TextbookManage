namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;
    
    /// <summary>
    /// 班级实发教材
    /// </summary>
    [DataContract]
    public class ClassReleaseDetailView :BaseViewModel
    {
        /// <summary>
        ///教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }

        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }

        /// <summary>
        /// ISBN
        /// </summary>
        [DataMember]
        public string Isbn { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        [DataMember]
        public string Press { get; set; }

        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Term { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [DataMember]
        public string CourseName { get; set; }

        /// <summary>
        /// 书商名称
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }

        /// <summary>
        /// 学院名称
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }

        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }

        /// <summary>
        /// 发放状态，是否发放
        /// </summary>
        public string IsRelease { get; set; }

    }
}
