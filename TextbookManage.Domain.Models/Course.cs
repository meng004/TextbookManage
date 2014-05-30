using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Course 
    {
        public Course()
        {
            TeachingTasks = new List<TeachingTask>();
            Departments = new List<Department>();
        }
        /// <summary>
        /// 课程ID
        /// </summary>
        public Guid CourseId { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 教学任务集合
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// 教研室集合
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
    }
}
