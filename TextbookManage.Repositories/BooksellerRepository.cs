using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class BooksellerRepository : EntityFrameworkRepository<Bookseller>, IBooksellerRepository
    {
        public BooksellerRepository(IRepositoryContext context)
            : base(context)
        {
            
        }
    }
}
