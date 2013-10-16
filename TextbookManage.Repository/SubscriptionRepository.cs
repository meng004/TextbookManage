using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class SubscriptionRepository : EntityFrameworkRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
