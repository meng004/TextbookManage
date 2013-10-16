using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Feedback : AggregateRoot
    {
        public Feedback()
        {
            Subscriptions = new List<Subscription>();
            Approvals = new List<FeedbackApproval>();
        }

        #region 属性

        /// <summary>
        /// 回告ID
        /// </summary>
        public int FeedbackId { get; set; }
        /// <summary>
        /// 回告人
        /// </summary>
        public string Person { get; set; }
        /// <summary>
        /// 回告日期
        /// </summary>
        public System.DateTime FeedbackDate { get; set; }
        /// <summary>
        /// 回告状态，征订成功、失败，未知，未回告
        /// </summary>
        public FeedbackState FeedbackState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// 回告审核记录
        /// </summary>
        public virtual ICollection<FeedbackApproval> Approvals { get; set; }
        #endregion

        #region 业务规则

        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="approvalSuggestion">审核意见</param>
        public void Approval(bool approvalSuggestion)
        {
            if (approvalSuggestion)
            {
                ApprovalState = ApprovalState.终审通过;
            }
            else
            {
                ApprovalState = ApprovalState.教材科审核未通过;
            }
        }
        #endregion

    }
}
