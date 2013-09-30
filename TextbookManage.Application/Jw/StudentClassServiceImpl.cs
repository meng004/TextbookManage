using System.Linq;
using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class StudentClassServiceImpl : IStudentClassService
    {

        private readonly IStudentClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;


        public StudentClassServiceImpl(IStudentClassRepository classRepository, IStudentRepository studentRepository)
        {
            _classRepository = classRepository;
            _studentRepository = studentRepository;
        }

        public IEnumerable<StudentClass> GetBySchoolId(string schoolId, string grade)
        {
            var id = schoolId.ConvertToGuid();
            var classes = _classRepository.Find(t => t.School_ID == id && t.Grade == grade);
            foreach (var item in classes)
            {
                item.StudentCount = _studentRepository.GetStudentCountById(item.ClassID);
            }
            return classes;
        }

        public StudentClass GetById(string classId)
        {
            var id = classId.ConvertToGuid();

            var stuClass = _classRepository.First(t => t.ClassID == id);
            stuClass.StudentCount = _studentRepository.GetStudentCountById(id);

            return stuClass;
        }

        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            return _classRepository.GetGradeBySchoolId(id);
        }
    }
}
