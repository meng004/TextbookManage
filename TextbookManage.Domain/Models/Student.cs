using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Student : IAggregateRoot
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public System.Guid StudentID { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        public string StudentNum { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public Nullable<System.Guid> Class_ID { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public string ClassNum { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }
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
    }
}
