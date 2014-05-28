using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class DataSignRepository : EntityFrameworkRepository<DataSign>, IDataSignRepository
    {
        public DataSignRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
