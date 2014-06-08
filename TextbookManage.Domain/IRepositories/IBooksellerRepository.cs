using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.IRepositories
{
    public interface IBooksellerRepository : IRepository<Bookseller>
    {
        /// <summary>
        /// 获取订单集合
        /// </summary>
        /// <param name="booksellerId">书商ID</param>
        /// <param name="schoolYearTerm">学年学期</param>
        /// <returns></returns>
        IEnumerable<Subscription> GetSubscriptions(Guid booksellerId, SchoolYearTerm schoolYearTerm);
    }
}
