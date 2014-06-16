using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;



namespace TextbookManage.Domain.Models.Comparer
{
    public class TextbookComparer : IEqualityComparer<Textbook>
    {
        public bool Equals(Textbook x, Textbook y)
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

        public int GetHashCode(Textbook obj)
        {
            if (object.ReferenceEquals(obj, null)) 
                return 0;
            return obj.ID.GetHashCode();
        }
    }
}
