using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 发放教师教材查询View
    /// </summary>
    [DataContract]
  public  class ReleaseBookForTeacherQueryView:ReleaseBookView
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        [DataMember]
        public string  CourseNum { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        [DataMember]
        public string  CourseName { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        [DataMember]
        public string BarCode  { get; set; } 
        /// <summary>
        /// 申报人
        /// </summary>
        [DataMember]
        public string  DeclarationPerson { get; set; }
    }
}
