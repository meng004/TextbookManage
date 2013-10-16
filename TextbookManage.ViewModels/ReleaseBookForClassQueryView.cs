using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 发放班级教材查询View
    /// </summary>
    [DataContract]
    public class ReleaseBookForClassQueryView : TextbookView
    {

        /// <summary>
        /// 已发放数
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }
    }
}
