using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;

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
