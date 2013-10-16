namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// 学生发放记录
    /// </summary>
    [DataContract]
    public class StudentReleaseRecordView : BaseViewModel
    {
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        [DataMember]
        public string ClassId { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        [DataMember]
        public string StudentId { get; set; }
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
        /// <summary>
        /// 领用人1姓名
        /// </summary>
        [DataMember]
        public string Recipient1Name { get; set; }
        /// <summary>
        /// 领用人1电话
        /// </summary>
        [DataMember]
        public string Recipient1Phone { get; set; }
        /// <summary>
        /// 领用人2姓名
        /// </summary>
        [DataMember]
        public string Recipient2Name { get; set; }
        /// <summary>
        /// 领用人2电话
        /// </summary>
        [DataMember]
        public string Recipient2Phone { get; set; }
    }
}
