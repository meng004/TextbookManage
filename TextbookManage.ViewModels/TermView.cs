namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;


    /// <summary>
    /// 学年学期View
    /// </summary>
    [DataContract]
    public class TermView : BaseViewModel
    {
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string YearTerm { set; get; }

        /// <summary>
        /// 当前学年学期
        /// </summary>
        [DataMember]
        public string IsCurrent { set; get; }


    }
}
