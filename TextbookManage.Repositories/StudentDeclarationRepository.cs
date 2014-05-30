using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Repositories
{
    public class StudentDeclarationRepository : EntityFrameworkRepository<StudentDeclaration>, IStudentDeclarationRepository
    {
        public StudentDeclarationRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
