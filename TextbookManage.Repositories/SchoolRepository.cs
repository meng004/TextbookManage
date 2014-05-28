using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class SchoolRepository : EntityFrameworkRepository<School>, ISchoolRepository
    {
        public SchoolRepository(IRepositoryContext context)
            : base(context)
        {
            
        }
        
    }
}
