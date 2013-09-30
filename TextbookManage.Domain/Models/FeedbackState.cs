using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextbookManage.Domain.Models
{
    public enum FeedbackState
    {
        /// <summary>
        /// 未征订
        /// </summary>
        NotSubscription,
        /// <summary>
        /// 征订中
        /// </summary>
        OnSubscription,
        /// <summary>
        /// 征订成功
        /// </summary>
        SubscriptionSuccess,
        /// <summary>
        /// 征订失败
        /// </summary>
        SubscriptionFail,
        /// <summary>
        /// 未知
        /// </summary>
        UnKnown
    }
}
