using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextbookManage.ViewModels
{
    public class ModifyRequest : RequestBase
    {
        /// <summary>
        /// 待修改的实体
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
