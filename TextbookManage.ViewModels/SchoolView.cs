namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SchoolView : ViewModelBase
    {
        /// <summary>
        /// 学院ID
        /// </summary>
       [DataMember]
        public string SchoolID { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
