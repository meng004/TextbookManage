using System.Collections.Generic;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.IRepositories
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        /// <summary>
        /// 批量插入订单
        /// 使用存储过程
        /// </summary>
        /// <param name="subscriptions">订单</param>
        //void BuldInsert(IEnumerable<Subscription> subscriptions);

        //#region  订单

        ///// <summary>
        ///// 添加书商订单
        ///// </summary>
        ///// <param name="subscription"></param>
        ///// <returns></returns>
        //bool AddSubscriptionPlan(SubscriptionPlan subscription);
        ///// <summary>
        ///// 更新订单未书商订单
        ///// </summary>
        ///// <param name="subscription"></param>
        ///// <returns></returns>
        //bool UpdateSubscriptionPlan(SubscriptionPlan subscription);
        ///// <summary>
        ///// 通过征订Id获取征订计划
        ///// </summary>
        ///// <param name="subscriptionId"></param>
        ///// <returns></returns>
        //SubscriptionPlan GetSubscriptionPlanById(Guid subscriptionId);
        //#endregion

        //#region 回告

        /////<summary>
        ///// 根据征订计划状态(征订成功、征订失败），用户id得到征订信息
        ///// </summary>
        ///// <param name="yearTerm">学年学期</param>
        ///// <param name="booksellerId">书商ID</param>
        ///// <param name="feedebackState">回告状态</param>
        ///// <returns></returns>
        //IList<SubscriptionPlan> GetSubscriptionPlansByBookselerIdFeedebackState(string yearTerm, Guid booksellerId, bool feedebackState);

        ///// <summary>
        ///// 获取未回告的订单
        ///// </summary>
        ///// <param name="yearTerm">学年学期</param>
        ///// <param name="booksellerId">书商ID</param>
        ///// <returns></returns>
        //IList<SubscriptionPlan> GetSubscriptionPlanForNotFeedback(string yearTerm, Guid booksellerId);

        //#endregion

    }
}
