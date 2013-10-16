namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    /// <summary>
    /// 用书申报的教材查询结果View
    /// </summary>
    [DataContract]
    public class TextbookForDeclarationView : BaseViewModel
    {
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// 教材编号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        [DataMember]
        public string Isbn { get; set; }
    }
}
