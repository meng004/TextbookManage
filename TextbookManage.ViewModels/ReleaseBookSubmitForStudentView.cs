using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 发放学生个人教材提交View
    /// </summary>
    [DataContract]
    public class ReleaseBookSubmitForStudentView:ReleaseBookView
    {    
        /// <summary>
        /// 学生Id
        /// </summary>
        [DataMember]
        public string  StudentId { get; set; }
    }
}
