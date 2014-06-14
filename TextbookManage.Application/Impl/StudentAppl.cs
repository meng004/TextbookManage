using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Applications.Impl
{
    public class StudentAppl
    {

        #region 私有变量

        private readonly IStudentRepository _repo = ServiceLocator.Current.GetInstance<IStudentRepository>();
        #endregion

        #region 业务方法

        /// <summary>
        /// 根据班级取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<Student> GetByProfessionalClassId(Guid classId)
        {
            return _repo.Find(t =>
                t.ProfessionalClass_Id == classId
                );
        }

        /// <summary>
        /// 由学号取姓名
        /// </summary>
        /// <param name="studentNum"></param>
        /// <returns></returns>
        public string GetNameByNum(string studentNum)
        {
            var student = _repo.First(t =>
                t.Num == studentNum
                );

            if (student == null)
            {
                return "没有该学生";
            }
            else
            {
                return student.Name;
            }
        }

        /// <summary>
        /// 由学籍ID，取学生
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student GetById(Guid studentId)
        {
            return _repo.First(t => t.ID == studentId);
        }
        #endregion

    }
}
