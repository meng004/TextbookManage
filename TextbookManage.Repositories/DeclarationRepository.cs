using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;


namespace TextbookManage.Repositories
{
    public class DeclarationRepository : EntityFrameworkRepository<DeclarationJiaoWu>, IDeclarationRepository
    {
        public DeclarationRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
