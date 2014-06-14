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
    public class SchoolYearTerm : IComparable, IComparable<SchoolYearTerm>, IEquatable<SchoolYearTerm>
    {

        #region 构造函数
        public SchoolYearTerm()
        {

        }
        public SchoolYearTerm(string yearTerm)
        {
            YearTerm = yearTerm;
        }
        #endregion

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
        }
        /// <summary>
        /// 学年
        /// 2013-2014
        /// </summary>
        public string Year
        {
            get
            {
                if (string.IsNullOrWhiteSpace(YearTerm))
                    return string.Empty;
                else
                    return YearTerm.Substring(0, 9);
            }
        }
        /// <summary>
        /// 学期
        /// 2
        /// </summary>
        public string Term
        {
            get
            {
                if (string.IsNullOrWhiteSpace(YearTerm))
                    return string.Empty;
                else
                    return YearTerm.Substring(10, 1);
            }
        }
        #endregion

        #region 重写ToString
        /// <summary>
        /// 学年学期
        /// 2013-2014-2
        /// </summary>
        public override string ToString()
        {
            return YearTerm;
        }
        #endregion

        #region 实现接口IComparable,IEquatable
        public int CompareTo(object obj)
        {
            var right = obj as SchoolYearTerm;
            //学年学期比较
            if (right.YearTerm == this.YearTerm)
                return 0;
            else
            {
                var leftYear = this.Year.Substring(0, 4).ConvertToInt();
                var rightYear = right.Year.Substring(0, 4).ConvertToInt();
                var leftTerm = this.Term.ConvertToInt();
                var rightTerm = right.Term.ConvertToInt();
                //学年大的，较大
                if (leftYear > rightYear)
                    return 1;
                if (leftYear < rightYear)
                    return -1;

                //学年相同，学期大的较大
                if (leftTerm > rightTerm)
                    return 1;
                if (leftTerm < rightTerm)
                    return -1;
                else
                    return 0;
            }
        }

        public int CompareTo(SchoolYearTerm other)
        {
            return this.CompareTo(other);
        }

        public bool Equals(SchoolYearTerm other)
        {
            return this.Equals(other);
        }
        #endregion

        #region 重写Equals
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.CompareTo(obj) == 0;
        }

        public override int GetHashCode()
        {
            return Year.GetHashCode() + Term.GetHashCode();
        }
        #endregion

        #region 重写比较运算符

        public static bool operator ==(SchoolYearTerm left, SchoolYearTerm right)
        {
            var result = left.CompareTo(right);
            return result == 0;
        }

        public static bool operator !=(SchoolYearTerm left, SchoolYearTerm right)
        {
            var result = left.CompareTo(right);
            return result != 0;
        }

        public static bool operator >(SchoolYearTerm left, SchoolYearTerm right)
        {
            var result = left.CompareTo(right);
            return result == 1;
        }

        public static bool operator <(SchoolYearTerm left, SchoolYearTerm right)
        {
            var result = left.CompareTo(right);
            return result == -1;
        }
        #endregion

    }
}
