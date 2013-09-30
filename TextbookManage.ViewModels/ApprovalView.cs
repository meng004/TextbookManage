namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ApprovalView : ViewModelBase
    {
        /// <summary>
        /// 审核记录ID
        /// </summary>
        [DataMember]
        public string ApprovalID { get; set; }
        /// <summary>
        /// 审核部门
        /// </summary>
        public string Division { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        public string Auditor { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        [DataMember]
        public string ApprovalDate { get; set; }
        /// <summary>
        /// 审核意见，同意或不同意
        /// </summary>
        [DataMember]
        public string Suggestion { get; set; }
        /// <summary>
        /// 说明，备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
