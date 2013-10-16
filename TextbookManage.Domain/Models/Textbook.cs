using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Textbook : AggregateRoot
    {
        public Textbook()
        {
            Approvals = new List<TextbookApproval>();
            Declarations = new List<Declaration>();
            Inventories = new List<Inventory>();
            Subscriptions = new List<Subscription>();            
        }

        #region ����

        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid TextbookId { get; set; }
        /// <summary>
        /// �̲ı��
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Author { get; set; }
        ///// <summary>
        ///// ������
        ///// </summary>
        //public string Press { get; set; }
        ///// <summary>
        ///// �������ַ
        ///// </summary>
        //public string PressAddress { get; set; }
        /// <summary>
        /// �汾
        /// </summary>
        public int Edition { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public int PrintCount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        public string TextbookType { get; set; }
        /// <summary>
        /// �Ƿ��Ա�̲�
        /// </summary>
        public bool IsSelfCompile { get; set; }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// �걨��
        /// </summary>
        public Guid? TeacherId { get; set; }
        /// <summary>
        /// �걨����
        /// </summary>
        public DateTime? DeclarationDate { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        public int PressId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual Press Press { get; set; }
        /// <summary>
        /// �걨��
        /// </summary>
        public virtual Teacher Declarant { get; set; }
        /// <summary>
        /// ��˼�¼
        /// </summary>
        public virtual ICollection<TextbookApproval> Approvals { get; set; }
        /// <summary>
        /// �����걨
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual ICollection<Inventory> Inventories { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        #endregion

        #region ҵ�����

        /// <summary>
        /// �̲��ۿ۲���
        /// </summary>        
        public IDiscountStrategy discountStrategy 
        {
            get { return new DiscountStrategyByName(); }
        }

        /// <summary>
        /// �ۿ���
        /// </summary>
        public decimal Discount
        {
            get
            {
                return discountStrategy.GetDiscount(this);
            }
        }
        /// <summary>
        /// �ۺ��
        /// </summary>
        public decimal DiscountPrice
        {
            get
            {
                //����������ȡż
                return Math.Round(Price * Discount, 2, MidpointRounding.ToEven);
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
        #endregion

    }
}
