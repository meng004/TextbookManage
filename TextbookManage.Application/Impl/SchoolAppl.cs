using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Applications.Impl
{
    public class SchoolAppl
    {

        #region 私有变量

        private readonly ITeacherRepository _teacherRepo = ServiceLocator.Current.GetInstance<ITeacherRepository>();
        private readonly ISchoolRepository _schoolRepo = ServiceLocator.Current.GetInstance<ISchoolRepository>();

        #endregion

        #region 业务方法

        /// <summary>
        /// 获取当前登录用户的学院
        /// </summary>
        /// <returns></returns>
        public IEnumerable<School> GetSchoolOfUser(string loginName)
        {
            //取业务用户
            var user = new TbmisUserAppl(loginName).GetUser();

            var schools = _teacherRepo.First(t => t.TeacherId == user.TbmisUserId)
                  .Departments
                  .Select(t => t.School);

            return schools;
        }

        /// <summary>
        /// 取学院
        /// </summary>
        /// <returns></returns>
        public IEnumerable<School> GetSchools()
        {
            var schools = _schoolRepo.GetAll();

            return schools;
        }

        #endregion

    }
}
