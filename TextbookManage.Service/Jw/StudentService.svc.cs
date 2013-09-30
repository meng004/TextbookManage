using System.Collections.Generic;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Services.Jw
{
 
    public class StudentService : IStudentService
    {

        private readonly IStudentService _serviceImpl = ServiceLocator.Current.GetInstance<IStudentService>();

        
        public IEnumerable<Student> GetByClassId(string classId)
        {
            return _serviceImpl.GetByClassId(classId);
        }

        public Student GetById(string studentId)
        {
            return _serviceImpl.GetById(studentId);
        }
    }
}
