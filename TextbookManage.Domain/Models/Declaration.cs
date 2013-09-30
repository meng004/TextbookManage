using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// �����걨
    /// </summary>
    public class Declaration : IAggregateRoot
    {
        public Declaration()
        {
            this.DeclarationApprovals = new List<DeclarationApproval>();
            this.Subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// �걨ID
        /// </summary>
        public int DeclarationID { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public int Textbook_ID { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        public string TeachingTask_Num { get; set; }
        /// <summary>
        /// �걨��
        /// </summary>
        public System.Guid Teacher_ID { get; set; }
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
        public System.DateTime DeclarationDate { get; set; }
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
        /// �̲�
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// ��˼�¼
        /// </summary>
        public virtual ICollection<DeclarationApproval> DeclarationApprovals { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }


    }
}
