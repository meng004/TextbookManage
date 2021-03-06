using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Teacher : AggregateRoot
    {
        public Teacher()
        {
            this.Departments = new List<Department>();
            this.TeachingTasks = new List<TeachingTask>();
            ReleaseRecords = new List<TeacherReleaseRecord>();
        }

        #region 属性

        /// <summary>
        /// 教师ID
        /// </summary>
        //public System.Guid TeacherId { get; set; }
        /// <summary>
        /// 教师编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 部门集合
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
        /// <summary>
        /// 教学任务集合
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// 教材发放集合
        /// </summary>
        public virtual ICollection<TeacherReleaseRecord> ReleaseRecords { get; set; }
        #endregion

    }
}
