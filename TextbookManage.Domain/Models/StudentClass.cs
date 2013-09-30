using System;

namespace TextbookManage.Domain.Models
{
    public class StudentClass : IAggregateRoot
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Guid ClassID { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public string ClassNum { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 学生总人数
        /// </summary>
        public int StudentCount { get; set; }
        /// <summary>
        /// 所属学院ID
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
