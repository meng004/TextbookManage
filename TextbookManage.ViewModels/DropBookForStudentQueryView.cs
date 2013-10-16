using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 学生个人教材退还查询View
    /// </summary>
    [DataContract]
    public class DropBookForStudentQueryView:DropBookView
    {
        /// <summary>
        /// 发放日期
        /// </summary>
        [DataMember]
        public string  ReleaseDate { get; set; }
        /// <summary>
        /// 发放人
        /// </summary>
        [DataMember]
        public string  ReleasePerson { get; set; }
        /// <summary>
        /// 领用人
        /// </summary>
        [DataMember]
        public string  RecipientName { get; set; }
        /// <summary>
        /// 领用人联系方式
        /// </summary>
        [DataMember]
        public string  RecipientTelephone { get; set; }  
    }
}
