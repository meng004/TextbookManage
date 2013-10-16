using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 教材退还查询BaseView
    /// </summary>
    [DataContract]
  public  class DropBookView:BaseViewModel
    {
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string  YearTerm { get; set; }
         /// <summary>
         /// 教材名称
         /// </summary>
        [DataMember]
        public string  TextbookName { get; set; }
        /// <summary>
        /// 教材Id
        /// </summary>
        [DataMember]
        public string  TextbookId { get; set; }
        /// <summary>
        /// 已发数量
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }
        /// <summary>
        /// 发放记录Id
        /// </summary>
        [DataMember]
        public string  ReleaseRecordId { get; set; }
    }
}
