using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TbmisUserRepository : EntityFrameworkRepository<TbmisUser>, ITbmisUserRepository
    {
        public TbmisUserRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
