namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 行政班
    /// </summary>
    [DataContract]
    public class ProfessionalClassView : ProfessionalClassBaseView
    {

        /// <summary>
        /// 班号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 学生人数
        /// </summary>
        [DataMember]
        public string StudentCount { get; set; }
    }
}
