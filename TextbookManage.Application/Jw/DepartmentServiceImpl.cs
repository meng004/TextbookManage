using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class DepartmentServiceImpl : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;


        public DepartmentServiceImpl(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Department> GetBySchoolId(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            return _repository.Find(t => t.School_ID == id);
        }

        public Department GetById(string departmentId)
        {
            var id = departmentId.ConvertToGuid();
            return _repository.First(t => t.DepartmentID == id);
        }
    }
}
