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

        #region ����

        /// <summary>
        /// �ظ�ID
        /// </summary>
        public int FeedbackId { get; set; }
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
        /// ���״̬
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// �ظ���˼�¼
        /// </summary>
        public virtual ICollection<FeedbackApproval> Approvals { get; set; }
        #endregion

        #region ҵ�����

        /// <summary>
        /// �޸����״̬
        /// </summary>
        /// <param name="approvalSuggestion">������</param>
        public void Approval(bool approvalSuggestion)
        {
            if (approvalSuggestion)
            {
                ApprovalState = ApprovalState.����ͨ��;
            }
            else
            {
                ApprovalState = ApprovalState.�̲Ŀ����δͨ��;
            }
        }
        #endregion

    }
}
