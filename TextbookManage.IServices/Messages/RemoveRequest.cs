using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextbookManage.ViewModels
{
    public class RemoveRequest : RequestBase
    {
        /// <summary>
        /// 待删除的实体主键
        /// </summary>
        public IEnumerable<string> EntityIds
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
