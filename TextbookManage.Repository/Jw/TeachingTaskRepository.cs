using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Repositories.Jw
{
    public class TeachingTaskRepository : Repository<TeachingTask>, ITeachingTaskRepository
    {
        public TeachingTaskRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public IEnumerable<Course> GetCourseByDepartmentId(System.Guid departmentId, string dataSignNum, string term)
        {
            var course = DbSet.Where(t =>
                t.Department_ID == departmentId &&
                t.DataSign == dataSignNum &&
                t.Term == term
                )
                .Select(t =>
                    new Course
                    {
                        CourseID = t.Course_ID,
                        Num = t.CourseNum,
                        Name = t.CourseName
                    }).ToList();
            return course;
        }

        public IEnumerable<System.Guid> GetStudentClassIdById(string teachingTaskNum)
        {
            var classes = DbSet.Where(t => t.TeachingTaskNum == teachingTaskNum)
                .Select(t => (System.Guid)t.Class_ID).ToList();

            return classes;
        }
    }
}
