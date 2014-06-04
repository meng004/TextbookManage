using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 责任教师，用于教学任务
    /// 复杂类型
    /// </summary>
    public class TeachingTaskTeacher : AggregateRoot
    {

        /// <summary>
        /// 教师ID
        /// </summary>
        public Guid TeacherId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 教学方式
        /// </summary>
        public string TeachingMode { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// 教学任务
        /// </summary>
        public virtual TeachingTask TeachingTask { get; set; }
    }
}
