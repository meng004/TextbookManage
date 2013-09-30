using System.Collections.Generic;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Services.Jw
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“StudentClassService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 StudentClassService.svc 或 StudentClassService.svc.cs，然后开始调试。
    public class StudentClassService : IStudentClassService
    {

        private readonly IStudentClassService _serviceImpl = ServiceLocator.Current.GetInstance<IStudentClassService>();

        public IEnumerable<StudentClass> GetBySchoolId(string schoolId,string grade)
        {
            return _serviceImpl.GetBySchoolId(schoolId, grade);
        }

        public StudentClass GetById(string classId)
        {
            return _serviceImpl.GetById(classId);
        }
        
        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            return _serviceImpl.GetGradeBySchoolId(schoolId);
        }
    }
}
