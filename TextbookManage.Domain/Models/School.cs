using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class School : IAggregateRoot
    {
        /// <summary>
        /// 学院ID
        /// </summary>
        public System.Guid SchoolID { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string Name { get; set; }
    }
}
