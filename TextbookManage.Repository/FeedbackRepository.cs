using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Repositories
{
    public class FeedbackRepository : EntityFrameworkRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
