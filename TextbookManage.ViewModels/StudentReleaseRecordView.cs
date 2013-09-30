namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// 学生发放记录
    /// </summary>
    [DataContract]
    public class StudentReleaseRecordView : ViewModelBase
    {
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        [DataMember]
        public string Class_ID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        [DataMember]
        public string Student_ID { get; set; }
        /// <summary>
        /// 学号
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
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
