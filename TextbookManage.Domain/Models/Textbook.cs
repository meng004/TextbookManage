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

        #region 属性

        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid TextbookId { get; set; }
        /// <summary>
        /// 教材编号
        /// </summary>
        public int Num { get; set; }
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
        ///// <summary>
        ///// 出版社
        ///// </summary>
        //public string Press { get; set; }
        ///// <summary>
        ///// 出版社地址
        ///// </summary>
        //public string PressAddress { get; set; }
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
        public DateTime PublishDate { get; set; }
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
        public Guid? TeacherId { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public DateTime? DeclarationDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// 出版社ID
        /// </summary>
        public int PressId { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        public virtual Press Press { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        public virtual Teacher Declarant { get; set; }
        /// <summary>
        /// 审核记录
        /// </summary>
        public virtual ICollection<TextbookApproval> Approvals { get; set; }
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
                return Math.Round(Price * Discount, 2, MidpointRounding.ToEven);
            }
        }

        /// <summary>
        /// 审核通过
        /// 修改审核状态
        /// </summary>
        private void ApprovalPass()
        {
            switch (ApprovalState)
            {
                //未提交，则变成学院审核中
                case ApprovalState.未提交:
                    ApprovalState = ApprovalState.学院审核中;
                    break;
                //学院审核后，变成教材科审核中
                case ApprovalState.学院审核中:
                    ApprovalState = ApprovalState.教材科审核中;
                    break;
                //教材科审核后，变成终审通过
                case ApprovalState.教材科审核中:
                    ApprovalState = ApprovalState.终审通过;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 审核不通过
        /// 修改审核状态
        /// </summary>
        private void ApprovalNotPass()
        {
            switch (ApprovalState)
            {
                //学院审核不通过
                case ApprovalState.学院审核中:
                    ApprovalState = ApprovalState.学院审核未通过;
                    break;
                //教材科审核不通过
                case ApprovalState.教材科审核中:
                    ApprovalState = ApprovalState.教材科审核未通过;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="approvalSuggestion">审核意见</param>
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
