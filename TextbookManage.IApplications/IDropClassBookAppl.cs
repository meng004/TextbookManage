using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 退还班级教材
    /// </summary>
    [ServiceContract]
   public interface IDropClassBookAppl
    {
        /// <summary>
        ///  根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<SchoolView> GetSchoolByLoginName(string booksellerId);
        /// <summary>
        /// 取年级
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<string> GetGradeBySchoolId(string schoolId);
        /// <summary>
        /// 根据学院Id、年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<ProfessionalClassView> GetClassBySchoolId(string schoolId, string grade);  

        /// <summary>
        ///  根据班级Id，教材Id,获取领用人名单
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<StudentForRecipientsView> GetRecipientsByTextbookId(string classId, string textbookId);
         /// <summary>
         ///  根据班级Id，取班级可退教材
         /// </summary>
         /// <param name="classId"></param>
         /// <returns></returns>
        [OperationContract]
        IEnumerable<DorpBookForClassQueryView>  GetClassDropBookByClassId(string classId);
        /// <summary>
        /// 退还班级教材
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="releaseRecordIds"></param>
        /// <returns></returns>
        ResponseView DropClassBookSubmit(string classId,IEnumerable<string> releaseRecordIds);
    }
}
