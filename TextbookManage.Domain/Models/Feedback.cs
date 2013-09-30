using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public  class Feedback
    {
        public Feedback()
        {
            this.Subscriptions = new List<Subscription>();
            this.FeedbackApprovals = new List<FeedbackApproval>();
        }

        /// <summary>
        /// 回告ID
        /// </summary>
        public int Feedback_ID { get; set; }
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
        /// 订单
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// 回告审核记录
        /// </summary>
        public virtual ICollection<FeedbackApproval> FeedbackApprovals { get; set; }
    }
}
