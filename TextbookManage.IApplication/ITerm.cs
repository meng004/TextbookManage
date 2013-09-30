using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface ITerm
    {
        /// <summary>
        /// 获取全部学年学期
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.IEnumerable<TermView> GetTermList();

        /// <summary>
        /// 当前学年
        /// </summary>
        string Year { get; }

        /// <summary>
        /// 当前学期
        /// </summary>
        string Term { get; }

        /// <summary>
        /// 当前学年学期
        /// </summary>
        string CurrentYearTerm { get; }
    }
}
