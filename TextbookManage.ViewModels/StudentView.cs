namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StudentView : BaseViewModel
    {
        /// <summary>
        /// 学籍ID
        /// </summary>
        [DataMember]
        public string StudentId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
    }
}
