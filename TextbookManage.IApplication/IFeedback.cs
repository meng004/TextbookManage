using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IFeedback
    {
        /// <summary>
        /// 获取回告信息
        /// </summary>
        /// <param name="subscriptionPlanId"></param>
        /// <returns></returns>
        FeedbackView GetFeedback(string subscriptionPlanId);

        /// <summary>
        /// 获取回告人姓名
        /// </summary>
        /// <returns></returns>
        string GetFeedbackPerson();

        /// <summary>
        /// 获取书商列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksellerView> GetBooksellerList();

        /// <summary>
        /// 获取回告状态列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetFeedbackState();

        /// <summary>
        /// 获得未回告订单
        /// </summary>
        /// <returns></returns>
        IEnumerable<SubscriptionView> GetSubscriptionPlansForFeedback();

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="booksellerId">书商ID</param>
        /// <param name="feedbackState">回告状态</param>
        /// <returns></returns>
        IEnumerable<SubscriptionView> GetSubscriptionPlansForFeedback(string booksellerId, string feedbackState);

        /// <summary>
        /// 提交回告
        /// </summary>
        /// <param name="subscriptionPlanForFeedbackViews">回告</param>
        /// <param name="booksellerId">书商ID</param>
        /// <param name="feedBackState">回告状态</param>
        /// <param name="remark">备注</param>
        /// <param name="message">返回操作结果信息</param>
        void SubmitFeedback(IEnumerable<SubscriptionView> subscriptionPlanForFeedbackViews, string feedBackState, string remark, ref string message);
    }
}
