using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class TeacherServiceImpl : ITeacherService
    {

        private readonly ITeacherRepository _repository;


        public TeacherServiceImpl(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Teacher> GetByDepartmentId(string departmentId)
        {
            var id = departmentId.ConvertToGuid();
            return _repository.Find(t => t.Department_ID == id);
        }

        public Teacher GetById(string teacherId)
        {
            var id = teacherId.ConvertToGuid();
            return _repository.First(t => t.TeacherID == id);
        }
    }
}
