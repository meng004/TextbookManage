using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;
using System.Linq;

namespace TextbookManage.Repositories.Jw
{
    public class StudentClassRepository : Repository<StudentClass>, IStudentClassRepository
    {
        public StudentClassRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public System.Collections.Generic.IEnumerable<string> GetGradeBySchoolId(System.Guid schoolId)
        {
            var grade = DbSet.Where(t => t.School_ID == schoolId)
                .Select(t => t.Grade)
                .Distinct()
                .OrderByDescending(t => t)
                .ToList();
            return grade;
        }
    }
}
