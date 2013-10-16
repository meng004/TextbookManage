using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Applications.Impl
{
    public class ProfessionalClassAppl
    {

        #region 私有变量

        private readonly IProfessionalClassRepository _repo = ServiceLocator.Current.GetInstance<IProfessionalClassRepository>();
        #endregion

        #region 业务方法

        /// <summary>
        /// 由学院ID，取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetGradeBySchoolId(Guid schoolId)
        {
            var grade = _repo.Find(t =>
                t.School_Id == schoolId
                ).Select(t =>
                    t.Grade
                    ).Distinct();

            grade = grade.OrderByDescending(t => t);
            return grade;
        }

        /// <summary>
        /// 根据学院，年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public IEnumerable<ProfessionalClass> GetBySchoolIdAndGrade(Guid schoolId, string grade)
        {
            var classes = _repo.Find(t =>
                t.School_Id == schoolId &&
                t.Grade == grade
                );

            classes = classes.OrderBy(t => t.Name);
            return classes;
        }
        #endregion

    }
}
