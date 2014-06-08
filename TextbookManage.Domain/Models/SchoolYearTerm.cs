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
        /// 2013-2014
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 学期
        /// 2
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// 学年学期
        /// 2013-2014-2
        /// </summary>
        public override string ToString()
        {
            return Year + "-" + Term; 
        }
    }
}
