using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class TeachingTaskServiceImpl : ITeachingTaskService
    {

        private readonly ITeachingTaskRepository _repository;
        private readonly IStudentClassRepository _classRepository;
        private readonly IStudentRepository _studentRepo;

        public TeachingTaskServiceImpl(ITeachingTaskRepository repository, IStudentClassRepository classRepository, IStudentRepository studentRepo)
        {
            _repository = repository;
            _classRepository = classRepository;
            _studentRepo = studentRepo;
        }


        public IEnumerable<Course> GetCourseByDepartmentId(string departmentId, string dataSignNum, string term)
        {
            var id = departmentId.ConvertToGuid();
            return _repository.GetCourseByDepartmentId(id, dataSignNum, term);
        }

        public IEnumerable<TeachingTask> GetByCourseId(string courseId, string departmentId, string dataSignNum, string term)
        {
            var id = courseId.ConvertToGuid();
            var departId = departmentId.ConvertToGuid();
            return _repository.Find(t => t.Course_ID == id && t.Department_ID==departId && t.DataSign == dataSignNum && t.Term == term);
        }

        public IEnumerable<StudentClass> GetStudentClassById(string teachingTaskNum)
        {
            //取班级ID
            var ids = _repository.GetStudentClassIdById(teachingTaskNum);

            var stuClasses = new List<StudentClass>();
            //取班级            
            foreach (var item in ids)
            {
                var stuClass = _classRepository.First(t => t.ClassID == item);
                stuClasses.Add(stuClass);
            }
            //取学生人数
            foreach (var item in stuClasses)
            {
                item.StudentCount = _studentRepo.GetStudentCountById(item.ClassID);
            }
            return stuClasses;
        }
    }
}
