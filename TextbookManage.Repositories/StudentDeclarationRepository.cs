using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Repositories.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Repositories
{
    public class StudentDeclarationRepository : EntityFrameworkRepository<StudentDeclaration>,
        IStudentDeclarationRepository
    {
        public StudentDeclarationRepository(IRepositoryContext context)
            : base(context)
        {

        }


        public IEnumerable<ProfessionalClass> GetProfessionalClasses(System.Guid declarationId)
        {
            if (EfContext.Context is TbMisDbContext ctx)
            {
                var declaration = Single(t => t.ID == declarationId).DeclarationJiaoWu;
                if (declaration != null)
                {
                    //取教学任务集合
                    var teachingTasks = ctx.TeachingTasks.Where(t =>
                        t.SchoolYearTerm.Year == declaration.SchoolYearTerm.Year &&
                        t.SchoolYearTerm.Term == declaration.SchoolYearTerm.Term &&
                        t.Course_Id == declaration.Course_Id &&
                        t.Department_Id == declaration.Department_Id &&
                        t.DataSign_Id == declaration.DataSign_Id
                        );
                    //取班级集合
                    var professionalClasses = teachingTasks.SelectMany(t =>
                        t.ProfessionalClasses).Distinct();
                    return professionalClasses;
                }
            }
            return new List<ProfessionalClass>();
        }


        public IEnumerable<School> GetSchools(System.Guid declarationId)
        {
            var classes = GetProfessionalClasses(declarationId).ToList();
            if (classes.Any())
            {
                var schools = classes.Select(t => t.School).Distinct();
                return schools;
            }
            return new List<School>();
        }
    }
}
