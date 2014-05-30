using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;



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
