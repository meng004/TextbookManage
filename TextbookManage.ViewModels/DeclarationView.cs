namespace TextbookManage.ViewModels
{

    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class DeclarationView : BaseViewModel
    {
        /// <summary>
        /// 申报ID
        /// </summary>
        [DataMember]
        public string DeclarationId { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        [DataMember]
        public IList<string> TeachingTaskNums { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        [DataMember]
        public string Declarant { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        [DataMember]
        public string DeclarationCount { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        [DataMember]
        public string Mobile { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }
        /// <summary>
        /// 不需要教材
        /// </summary>
        [DataMember]
        public bool NotNeedTextbook { get; set; }
    }
}
