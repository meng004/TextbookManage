using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Repositories
{
    public class InventoryRepository : EntityFrameworkRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
