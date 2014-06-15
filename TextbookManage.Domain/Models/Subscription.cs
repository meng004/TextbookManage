using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    public class Subscription : AggregateRoot
    {
        public Subscription()
        {
            TeacherDeclarations = new List<TeacherDeclaration>();
            StudentDeclarations = new List<StudentDeclaration>();
        }

        #region 属性

        /// <summary>
        /// 订单ID
        /// </summary>
        //public Guid SubscriptionId { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid Textbook_Id { get; set; }
        /// <summary>
        /// 回告ID
        /// </summary>
        public Guid? Feedback_Id { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public SchoolYearTerm SchoolYearTerm { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        public int PlanCount { get; set; }
        /// <summary>
        /// 上抛数量
        /// </summary>
        public int SpareCount { get; set; }
        /// <summary>
        /// 征订日期
        /// </summary>
        public System.DateTime SubscriptionDate { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public FeedbackState SubscriptionState { get; set; }
        /// <summary>
        /// 书商
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
        /// <summary>
        /// 回告
        /// </summary>
        public virtual Feedback Feedback { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// 教师用书申报
        /// </summary>
        public virtual ICollection<TeacherDeclaration> TeacherDeclarations { get; set; }
        /// <summary>
        /// 学生用书申报
        /// </summary>
        public virtual ICollection<StudentDeclaration> StudentDeclarations { get; set; }
        #endregion

        #region 业务规则

        /// <summary>
        /// 订单的回告状态
        /// </summary>
        /// <returns></returns>
        public FeedbackState FeedbackState
        {
            get
            {
                if (Feedback == null || Feedback.ApprovalState != ApprovalState.终审通过)
                {
                    return FeedbackState.征订中;
                }
                else
                {
                    return Feedback.FeedbackState;
                }
            }
        }
        #endregion

    }
}
