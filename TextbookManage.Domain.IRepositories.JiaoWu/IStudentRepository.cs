using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.IRepositories.JiaoWu
{
    public interface IStudentRepository : IRepository<Student>
    {
        ///// <summary>
        ///// 根据班级ID
        ///// 取学生人数
        ///// </summary>
        ///// <param name="classId">班级ID</param>
        ///// <returns></returns>
        //int GetStudentCountById(System.Guid classId);
    }
}
