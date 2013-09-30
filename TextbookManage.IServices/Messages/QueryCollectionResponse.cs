using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 返回结果为集合的查询响应
    /// </summary>
    public class QueryCollectionResponse : ResponseBase
    {
        /// <summary>
        /// 查询结果
        /// </summary>
        public IEnumerable<ViewModelBase> Entities
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
