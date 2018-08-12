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

        public IEnumerable<Subscription> GetSubscriptions(System.Guid booksellerId, SchoolYearTerm schoolYearTerm)
        {
            if (!(EfContext.Context is TbMisDbContext ctx)) return new List<Subscription>();
            var results = ctx.Subscriptions.Where(t => 
                t.SchoolYearTerm.Year == schoolYearTerm.Year && 
                t.SchoolYearTerm.Term == schoolYearTerm.Term && 
                t.Bookseller_Id == booksellerId
            );
            return results.ToList();
        }
    }
}
