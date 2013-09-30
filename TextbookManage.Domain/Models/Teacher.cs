using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Teacher : IAggregateRoot
    {
        /// <summary>
        /// 教师ID
        /// </summary>
        public System.Guid TeacherID { get; set; }
        /// <summary>
        /// 教师编号
        /// </summary>
        public string TeacherNum { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 学院ID
        /// </summary>
        public Nullable<System.Guid> School_ID { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        public string SchoolNum { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 系教研室ID
        /// </summary>
        public Nullable<System.Guid> Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// 系教研室名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
