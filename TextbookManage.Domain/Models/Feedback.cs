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
        /// �ظ�ID
        /// </summary>
        public int Feedback_ID { get; set; }
        /// <summary>
        /// �ظ���
        /// </summary>
        public string Person { get; set; }
        /// <summary>
        /// �ظ�����
        /// </summary>
        public System.DateTime FeedbackDate { get; set; }
        /// <summary>
        /// �ظ�״̬�������ɹ���ʧ�ܣ�δ֪��δ�ظ�
        /// </summary>
        public FeedbackState FeedbackState { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// �ظ���˼�¼
        /// </summary>
        public virtual ICollection<FeedbackApproval> FeedbackApprovals { get; set; }
    }
}
