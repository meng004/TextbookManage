using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;


namespace TextbookManage.Repositories
{
    public class TermRepository : EntityFrameworkRepository<Term>, ITermRepository
    {
        public TermRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
