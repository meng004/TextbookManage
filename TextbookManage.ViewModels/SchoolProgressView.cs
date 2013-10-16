namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SchoolProgressView : BaseViewModel
    {
 
        /// <summary>
        /// 学院Id
        /// </summary>
        [DataMember]
        public string SchoolId { get; set; }        
        /// <summary>
        /// 学院名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 教学任务总数
        /// </summary>
        [DataMember]
        public string TotalCount { get; set; }
        /// <summary>
        /// 已完成数
        /// </summary>
        [DataMember]
        public string FinishedCount { get; set; }
        /// <summary>
        /// 剩余数
        /// </summary>
        [DataMember]
        public string RestCount { get; set; }
        /// <summary>
        /// 完成比例
        /// </summary>
        [DataMember]
        public string Proportion { get; set; }

    }
}
