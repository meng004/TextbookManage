using System;
using System.Collections.Generic;
using TextbookManage.Infrastructure;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Textbook : AggregateRoot
    {
        public Textbook()
        {
            Declarations = new List<Declaration>();
            Subscriptions = new List<Subscription>();            
        }

        #region ����

        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid TextbookId { get; set; }
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
        /// <summary>
        /// ��������
        /// </summary>
        public string PublishDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// �汾
        /// </summary>
        public string Edition { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string PrintCount { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string Press { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        public string TextbookType { get; set; }
        /// <summary>
        /// �����걨
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
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
                return Math.Round(Price.ConvertToDecimal() * Discount, 2, MidpointRounding.ToEven);
            }
        }

        #endregion

    }
}
