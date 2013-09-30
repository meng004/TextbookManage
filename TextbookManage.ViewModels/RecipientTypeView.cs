namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    /// <summary>
    /// 领用人类型View
    /// </summary>
    [DataContract]
    public class RecipientTypeView : ViewModelBase
    {
        /// <summary>
        /// 领用人ID
        /// </summary>
        [DataMember]
        public string RecipientTypeId { get; set; }

        /// <summary>
        /// 领用人类型
        /// </summary>
        [DataMember]
        public string RecipientName { get; set; }
    }
}
