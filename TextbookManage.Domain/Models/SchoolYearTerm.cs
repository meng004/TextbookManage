using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 学年学期
    /// 结构体，当作值对象
    /// </summary>
    public class SchoolYearTerm
    {
        /// <summary>
        /// 学年
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 学期
        /// </summary>
        public string Term { get; set; }
    }
}
