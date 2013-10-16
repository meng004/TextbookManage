using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 学生个人教材退还提交View
    /// </summary>
    [DataContract]
    public class DropStudentBookSubmitView:DropBookView
    {
        /// <summary>
        ///学生ID
        /// </summary>
        [DataMember]
        public string  StudentId { get; set; }
    }
}
