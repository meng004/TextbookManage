using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IBookseller
    {
        /// <summary>
        /// 获得所有书商
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksellerView> GetBooksellerList();        
        
    }
}
