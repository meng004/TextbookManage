using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Department : AggregateRoot
    {
        public Department()
        {
            this.Courses = new List<Course>();
            this.Teachers = new List<Teacher>();
            this.TeachingTasks = new List<TeachingTask>();
        }

        #region 属性

        /// <summary>
        /// 部门ID
        /// </summary>
        public System.Guid DepartmentId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 院系所ID
        /// </summary>
        public System.Guid School_Id { get; set; }
        /// <summary>
        /// 院系所
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// 课程集合
        /// </summary>
        public virtual ICollection<Course> Courses { get; set; }
        /// <summary>
        /// 教师集合
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }
        /// <summary>
        /// 教学任务集合
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        #endregion
    }
}
