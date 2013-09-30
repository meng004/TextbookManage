using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface ISubscription : IBookseller, ISchool
    {

        /// <summary>
        /// 通过学院Id对教材汇总，获取未生成的订单
        /// </summary>
        /// <param name="schoolId">学院ID</param>
        /// <returns></returns>
        IEnumerable<SubscriptionView> GetSubscriptionPlans(string schoolId);

        /// <summary>
        /// 根据教材汇总，获取未生成的订单
        /// </summary>
        /// <param name="textbookName">教材名称</param>
        /// <param name="isbn"></param>
        /// <returns>如果无输入，则返回全部订单</returns>
        IEnumerable<SubscriptionView> GetSubscriptionPlans(string textbookName, string isbn);

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="bookSellerId">书商ID</param>
        /// <param name="spareCount">上抛数量</param>
        /// <param name="subscriptionPlanViews">订单</param>
        /// <param name="ipAddress">ip地址</param>
        /// <param name="loginName">登录名</param>
        /// <param name="message">返回操作结果信息</param>
        /// <returns></returns>
        void SubmitSubscriptionPlan(string bookSellerId, string spareCount, IEnumerable<SubscriptionView> subscriptionPlanViews, ref string message);


    }
}
