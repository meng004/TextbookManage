namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TermView : ViewModelBase
    {
        //public int TermID { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 是否当前学年学期
        /// </summary>
        [DataMember]
        public string IsValid { get; set; }
    }
}
