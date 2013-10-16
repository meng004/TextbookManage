using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Repositories
{
    public class ReleaseRecordRepository : EntityFrameworkRepository<ReleaseRecord>, IReleaseRecordRepository 
    {
        public ReleaseRecordRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
