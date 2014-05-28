using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.IRepositories;

namespace TextbookManage.Repositories
{
    public class OutStockRecordRepository : EntityFrameworkRepository<OutStockRecord>, IOutStockRecordRepository
    {
        public OutStockRecordRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
