namespace TextbookManage.Domain.IRepositories
{

    using System.Collections.Generic;

    public interface IProfessionalClassRepository : IRepository<Models.ProfessionalClass>
    {
        /// <summary>
        /// 根据学院ID，取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        IEnumerable<string> GetGradeBySchoolId(System.Guid schoolId);
    }
}
