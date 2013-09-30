using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;
using System.Linq;

namespace TextbookManage.Repositories.Jw
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public int GetStudentCountById(System.Guid classId)
        {
            //var sql = "SELECT COUNT(XH) FROM dbo.V_JCSJ_YXSXSB WHERE BJID=@ClassId";
            //SqlParameter param = new SqlParameter("@ClassId", classId);
            //int count = _unitOfWork.Database.SqlQuery<int>(sql, param).First();

            int count = DbSet.Where(t => t.Class_ID == classId).Count();
            return count;
        }
        
    }
}
