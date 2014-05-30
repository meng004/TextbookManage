using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.IRepositories.JiaoWu
{
    public interface ISchoolRepository:IRepository<School>
    {

        ///// <summary>
        ///// 根据id得到学院
        ///// </summary>
        ///// <param name="schoolId">学院ID</param>
        ///// <returns></returns>
        //School GetSchoolById(Guid schoolId);
        ///// <summary>
        ///// 获取全部学院
        ///// </summary>
        ///// <returns></returns>
        //IList<School> GetSchoolList();
        ///// <summary>
        ///// 根据用户id获取学院列表
        ///// </summary>
        ///// <param name="userAccountId">用户ID</param>
        ///// <returns></returns>
        //IList<School> GetSchoolListByTeachId(Guid userAccountId);
        ///// <summary>
        ///// 获取教研室列表
        ///// </summary>
        ///// <param name="schoolId">学院ID</param>
        ///// <param name="userAccountId">教师ID</param>
        ///// <returns></returns>
        //IList<Department> GetDepartmentListBySchoolIdAndTeacherId(Guid schoolId, Guid teacherId);

        ///// <summary>
        ///// 获取教研室列表
        ///// </summary>
        ///// <param name="schoolId">学院ID</param>
        ///// <returns></returns>
        //IList<Department> GetDepartmentListBySchoolId(Guid schoolId);

        ///// <summary>
        /////通过教师ID得到教师
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Teacher GetTeacherById(Guid id);

    }
}
