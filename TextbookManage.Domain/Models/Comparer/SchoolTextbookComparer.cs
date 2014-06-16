using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models.Comparer
{
    /// <summary>
    /// 用书申报的比较器
    /// 按学院、教材比较
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SchoolTextbookComparer<T> : IEqualityComparer<T>
        where T : Declaration, new()
    {
        public bool Equals(T x, T y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            if (x.School_Id == y.School_Id && x.Textbook_Id == y.Textbook_Id)
                return true;
            else
                return false;
        }

        public int GetHashCode(T obj)
        {
            if (object.ReferenceEquals(obj, null))
                return 0;
            return obj.School_Id.GetHashCode() + obj.Textbook_Id.GetHashCode();
        }
    }
}
