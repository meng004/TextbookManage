using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace TextbookManage.Repositories
{
    public class BooksellerRepository : EntityFrameworkRepository<Bookseller>, IBooksellerRepository
    {
        public BooksellerRepository(IRepositoryContext context)
            : base(context)
        {

        }

        public System.Collections.Generic.IEnumerable<Subscription> GetSubscriptions(System.Guid booksellerId, SchoolYearTerm schoolYearTerm)
        {
            var ctx = this.EFContext.Context as TbMisDbContext;
            if (ctx != null)
            {
                var results = ctx.Subscriptions.Where(t => 
                    t.SchoolYearTerm.Year == schoolYearTerm.Year && 
                    t.SchoolYearTerm.Term == schoolYearTerm.Term && 
                    t.Bookseller_Id == booksellerId
                    );
                return results.ToList();
            }
            return new List<Subscription>();
        }
    }
}
