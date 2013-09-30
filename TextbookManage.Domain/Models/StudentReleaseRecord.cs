using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 学生发放记录
    /// </summary>
    public class StudentReleaseRecord : ReleaseRecord
    {
        public StudentReleaseRecord()
        {
            this.RecipientType = RecipientType.Student;
        }
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Guid Class_ID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public System.Guid Student_ID { get; set; }
        /// <summary>
        /// 学号
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
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
