using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
     /// <summary>
     /// 领用人名单View
     /// </summary>
    [DataContract]
    public class StudentForRecipientsView:StudentView
    {
        /// <summary>
        /// 学籍ID
        /// </summary>
        [DataMember]
        public string StudentId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        [DataMember]
        public string StudentNum { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        [DataMember]
        public string StudentName { get; set; }       
    }
}
