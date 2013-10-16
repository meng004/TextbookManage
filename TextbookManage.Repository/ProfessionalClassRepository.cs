using TextbookManage.Domain.IRepositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.Models;
using System.Linq;

namespace TextbookManage.Repositories
{
    public class ProfessionalClassRepository : EntityFrameworkRepository<ProfessionalClass>, IProfessionalClassRepository
    {
        public ProfessionalClassRepository(IRepositoryContext context)
            : base(context)
        {
            
        }

        public System.Collections.Generic.IEnumerable<string> GetGradeBySchoolId(System.Guid schoolId)
        {
            var grade = _dbSet.AsNoTracking().AsParallel()
                .Where(t => t.School_Id == schoolId)
                .Select(t => t.Grade)
                .Distinct()
                .OrderByDescending(t => t)
                .ToList();
            return grade;
        }
    }
}
