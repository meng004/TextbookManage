using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 查询结果为单个实体的查询响应
    /// </summary>
    public class QuerySingleResponse : ResponseBase
    {
        /// <summary>
        /// 查询结果
        /// </summary>
        public ViewModelBase Entity
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
