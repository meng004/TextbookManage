namespace TextbookManage.Domain.IRepositories.JiaoWu
{

    using System.Collections.Generic;
    using TextbookManage.Domain.Models.JiaoWu;

    public interface IProfessionalClassRepository : IRepository<ProfessionalClass>
    {
        /// <summary>
        /// 根据学院ID，取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        IEnumerable<string> GetGradeBySchoolId(System.Guid schoolId);
    }
}
