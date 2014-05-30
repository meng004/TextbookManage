using System;

namespace TextbookManage.Domain.Models
{
    public enum FeedbackState : int
    {

        /// <summary>
        /// Î´Õ÷¶©
        /// </summary>
        //NotSubscription,
        Î´Õ÷¶©,
        /// <summary>
        /// Õ÷¶©ÖÐ
        /// </summary>
        //OnSubscription,
        Õ÷¶©ÖÐ,
        /// <summary>
        /// Õ÷¶©³É¹¦
        /// </summary>
        //Success,
        Õ÷¶©³É¹¦,
        /// <summary>
        /// Õ÷¶©Ê§°Ü
        /// </summary>
        //Fail,
        Õ÷¶©Ê§°Ü,
        /// <summary>
        /// Î´Öª
        /// </summary>
        //UnKnown
        Î´Öª×´Ì¬
    }
}
