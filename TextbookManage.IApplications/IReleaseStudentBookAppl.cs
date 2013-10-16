using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{  
    /// <summary>
    /// 学生个人教材发放
    /// </summary>
   [ServiceContract]
   public interface IReleaseStudentBookAppl
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
        /// 根据班级Id,取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<StudentView> GetStudentByClassId(string classId);
        /// <summary>
        /// 根据书商Id，取仓库
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<StorageView> GetStorageByBooksellerId(string booksellerId);
        
        /// <summary>
        /// 学生个人教材发放查询                                                            
        /// </summary>
        /// <param name="studentId">学生Id</param>
        /// <param name="storageId">仓库Id</param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<ReleaseBookForStudentQueryView> GetStudentBookByStudentId(string studentId, string storageId);  
        /// <summary>
        /// 发放学生个人教材
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseView ReleaseStudentBookSubmit(IEnumerable<ReleaseBookSubmitForStudentView> views);
    }
}
