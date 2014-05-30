using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;

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
