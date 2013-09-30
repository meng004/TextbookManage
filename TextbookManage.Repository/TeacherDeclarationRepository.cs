using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TeacherDeclarationRepository:Repository<TeacherDeclaration>,ITeacherDeclarationRepository
    {
        public TeacherDeclarationRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
