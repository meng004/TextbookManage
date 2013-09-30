using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Jw
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {

        public SchoolRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
         
    }
}
