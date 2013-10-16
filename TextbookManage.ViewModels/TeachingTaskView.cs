namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;
    /// <summary>
    /// 教学任务View
    /// </summary>
    [DataContract]
    public class TeachingTaskView : BaseViewModel
    {
        /// <summary>
        /// 教学班编号
        /// </summary>
        [DataMember]
        public string TeachingTaskNum { set; get; }
        /// <summary>
        /// 任课教师姓名
        /// </summary>
        [DataMember]
        public string TeacherName { set; get; }
        /// <summary>
        /// 教学班人数
        /// </summary>
        [DataMember]
        public string StudentCount { set; get; }
        /// <summary>
        /// 学生用书申报状态
        /// </summary>
        [DataMember]
        public string DeclarationState { get; set; }
        /// <summary>
        /// 数据标识名称
        /// </summary>
        [DataMember]
        public string DataSignName { set; get; }

    }
}
