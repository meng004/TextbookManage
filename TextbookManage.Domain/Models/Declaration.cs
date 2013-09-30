using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 用书申报
    /// </summary>
    public class Declaration : IAggregateRoot
    {
        public Declaration()
        {
            this.DeclarationApprovals = new List<DeclarationApproval>();
            this.Subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// 申报ID
        /// </summary>
        public int DeclarationID { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public int Textbook_ID { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        public string TeachingTask_Num { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        public System.Guid Teacher_ID { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// 领用人类型，学生或教师
        /// </summary>
        public RecipientType RecipientType { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public System.DateTime DeclarationDate { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// 是否已查看回告
        /// </summary>
        public bool HadViewFeedback { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// 审核记录
        /// </summary>
        public virtual ICollection<DeclarationApproval> DeclarationApprovals { get; set; }
        /// <summary>
        /// 所属订单
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }


    }
}
