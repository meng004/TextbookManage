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
            this.yearTerm = yearTerm;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 学年学期
        /// </summary>
        private string yearTerm { get; set; }

        private string year;
        /// <summary>
        /// 学年
        /// 2013-2014
        /// </summary>
        public string Year
        {
            get
            {
                if (string.IsNullOrWhiteSpace(year))
                {
                    if (string.IsNullOrWhiteSpace(yearTerm))
                        return string.Empty;
                    else
                        return yearTerm.Substring(0, 9);
                }
                else
                    return year;
            }
            set
            {
                year = value;
            }
        }
        private string term;
        /// <summary>
        /// 学期
        /// 2
        /// </summary>
        public string Term
        {
            get
            {
                if (string.IsNullOrWhiteSpace(term))
                {
                    if (string.IsNullOrWhiteSpace(yearTerm))
                        return string.Empty;
                    else
                        return yearTerm.Substring(10, 1);
                }
                else
                    return term;
            }
            set
            {
                term = value;
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
            return yearTerm;
        }
        #endregion

        #region 实现接口IComparable,IEquatable
        public int CompareTo(object obj)
        {
            if (object.ReferenceEquals(this, null) || object.ReferenceEquals(obj, null))
                throw new NullReferenceException("对象等于Null，应初始化");
            var right = obj as SchoolYearTerm;
            return CompareTo(right);
        }

        public int CompareTo(SchoolYearTerm other)
        {
            if (object.ReferenceEquals(this, null) || object.ReferenceEquals(other, null))
                throw new NullReferenceException("对象等于Null，应初始化");
            if (string.IsNullOrWhiteSpace(this.yearTerm) || string.IsNullOrWhiteSpace(other.yearTerm))
                throw new ArgumentNullException("YearTerm等于null，使用前应初始化");
            //学年学期比较
            if (other.yearTerm == this.yearTerm)
                return 0;
            else
            {
                var leftYear = this.Year.Substring(0, 4).ConvertToInt();
                var rightYear = other.Year.Substring(0, 4).ConvertToInt();
                var leftTerm = this.Term.ConvertToInt();
                var rightTerm = other.Term.ConvertToInt();
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

        public bool Equals(SchoolYearTerm other)
        {
            if (this == other)
            {
                return true;
            }
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }

            return this.GetHashCode() == other.GetHashCode();
        }
        #endregion

        #region 重写Equals
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            if (object.ReferenceEquals(this, null) || object.ReferenceEquals(obj, null))
                return false;

            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (object.ReferenceEquals(this, null))
                return 0;
            return yearTerm.GetHashCode();
        }
        #endregion

        #region 重写比较运算符

        public static bool operator ==(SchoolYearTerm left, SchoolYearTerm right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            return left.GetHashCode() == right.GetHashCode();
        }

        public static bool operator !=(SchoolYearTerm left, SchoolYearTerm right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            return left.GetHashCode() != right.GetHashCode();
        }

        public static bool operator >(SchoolYearTerm left, SchoolYearTerm right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            return left.CompareTo(right) == 1;
        }

        public static bool operator <(SchoolYearTerm left, SchoolYearTerm right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            return left.CompareTo(right) == -1;
        }
        #endregion

    }
}
