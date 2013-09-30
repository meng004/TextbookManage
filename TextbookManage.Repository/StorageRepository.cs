using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class StorageRepository : Repository<Storage>, IStorageRepository
    {
        public StorageRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
