using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;


namespace TextbookManage.Repositories
{
    public class StudentRepository : EntityFrameworkRepository<Student>, IStudentRepository
    {
        public StudentRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
