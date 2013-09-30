using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public partial class Textbook : IAggregateRoot
    {
        public Textbook()
        {
            this.TextbookApprovals = new List<TextbookApproval>();
            this.Declarations = new List<Declaration>();
            this.Inventories = new List<Inventory>();
            this.Subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// 教材ID
        /// </summary>
        public int TextbookID { get; set; }
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
        /// 出版社
        /// </summary>
        public string Press { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        public string PressAddress { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public int Edition { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        public int PrintCount { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        public System.DateTime PublishDate { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 教材类型
        /// </summary>
        public string TextbookType { get; set; }
        /// <summary>
        /// 是否自编教材
        /// </summary>
        public bool IsSelfCompile { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        public System.Guid TeacherId { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public DateTime DeclarationDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public Nullable<decimal> Discount { get; set; }
        /// <summary>
        /// 折后价
        /// </summary>
        public Nullable<decimal> DiscountPrice { get; set; }
        /// <summary>
        /// 审核记录
        /// </summary>
        public virtual ICollection<TextbookApproval> TextbookApprovals { get; set; }
        /// <summary>
        /// 用书申报
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public virtual ICollection<Inventory> Inventories { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
