using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;


namespace TextbookManage.Repositories
{
    public class TermRepository : EntityFrameworkRepository<Term>, ITermRepository
    {
        public TermRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
