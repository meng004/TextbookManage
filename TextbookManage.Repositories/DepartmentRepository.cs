using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories
{
    public class DepartmentRepository : EntityFrameworkRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
