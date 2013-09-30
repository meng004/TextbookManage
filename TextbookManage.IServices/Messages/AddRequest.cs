using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextbookManage.ViewModels
{
    public class AddRequest : RequestBase
    {
        /// <summary>
        /// 待添加的实体
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
