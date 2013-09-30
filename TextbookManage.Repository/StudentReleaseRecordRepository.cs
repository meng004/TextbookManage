using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class StudentReleaseRecordRepository : Repository<StudentReleaseRecord>, IStudentReleaseRecordRepository
    {
        public StudentReleaseRecordRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
