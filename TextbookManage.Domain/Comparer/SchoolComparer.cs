using System.Collections.Generic;


namespace TextbookManage.Domain.Comparer
{
    /// <summary>
    /// 学院比较器
    /// </summary>
    public class SchoolComparer : IEqualityComparer<Models.School>
    {
        public bool Equals(Models.School x, Models.School y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            return x.SchoolId == y.SchoolId;
        }

        public int GetHashCode(Models.School obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;
            return obj.SchoolId.GetHashCode();
        }
    }
}
