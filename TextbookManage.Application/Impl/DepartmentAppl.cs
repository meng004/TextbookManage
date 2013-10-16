using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Applications.Impl
{
    public class DepartmentAppl
    {

        #region 私有变量

        private readonly ITeacherRepository _teacherRepo = ServiceLocator.Current.GetInstance<ITeacherRepository>();
        private readonly ISchoolRepository _schoolRepo = ServiceLocator.Current.GetInstance<ISchoolRepository>();
        #endregion

        #region 共有方法

        /// <summary>
        /// 根据学院ID，取当前用户所属系教研室
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartmentBySchoolId(string loginName, Guid schoolId)
        {
            //取登录用户
            var tbmisUserAppl = new TbmisUserAppl(loginName);
            var user = tbmisUserAppl.GetUser();

            var departments = _teacherRepo.First(t =>
                            t.TeacherId == user.TbmisUserId
                            ).Departments
                            .Where(d =>
                                d.School_Id == schoolId
                                );

            return departments;
        }

        /// <summary>
        /// 取学院教研室
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartmentBySchoolId(Guid schoolId)
        {
            var departments = _schoolRepo.First(t => t.SchoolId == schoolId).Departments;

            return departments;
        }
        #endregion

    }
}
