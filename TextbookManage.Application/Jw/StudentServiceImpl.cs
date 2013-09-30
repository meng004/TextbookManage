using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class StudentServiceImpl : IStudentService
    {

        private readonly IStudentRepository _repository;


        public StudentServiceImpl(IStudentRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Student> GetByClassId(string classId)
        {
            var id = classId.ConvertToGuid();
            return _repository.Find(t => t.Class_ID == id);
        }

        public Student GetById(string studentId)
        {
            var id = studentId.ConvertToGuid();
            return _repository.First(t => t.StudentID == id);
        }
    }
}
