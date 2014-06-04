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
            StudentDeclarationJiaoWus = new List<StudentDeclarationJiaoWu>();
            StudentDeclarations = new List<StudentDeclaration>();
            TeacherDeclarationJiaoWus = new List<TeacherDeclarationJiaoWu>();
            TeacherDeclarations = new List<TeacherDeclaration>();
        }

        #region 属性

        /// <summary>
        /// 部门ID
        /// </summary>
        //public System.Guid DepartmentId { get; set; }
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
        /// <summary>
        /// 教务学生用书申报
        /// </summary>
        public virtual ICollection<StudentDeclarationJiaoWu> StudentDeclarationJiaoWus { get; set; }
        /// <summary>
        /// 教务教师用书申报
        /// </summary>
        public virtual ICollection<TeacherDeclarationJiaoWu> TeacherDeclarationJiaoWus { get; set; }
        /// <summary>
        /// 学生用书申报
        /// </summary>
        public virtual ICollection<StudentDeclaration> StudentDeclarations { get; set; }
        /// <summary>
        /// 教师用书申报
        /// </summary>
        public virtual ICollection<TeacherDeclaration> TeacherDeclarations { get; set; }
        #endregion
    }
}
