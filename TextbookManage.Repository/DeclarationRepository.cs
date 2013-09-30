using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;
using System.Linq;

namespace TextbookManage.Repositories
{
    public class DeclarationRepository : Repository<Declaration>, IDeclarationRepository
    {
        public DeclarationRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public Feedback GetFeedbackByDeclarationId(int declarationId)
        {
            var result = DbSet.Where(t => t.DeclarationID == declarationId)
                .Select(t => t.Subscriptions.First())
                .Select(t => t.Feedback)
                .First();
            return result;
        }



    }
}
