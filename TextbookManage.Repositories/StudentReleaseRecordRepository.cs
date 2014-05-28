using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class StudentReleaseRecordRepository : EntityFrameworkRepository<StudentReleaseRecord>, IStudentReleaseRecordRepository
    {

        public StudentReleaseRecordRepository(IRepositoryContext context)
            : base(context)
        {
            
        }
    }
}
