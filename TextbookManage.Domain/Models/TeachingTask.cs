using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class TeachingTask : IAggregateRoot
    {
        //public int TeachingTaskID { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public string Term 
        {
            get
            {
                return string.Format("{0}-{1}", XN, XQ);
            }
        }
        /// <summary>
        /// 学年
        /// </summary>
        public string XN { get; set; }
        /// <summary>
        /// 学期
        /// </summary>
        public string XQ { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public System.Guid Course_ID { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public string CourseNum { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 数据标识
        /// </summary>
        public string DataSign { get; set; }
        /// <summary>
        /// 开课学院ID
        /// </summary>
        public Nullable<System.Guid> SchoolID { get; set; }
        //public string SchoolNum { get; set; }
        /// <summary>
        /// 开课学院名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 开课系教研室ID
        /// </summary>
        public Nullable<System.Guid> Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// 开课系教研室名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 责任教师姓名
        /// </summary>
        public string ResponsibleTeacher { get; set; }
        /// <summary>
        /// 理论教师ID
        /// </summary>
        public Nullable<System.Guid> Teacher_ID { get; set; }
        /// <summary>
        /// 理论教师姓名
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 学生班级ID
        /// </summary>
        public Nullable<System.Guid> Class_ID { get; set; }
        /// <summary>
        /// 学生班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 学生总数
        /// </summary>
        public int StudentCount { get; set; }
    }
}
