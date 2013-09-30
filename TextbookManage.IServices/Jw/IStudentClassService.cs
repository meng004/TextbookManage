using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface IStudentClassService
    {
        /// <summary>
        /// 根据学院ID、年级，取学生班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StudentClass> GetBySchoolId(string schoolId, string grade);

        /// <summary>
        /// 根据班级ID，取单个班级
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        StudentClass GetById(string classId);

        /// <summary>
        /// 根据学院ID，取年级列表
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<string> GetGradeBySchoolId(string schoolId);
    }
}
