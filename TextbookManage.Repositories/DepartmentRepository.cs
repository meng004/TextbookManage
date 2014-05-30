using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;

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
