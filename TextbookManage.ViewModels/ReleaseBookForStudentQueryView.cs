using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 发放学生个人教材查询View
    /// </summary>
    [DataContract]
  public  class ReleaseBookForStudentQueryView:ReleaseBookView
    {
         /// <summary>
         /// 课程名称
         /// </summary>
        [DataMember]
        public string  CourseName { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        [DataMember]
        public IEnumerable<StudentView> Students { get; set; }

    }
}
