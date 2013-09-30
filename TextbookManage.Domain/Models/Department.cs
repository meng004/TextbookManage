using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Department : IAggregateRoot
    {
        /// <summary>
        /// 系教研室ID
        /// </summary>
        public System.Guid DepartmentID { get; set; }
        /// <summary>
        /// 系教研室编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
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
