using System.Collections.Generic;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Services.Jw
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“TeachingTaskService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 TeachingTaskService.svc 或 TeachingTaskService.svc.cs，然后开始调试。
    public class TeachingTaskService : ITeachingTaskService
    {

        private readonly ITeachingTaskService _serviceImpl = ServiceLocator.Current.GetInstance<ITeachingTaskService>();

        
        public IEnumerable<Course> GetCourseByDepartmentId(string departmentId, string dataSignNum, string term)
        {
            return _serviceImpl.GetCourseByDepartmentId(departmentId, dataSignNum, term);
        }

        public IEnumerable<TeachingTask> GetByCourseId(string courseId, string departmentId, string dataSignNum, string term)
        {
            return _serviceImpl.GetByCourseId(courseId, departmentId, dataSignNum, term);
        }

        public IEnumerable<StudentClass> GetStudentClassById(string teachingTaskNum)
        {
            return _serviceImpl.GetStudentClassById(teachingTaskNum);
        }



    }
}
