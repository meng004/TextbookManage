using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;

namespace TextbookManage.Repositories
{
    public class TextbookRepository : EntityFrameworkRepository<Textbook>, ITextbookRepository
    {
        public TextbookRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
