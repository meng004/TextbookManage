using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class CasMapperRepository : EntityFrameworkRepository<CasMapper>, ICasMapperRepository
    {

        public CasMapperRepository(IRepositoryContext context)
            : base(context)
        {
            
        }
         
    }
}
