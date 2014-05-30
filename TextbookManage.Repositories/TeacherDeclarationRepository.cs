using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Repositories
{
    public class TeacherDeclarationRepository : EntityFrameworkRepository<TeacherDeclaration>, ITeacherDeclarationRepository
    {
        public TeacherDeclarationRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
