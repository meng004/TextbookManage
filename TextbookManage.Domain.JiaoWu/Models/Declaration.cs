using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Declaration : AggregateRoot
    {

        #region 属性

        /// <summary>
        /// 申报ID
        /// </summary>
        public Guid DeclarationId { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid? Textbook_Id { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// 开课学院ID
        /// </summary>
        public Guid School_Id { get; set; }
        /// <summary>
        /// 开课系教研室ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public Guid? Subscription_Id { get; set; }
        /// <summary>
        /// 学年
        /// </summary>
        public string SchoolYear { get; set; }
        /// <summary>
        /// 学期
        /// </summary>
        public string SchoolTerm { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// 数据标识
        /// A为本部，B为船山
        /// </summary>
        public string DataSign { get; set; }
        /// <summary>
        /// 是否归档
        /// 表明当前记录的审核状态
        /// </summary>
        public string Sfgd { get; set; }
        /// <summary>
        /// 是否已查看回告
        /// </summary>
        public bool HadViewFeedback { get; set; }
        /// <summary>
        /// 查看回告日期
        /// </summary>
        public DateTime? ViewFeedbackDate { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// 开课学院
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// 开课系教研室
        /// </summary>
        public virtual Department Department { get; set; }
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
        /// 是否可以下订单
        /// 审核状态为终审通过
        /// 且未下订单
        /// </summary>
        public bool CanSubscribe
        {
            get
            {
                return !Subscription_Id.HasValue;
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
