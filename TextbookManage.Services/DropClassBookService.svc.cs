using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DropClassBookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DropClassBookService.svc 或 DropClassBookService.svc.cs，然后开始调试。
    public class DropClassBookService : IDropClassBookAppl
    {
        private readonly IDropClassBookAppl _impl = ServiceLocator.Current.GetInstance<IDropClassBookAppl>();

        /// <summary>
        ///  根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            return _impl.GetSchoolByLoginName(loginName);
        }
        /// <summary>
        /// 取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            return _impl.GetGradeBySchoolId(schoolId);
        }
        /// <summary>
        /// 根据学院Id、年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public IEnumerable<ProfessionalClassView> GetClassBySchoolId(string schoolId, string grade)
        {
            return _impl.GetClassBySchoolId(schoolId, grade);
        }
        /// <summary>
        ///  根据班级Id，教材Id,获取领用人名单
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.StudentForRecipientsView> GetRecipientsByTextbookId(string classId, string textbookId)
        {
            return _impl.GetRecipientsByTextbookId(classId, textbookId);
        }
        /// <summary>
        ///  根据班级Id，取班级可退教材
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.DorpBookForClassQueryView> GetClassDropBookByClassId(string classId)
        {
            return _impl.GetClassDropBookByClassId(classId);
        }
        /// <summary>
        /// 退还班级教材
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="releaseRecordIds"></param>
        /// <returns></returns>
        public ViewModels.ResponseView DropClassBookSubmit(string classId, IEnumerable<string> releaseRecordIds)
        {
            return _impl.DropClassBookSubmit(classId, releaseRecordIds);
        }
    }                                                                                           
}
