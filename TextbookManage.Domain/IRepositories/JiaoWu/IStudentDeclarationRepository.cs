using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.IRepositories.JiaoWu
{
    public interface IStudentDeclarationRepository : IRepository<StudentDeclaration>
    {
        /// <summary>
        /// 用书申报对应的教学任务，
        /// 取相应的学生班级集合
        /// </summary>
        /// <param name="declarationId">用书申报ID</param>
        /// <returns></returns>
        IEnumerable<ProfessionalClass> GetProfessionalClasses(System.Guid declarationId);

        /// <summary>
        /// 用书申报对应的教学任务，
        /// 取相应的学生学院集合
        /// </summary>
        /// <param name="declarationId">用书申报ID</param>
        /// <returns></returns>
        IEnumerable<School> GetSchools(System.Guid declarationId);
    }
}
