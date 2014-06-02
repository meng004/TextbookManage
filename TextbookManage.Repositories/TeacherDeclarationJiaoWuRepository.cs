using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Repositories
{
    public class TeacherDeclarationJiaoWuRepository : EntityFrameworkRepository<TeacherDeclarationJiaoWu>
        , ITeacherDeclarationJiaoWuRepository
    {
        public TeacherDeclarationJiaoWuRepository(IRepositoryContext context)
            : base(context)
        {

        }
    }
}
