using System;
using System.Collections.Generic;
using TextbookManage.Infrastructure;


namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 实体类学年学期
    /// 用于从数据库映射
    /// </summary>
    public class Term : AggregateRoot
    {

        #region 属性

        /// <summary>
        /// 学年学期
        /// </summary>
        public string YearTerm { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 当前学年学期标志
        /// 1为当前，0为非当前
        /// </summary>
        public string DqXnXqBz { get; set; }
        /// <summary>
        /// 是否当前学年学期
        /// 将字符串类型的当前学年学期标志转换为bool
        /// 可接受字符为true\yes\y\1\ok\是
        /// </summary>
        public bool IsCurrent
        {
            get
            {
                return DqXnXqBz.ConvertToBool();
            }
            set
            {
                DqXnXqBz = value ? "1" : "0";
            }
        }
        #endregion

        #region 业务方法

        /// <summary>
        /// 将合体的学年学期分离
        /// 格式由2011-2012-2变身2011-2012，2
        /// </summary>
        public SchoolYearTerm SchoolYearTerm
        {
            get
            {
                var result = new SchoolYearTerm
                {
                    Year = YearTerm.Substring(0, 9),
                    Term = YearTerm.Substring(10, 1)
                };
                return result;
            }
        }
        #endregion

    }
}
