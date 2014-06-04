using System;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 审核目标
    /// </summary>
    public enum ApprovalTarget:int
    {
        /// <summary>
        /// 用书申报
        /// </summary>
        Declaration,
        /// <summary>
        /// 订单回告
        /// </summary>
        Feedback,
        /// <summary>
        /// 教材
        /// </summary>
        Textbook
    }
}
