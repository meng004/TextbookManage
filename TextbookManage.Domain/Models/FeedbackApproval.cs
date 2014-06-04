using System;
namespace TextbookManage.Domain.Models
{
    public class FeedbackApproval : Approval
    {
        public FeedbackApproval()
        {
            this.ApprovalTarget = ApprovalTarget.Feedback;
        }

        /// <summary>
        /// 回告ID
        /// </summary>
        public Guid Feedback_Id { get; set; }
        /// <summary>
        /// 回告
        /// </summary>
        public virtual Feedback Feedback { get; set; }
    }
}
