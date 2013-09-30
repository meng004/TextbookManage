namespace TextbookManage.Domain.IRepositories.Jw
{
    public interface IStudentRepository : IRepository<Domain.Models.Student>
    {
        /// <summary>
        /// 根据班级ID
        /// 取学生人数
        /// </summary>
        /// <param name="classId">班级ID</param>
        /// <returns></returns>
        int GetStudentCountById(System.Guid classId);
    }
}
