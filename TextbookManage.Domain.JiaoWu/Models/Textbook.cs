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

        #region 属性

        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid TextbookId { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        public string PublishDate { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Edition { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        public string PrintCount { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        public string Press { get; set; }
        /// <summary>
        /// 教材类型
        /// </summary>
        public string TextbookType { get; set; }
        /// <summary>
        /// 用书申报
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        #endregion

        #region 业务规则

        /// <summary>
        /// 教材折扣策略
        /// </summary>        
        public IDiscountStrategy discountStrategy 
        {
            get { return new DiscountStrategyByName(); }
        }

        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal Discount
        {
            get
            {
                return discountStrategy.GetDiscount(this);
            }
        }
        /// <summary>
        /// 折后价
        /// </summary>
        public decimal DiscountPrice
        {
            get
            {
                //四舍六入五取偶                
                return Math.Round(Price.ConvertToDecimal() * Discount, 2, MidpointRounding.ToEven);
            }
        }

        #endregion

    }
}
