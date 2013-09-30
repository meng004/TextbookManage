using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextbookManage.Domain.Models
{
    public class Course
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public Guid CourseID { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }
    }
}
