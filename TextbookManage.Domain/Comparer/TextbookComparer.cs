using System.Collections.Generic;


namespace TextbookManage.Domain.Comparer
{
    public class TextbookComparer : IEqualityComparer<Models.Textbook>
    {
        public bool Equals(Models.Textbook x, Models.Textbook y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            return x.TextbookId == y.TextbookId;
        }

        public int GetHashCode(Models.Textbook obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;
            return obj.TextbookId.GetHashCode();
        }
    }
}
