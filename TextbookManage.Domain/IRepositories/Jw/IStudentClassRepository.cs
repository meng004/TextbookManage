namespace TextbookManage.Domain.IRepositories.Jw
{

    using System.Collections.Generic;

    public interface IStudentClassRepository : IRepository<Models.StudentClass>
    {
        /// <summary>
        /// 根据学院ID，取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        IEnumerable<string> GetGradeBySchoolId(System.Guid schoolId);
    }
}
