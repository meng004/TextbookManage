using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TeacherRepository : EntityFrameworkRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
