using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class StorageRepository : EntityFrameworkRepository<Storage>, IStorageRepository
    {
        public StorageRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
