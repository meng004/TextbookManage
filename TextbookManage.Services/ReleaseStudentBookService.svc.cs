using System;
using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ReleaseStudentIndividualBookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ReleaseStudentIndividualBookService.svc 或 ReleaseStudentIndividualBookService.svc.cs，然后开始调试。
    public class ReleaseStudentBookService:IReleaseStudentBookAppl
    {
        private readonly IReleaseStudentBookAppl _impl = ServiceLocator.Current.GetInstance<IReleaseStudentBookAppl>();
        
        /// <summary>
        ///  根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
           return  _impl.GetSchoolByLoginName(loginName);
        }
        /// <summary>
        /// 取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
          return  _impl.GetGradeBySchoolId(schoolId);
        }
         /// <summary>
         /// 根据学院Id、年级取专业班级
         /// </summary>
         /// <param name="schoolId"></param>
         /// <param name="grade"></param>
         /// <returns></returns>
        public IEnumerable<ProfessionalClassView> GetClassBySchoolId(string schoolId, string grade)
        {
          return  _impl.GetClassBySchoolId(schoolId, grade);
        }
        /// <summary>
        /// 根据班级Id,取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<StudentView> GetStudentByClassId(string classId)
        {
           return  _impl.GetStudentByClassId(classId);
        }
        /// <summary>
        /// 根据书商Id，取仓库
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        public IEnumerable<StorageView> GetStorageByBooksellerId(string booksellerId)
        {
          return  _impl.GetStorageByBooksellerId(booksellerId);
        }
         /// <summary>
         /// 学生个人教材发放查询  
         /// </summary>
         /// <param name="studentId"></param>
         /// <param name="storageId"></param>
         /// <returns></returns>
        public IEnumerable<ReleaseBookForStudentQueryView> GetStudentBookByStudentId(string studentId, string storageId)
        {
           return _impl.GetStudentBookByStudentId(studentId, storageId);
        }
         /// <summary>
         /// 发放学生个人教材
         /// </summary>
         /// <param name="views"></param>
         /// <returns></returns>
        public ResponseView ReleaseStudentBookSubmit(IEnumerable<ReleaseBookSubmitForStudentView> views)
        {
           return _impl.ReleaseStudentBookSubmit(views);
        }
    }
}
