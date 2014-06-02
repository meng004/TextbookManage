using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.IRepositories;

namespace TextbookManage.Repositories
{
    public class StudentDeclarationJiaoWuRepository : EntityFrameworkRepository<StudentDeclarationJiaoWu>
        , IStudentDeclarationJiaoWuRepository
    {
        public StudentDeclarationJiaoWuRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

    }
}
