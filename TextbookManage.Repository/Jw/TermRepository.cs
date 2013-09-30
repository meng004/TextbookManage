using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;
using System.Linq;

namespace TextbookManage.Repositories.Jw
{
    public class TermRepository : Repository<Term>, ITermRepository
    {
        public TermRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
