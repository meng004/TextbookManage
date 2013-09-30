using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TeacherReleaseRecordRepository : Repository<TeacherReleaseRecord>, ITeacherReleaseRecordRepository
    {
        public TeacherReleaseRecordRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
