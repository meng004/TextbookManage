using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Subscription
    {
        public Subscription()
        {
            this.Declarations = new List<Declaration>();
        }

        /// <summary>
        /// 订单ID
        /// </summary>
        public int SubscriptionID { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public int Bookseller_ID { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public int Textbook_ID { get; set; }
        /// <summary>
        /// 回告ID
        /// </summary>
        public int Feedback_ID { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public string Term { get; set; }
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
        /// 用书申报
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
    }
}
