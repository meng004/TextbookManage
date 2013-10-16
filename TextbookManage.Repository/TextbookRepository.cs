using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TextbookRepository : EntityFrameworkRepository<Textbook>, ITextbookRepository
    {
        public TextbookRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
