using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class TeacherReleaseRecordRepository : EntityFrameworkRepository<TeacherReleaseRecord>, ITeacherReleaseRecordRepository
    {
        public TeacherReleaseRecordRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
