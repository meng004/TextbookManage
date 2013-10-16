using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    public class Declaration : AggregateRoot
    {
        /// <summary>
        /// �����걨
        /// </summary>
        public Declaration()
        {
            Approvals = new List<DeclarationApproval>();
        }

        #region ����

        /// <summary>
        /// �걨ID
        /// </summary>
        public int DeclarationId { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid? Textbook_Id { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        public string TeachingTask_Num { get; set; }
        /// <summary>
        /// �걨��
        /// </summary>
        public Guid Teacher_Id { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public Guid? Subscription_Id { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// ���������ͣ�ѧ�����ʦ
        /// </summary>
        public RecipientType RecipientType { get; set; }
        /// <summary>
        /// �걨����
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// �걨����
        /// </summary>
        public DateTime DeclarationDate { get; set; }
        /// <summary>
        /// �ƶ��绰
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// �̶��绰
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// �Ƿ��Ѳ鿴�ظ�
        /// </summary>
        public bool HadViewFeedback { get; set; }
        /// <summary>
        /// �鿴�ظ�����
        /// </summary>
        public DateTime? ViewFeedbackDate { get; set; }
        /// <summary>
        /// ����Ҫ�̲�
        /// </summary>
        public bool NotNeedTextbook { get; set; }
        /// <summary>
        /// ������ѧ��
        /// </summary>
        public virtual TeachingTask TeachingTask { get; set; }
        /// <summary>
        /// �걨��
        /// </summary>
        public virtual Teacher Declarant { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// ��˼�¼
        /// </summary>
        public virtual ICollection<DeclarationApproval> Approvals { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual Subscription Subscription { get; set; }
        #endregion

        #region ҵ�����

        /// <summary>
        /// ��ȡ�ظ�״̬
        /// </summary>
        /// <returns></returns>
        public FeedbackState FeedbackState
        {
            get
            {
                //�޶���
                if (Subscription == null)
                {
                    return FeedbackState.δ����;
                }
                //�ж��������ض����Ļظ�״̬
                else
                {
                    return Subscription.FeedbackState;
                }
            }
        }

        /// <summary>
        /// ���ͨ��
        /// �޸����״̬
        /// </summary>
        private void ApprovalPass()
        {
            switch (ApprovalState)
            {
                //δ�ύ������ѧԺ�����
                case ApprovalState.δ�ύ:
                    ApprovalState = ApprovalState.�����������;
                    break;
                    //���������ͨ�������ѧԺ�����
                case ApprovalState.�����������:
                    ApprovalState = ApprovalState.ѧԺ�����;
                    break;
                //ѧԺ��˺󣬱�ɽ̲Ŀ������
                case ApprovalState.ѧԺ�����:
                    ApprovalState = ApprovalState.�̲Ŀ������;
                    break;
                //�̲Ŀ���˺󣬱������ͨ��
                case ApprovalState.�̲Ŀ������:
                    ApprovalState = ApprovalState.����ͨ��;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ��˲�ͨ��
        /// �޸����״̬
        /// </summary>
        private void ApprovalNotPass()
        {
            switch (ApprovalState)
            {
                case ApprovalState.�����������:
                    ApprovalState = ApprovalState.���������δͨ��;
                    break;
                //ѧԺ��˲�ͨ��
                case ApprovalState.ѧԺ�����:
                    ApprovalState = ApprovalState.ѧԺ���δͨ��;
                    break;
                //�̲Ŀ���˲�ͨ��
                case ApprovalState.�̲Ŀ������:
                    ApprovalState = ApprovalState.�̲Ŀ����δͨ��;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// �޸����״̬
        /// </summary>
        /// <param name="approvalSuggestion">������</param>
        public void Approval(bool approvalSuggestion)
        {
            if (approvalSuggestion)
            {
                ApprovalPass();
            }
            else
            {
                ApprovalNotPass();
            }
        }

        /// <summary>
        /// �Ƿ�����¶���
        /// ���״̬Ϊ����ͨ��
        /// ��δ�¶���
        /// </summary>
        public bool CanSubscribe
        {
            get
            {
                return ApprovalState == ApprovalState.����ͨ�� && !Subscription_Id.HasValue;
            }
        }

        /// <summary>
        /// �鿴�ظ�
        /// </summary>
        public void ViewFeedback()
        {
            //�Ƿ��Ѳ鿴���ظ�
            if (HadViewFeedback)
            {
                return;
            }
            else//δ�鿴
            {
                //ȡ�ظ�״̬
                var state = FeedbackState;
                //�����Ѹ����ظ�
                if (state == FeedbackState.�����ɹ� || state == FeedbackState.����ʧ��)
                {
                    //�޸��Ѳ鿴�ظ��־
                    HadViewFeedback = true;
                    //�޸Ĳ鿴�ظ�����
                    ViewFeedbackDate = DateTime.Now;
                }
            }
        }

        #endregion

    }
}
