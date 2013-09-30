using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices.Jw
{
    [ServiceContract]
    public interface IStudentService
    {
        /// <summary>
        /// 根据班级ID，取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<Student> GetByClassId(string classId);

        /// <summary>
        /// 根据学生ID，取单个学生
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        Student GetById(string studentId);

    }
}
