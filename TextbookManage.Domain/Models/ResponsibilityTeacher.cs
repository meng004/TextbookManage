using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 责任教师，用于教学任务
    /// 复杂类型
    /// </summary>
    public class TeachingTaskTeacher
    {

        /// <summary>
        /// 教师ID
        /// </summary>
        public Guid TeacherId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 教学方式
        /// </summary>
        public string TeachingMode { get; set; }
    }
}
