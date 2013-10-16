using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;



namespace TextbookManage.Repositories
{
    public class TeachingTaskRepository : EntityFrameworkRepository<TeachingTask>, ITeachingTaskRepository
    {
        public TeachingTaskRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
