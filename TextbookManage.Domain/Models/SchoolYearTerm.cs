using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Infrastructure;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 学年学期
    /// 结构体，当作值对象
    /// </summary>
    public class SchoolYearTerm:IComparable
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
            return String.Format("{0}-{1}", Year, Term); 
        }

        public int CompareTo(object obj)
        {
            var yearTerm = obj as SchoolYearTerm;
            //学年学期比较
            //学年大的，较大
            if (this.Year.Substring(0, 4).ConvertToInt() < yearTerm.Year.Substring(0, 4).ConvertToInt())
                return 1;
            if (this.Year.Substring(0, 4).ConvertToInt() > yearTerm.Year.Substring(0, 4).ConvertToInt())
                return -1;
            
            //学年相同，学期大的较大
            if (this.Term.ConvertToInt() < yearTerm.Term.ConvertToInt())
                return 1;
            if (this.Term.ConvertToInt() > yearTerm.Term.ConvertToInt())
                return -1;
            else
                return 0;
        }


    }
}
