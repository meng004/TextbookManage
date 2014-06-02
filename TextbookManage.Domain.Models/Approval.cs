using System;
namespace TextbookManage.Domain.Models
{
    public class Approval 
    {
        /// <summary>
        /// 审核记录ID
        /// </summary>
        public Guid ApprovalId { get; set; }
        /// <summary>
        /// 审核部门
        /// </summary>
        public string Division { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string Auditor { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public System.DateTime ApprovalDate { get; set; }
        /// <summary>
        /// 审核意见，同意或不同意
        /// </summary>
        public bool Suggestion { get; set; }
        /// <summary>
        /// 说明，备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 审核对象，如用书申报、回告
        /// </summary>
        public ApprovalTarget ApprovalTarget { get; set; }
        //public virtual Declaration Declaration { get; set; }
    }
}
