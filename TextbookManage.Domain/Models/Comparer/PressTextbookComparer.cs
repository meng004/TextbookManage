using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models.Comparer
{
    public class PressTextbookComparer<T> : IEqualityComparer<T>
        where T : DeclarationJiaoWu
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
            if (x.Textbook.Press == y.Textbook.Press && x.Textbook_Id == y.Textbook_Id)
                return true;
            else
                return false;
        }

        public int GetHashCode(T obj)
        {
            if (object.ReferenceEquals(obj, null))
                return 0;
            return obj.Textbook.Press.GetHashCode() + obj.Textbook_Id.GetHashCode();
        }
    }
}
