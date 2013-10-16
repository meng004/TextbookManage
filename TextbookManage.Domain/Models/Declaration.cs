using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    public class Declaration : AggregateRoot
    {
        /// <summary>
        /// 用书申报
        /// </summary>
        public Declaration()
        {
            Approvals = new List<DeclarationApproval>();
        }

        #region 属性

        /// <summary>
        /// 申报ID
        /// </summary>
        public int DeclarationId { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid? Textbook_Id { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        public string TeachingTask_Num { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        public Guid Teacher_Id { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public Guid? Subscription_Id { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// 领用人类型，学生或教师
        /// </summary>
        public RecipientType RecipientType { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public DateTime DeclarationDate { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public ApprovalState ApprovalState { get; set; }
        /// <summary>
        /// 是否已查看回告
        /// </summary>
        public bool HadViewFeedback { get; set; }
        /// <summary>
        /// 查看回告日期
        /// </summary>
        public DateTime? ViewFeedbackDate { get; set; }
        /// <summary>
        /// 不需要教材
        /// </summary>
        public bool NotNeedTextbook { get; set; }
        /// <summary>
        /// 所属教学班
        /// </summary>
        public virtual TeachingTask TeachingTask { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        public virtual Teacher Declarant { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// 审核记录
        /// </summary>
        public virtual ICollection<DeclarationApproval> Approvals { get; set; }
        /// <summary>
        /// 所属订单
        /// </summary>
        public virtual Subscription Subscription { get; set; }
        #endregion

        #region 业务规则

        /// <summary>
        /// 获取回告状态
        /// </summary>
        /// <returns></returns>
        public FeedbackState FeedbackState
        {
            get
            {
                //无订单
                if (Subscription == null)
                {
                    return FeedbackState.未征订;
                }
                //有订单，返回订单的回告状态
                else
                {
                    return Subscription.FeedbackState;
                }
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
                    ApprovalState = ApprovalState.教研室审核中;
                    break;
                    //教研室审核通过，变成学院审核中
                case ApprovalState.教研室审核中:
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
                case ApprovalState.教研室审核中:
                    ApprovalState = ApprovalState.教研室审核未通过;
                    break;
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

        /// <summary>
        /// 是否可以下订单
        /// 审核状态为终审通过
        /// 且未下订单
        /// </summary>
        public bool CanSubscribe
        {
            get
            {
                return ApprovalState == ApprovalState.终审通过 && !Subscription_Id.HasValue;
            }
        }

        /// <summary>
        /// 查看回告
        /// </summary>
        public void ViewFeedback()
        {
            //是否已查看过回告
            if (HadViewFeedback)
            {
                return;
            }
            else//未查看
            {
                //取回告状态
                var state = FeedbackState;
                //书商已给出回告
                if (state == FeedbackState.征订成功 || state == FeedbackState.征订失败)
                {
                    //修改已查看回告标志
                    HadViewFeedback = true;
                    //修改查看回告日期
                    ViewFeedbackDate = DateTime.Now;
                }
            }
        }

        #endregion

    }
}
