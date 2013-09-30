using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Jw
{
    public class DataSignRepository : Repository<DataSign>, IDataSignRepository
    {
        public DataSignRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
