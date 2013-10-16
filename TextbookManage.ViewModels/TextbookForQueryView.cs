namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class TextbookForQueryView : TextbookView
    {
        /// <summary>
        /// 申报人
        /// </summary>
        [DataMember]
        public string Declarant { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        [DataMember]
        public string DeclarationDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember]
        public string ApprovalState { get; set; }
    }
}
