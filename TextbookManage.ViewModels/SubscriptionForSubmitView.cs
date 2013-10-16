namespace TextbookManage.ViewModels
{

    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using TextbookManage.Domain.Models;


    [DataContract]
    public class SubscriptionForSubmitView : TextbookForDeclarationView
    {
        /// <summary>
        ///  征订ID
        /// </summary>
        [DataMember]
        public string SubscriptionId { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        [DataMember]
        public string DeclarationCount { set; get; }
        /// <summary>
        /// 用书申报
        /// </summary>
        [DataMember]
        public IEnumerable<DeclarationView> Declarations { get; set; }
    }
}
