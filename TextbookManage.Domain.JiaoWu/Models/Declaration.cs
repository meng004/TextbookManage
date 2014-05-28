using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Declaration : AggregateRoot
    {

        #region ����

        /// <summary>
        /// �걨ID
        /// </summary>
        public Guid DeclarationId { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid? Textbook_Id { get; set; }
        /// <summary>
        /// �γ�ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// ����ѧԺID
        /// </summary>
        public Guid School_Id { get; set; }
        /// <summary>
        /// ����ϵ������ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public Guid? Subscription_Id { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string SchoolYear { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string SchoolTerm { get; set; }
        /// <summary>
        /// �걨����
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// AΪ������BΪ��ɽ
        /// </summary>
        public string DataSign { get; set; }
        /// <summary>
        /// �Ƿ�鵵
        /// ������ǰ��¼�����״̬
        /// </summary>
        public string Sfgd { get; set; }
        /// <summary>
        /// �Ƿ��Ѳ鿴�ظ�
        /// </summary>
        public bool HadViewFeedback { get; set; }
        /// <summary>
        /// �鿴�ظ�����
        /// </summary>
        public DateTime? ViewFeedbackDate { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// �γ�
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// ����ѧԺ
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// ����ϵ������
        /// </summary>
        public virtual Department Department { get; set; }
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
        /// �Ƿ�����¶���
        /// ���״̬Ϊ����ͨ��
        /// ��δ�¶���
        /// </summary>
        public bool CanSubscribe
        {
            get
            {
                return !Subscription_Id.HasValue;
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
