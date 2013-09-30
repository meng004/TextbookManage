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
        /// ����ID
        /// </summary>
        public int SubscriptionID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public int Bookseller_ID { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public int Textbook_ID { get; set; }
        /// <summary>
        /// �ظ�ID
        /// </summary>
        public int Feedback_ID { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// �ƻ�����
        /// </summary>
        public int PlanCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public int SpareCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public System.DateTime SubscriptionDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
        /// <summary>
        /// �ظ�
        /// </summary>
        public virtual Feedback Feedback { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// �����걨
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
    }
}
