using System;
using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ReleaseClassBookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ReleaseClassBookService.svc 或 ReleaseClassBookService.svc.cs，然后开始调试。
    public class ReleaseClassBookService : IReleaseClassBookAppl
    {
        private readonly IReleaseClassBookAppl _impl = ServiceLocator.Current.GetInstance<IReleaseClassBookAppl>();



        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            return _impl.GetSchoolByLoginName(loginName);
        }

        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            return _impl.GetGradeBySchoolId(schoolId);
        }

        public IEnumerable<ProfessionalClassBaseView> GetClassBySchoolId(string schoolId, string grade)
        {
            return _impl.GetClassBySchoolId(schoolId, grade);
        }

        public IEnumerable<StorageView> GetStorages(string loginName)
        {
            return _impl.GetStorages(loginName);
        }

        public ResponseView GetStudentNameByStudentNum(string studentNum)
        {
            return _impl.GetStudentNameByStudentNum(studentNum);
        }

        public IEnumerable<InventoryForReleaseClassView> GetInventoriesByClassId(string classId, string storageId)
        {
            return _impl.GetInventoriesByClassId(classId, storageId);
        }

        public IEnumerable<StudentView> GetNotReleaseStudents(string classId, string textbookId)
        {
            return _impl.GetNotReleaseStudents(classId, textbookId);
        }

        public ResponseView SubmitReleaseClass(IEnumerable<InventoryForReleaseClassView> inventoryViews, ReleaseBookForClassView releaseView)
        {
            return _impl.SubmitReleaseClass(inventoryViews, releaseView);
        }
    }
}
