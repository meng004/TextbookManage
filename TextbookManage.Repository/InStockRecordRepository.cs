using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories.EntityFramework;


namespace TextbookManage.Repositories
{
    public class InStockRecordRepository: EntityFrameworkRepository<InStockRecord> ,IInStockRecordRepository
    {
        public InStockRecordRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
