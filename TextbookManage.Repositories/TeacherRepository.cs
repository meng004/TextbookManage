using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;

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
