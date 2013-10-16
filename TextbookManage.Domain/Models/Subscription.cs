using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Subscription : AggregateRoot
    {
        public Subscription()
        {
            Declarations = new List<Declaration>();
        }

        #region ����

        /// <summary>
        /// ����ID
        /// </summary>
        public Guid SubscriptionId { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid Textbook_Id { get; set; }
        /// <summary>
        /// �ظ�ID
        /// </summary>
        public int? Feedback_Id { get; set; }
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
        #endregion

        #region ҵ�����

        /// <summary>
        /// �����Ļظ�״̬
        /// </summary>
        /// <returns></returns>
        public FeedbackState FeedbackState
        {
            get
            {
                if (Feedback == null || Feedback.ApprovalState != ApprovalState.����ͨ��)
                {
                    return FeedbackState.������;
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
