namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;
    using System;

    /// <summary>
    /// 领用人类型View
    /// </summary>
    [DataContract]
    [Serializable]
    public class RecipientTypeView : BaseViewModel
    {
        /// <summary>
        /// 领用人ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 领用人类型
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
