using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class PressRepository : EntityFrameworkRepository<Press>, IPressRepository
    {
        public PressRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
