using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;



namespace TextbookManage.Domain.Models.Comparer
{
    /// <summary>
    /// 学院比较器
    /// </summary>
    public class SchoolComparer : IEqualityComparer<School>
    {
        public bool Equals(School x, School y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            return x.ID == y.ID;
        }

        public int GetHashCode(School obj)
        {
            if (object.ReferenceEquals(obj, null)) 
                return 0;
            return obj.ID.GetHashCode();
        }
    }
}
