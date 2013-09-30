using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Jw
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
