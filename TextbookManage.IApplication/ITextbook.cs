using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface ITextbook
    {
        /// <summary>
        /// 获取教材详细信息
        /// </summary>
        /// <param name="textbookId">教材ID</param>
        /// <returns></returns>
        TextbookView GetTextbookById(string textbookId);

        /// <summary>
        /// 通过教材名称或ISBN获取教材列表
        /// </summary>
        /// <param name="Isbn"></param>
        /// <param name="textBookName">书名</param>
        /// <returns></returns>
        System.Collections.Generic.IEnumerable<TextbookView> GetTextbooksByTextbookNameOrISBN(string textbookName, string isbn);
    }
}
