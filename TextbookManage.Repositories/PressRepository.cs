using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;

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
