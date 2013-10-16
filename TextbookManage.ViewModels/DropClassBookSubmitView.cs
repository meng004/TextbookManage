using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
     /// <summary>
     /// 班级教材退回提交View
     /// </summary>
    [DataContract]
    public class DropClassBookSubmitView:DropBookView 
    {
        /// <summary>
        /// 班级Id
        /// </summary>
        [DataMember]
        public string  ClassId { get; set; } 

    }
}
