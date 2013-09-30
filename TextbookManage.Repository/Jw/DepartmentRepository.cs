using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Jw
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
