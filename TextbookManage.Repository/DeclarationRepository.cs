using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;


namespace TextbookManage.Repositories
{
    public class DeclarationRepository : EntityFrameworkRepository<Declaration>, IDeclarationRepository
    {
        public DeclarationRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
