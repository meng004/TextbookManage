using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
     /// <summary>
     /// 班级教材退还查询View
     /// </summary>
    [DataContract]
   public class DorpBookForClassQueryView:DropBookView
    {
        /// <summary>
        /// 未领用名单
        /// </summary>
       [DataMember]
        public IEnumerable<StudentForRecipientsView> UnReceiverList { get; set; }
    }
}
