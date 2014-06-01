using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class School : AggregateRoot
    {
        public School()
        {
            this.Departments = new List<Department>();
            this.ProfessionalClasses = new List<ProfessionalClass>();
            StudentDeclarationJiaoWus = new List<StudentDeclarationJiaoWu>();
            TeacherDeclarationJiaoWus = new List<TeacherDeclarationJiaoWu>();
            TeachingTasks = new List<TeachingTask>();
        }

        #region 属性

        /// <summary>
        /// 院系所ID
        /// </summary>
        public System.Guid SchoolId { get; set; }
        /// <summary>
        /// 院系所编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 院系所名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门集合
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
        /// <summary>
        /// 班级集合
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }
        /// <summary>
        /// 教务学生用书申报
        /// </summary>
        public virtual ICollection<StudentDeclarationJiaoWu> StudentDeclarationJiaoWus { get; set; }
        /// <summary>
        /// 教务教师用书申报
        /// </summary>
        public virtual ICollection<TeacherDeclarationJiaoWu> TeacherDeclarationJiaoWus { get; set; }
        /// <summary>
        /// 教学任务
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        #endregion

    }
}
