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
    /// 退还学生个人教材
    /// </summary>
    [ServiceContract]
    public interface IDropStudentBookAppl
    {
        /// <summary>
        ///  根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<SchoolView> GetSchoolByLoginName(string loginName);
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
        /// 根据学生ID，取学生个人可退还教材
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<DropBookForStudentQueryView> GetStudentDropBookByStudentId(string studentId); 
        /// <summary>
        /// 根据书商Id，发放记录Id，退还学生个人教材
        /// </summary>
        /// <param name="releaseRecordeIds"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseView DropStudenBookSubmit(IEnumerable<string> releaseRecordeIds,string studentId);
    }
}
