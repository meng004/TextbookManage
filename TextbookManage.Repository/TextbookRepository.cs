using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TextbookRepository : Repository<Textbook>, ITextbookRepository
    {
        public TextbookRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
