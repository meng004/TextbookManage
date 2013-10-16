using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
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
