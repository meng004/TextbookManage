using System.Collections.Generic;



namespace TextbookManage.Domain.Models.JiaoWu
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
            return x.SchoolId == y.SchoolId;
        }

        public int GetHashCode(School obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;
            return obj.SchoolId.GetHashCode();
        }
    }
}
