﻿using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.Models;


namespace TextbookManage.Applications.Impl
{
    public class CourseAppl
    {

        #region 私有变量

        private readonly ITeachingTaskRepository _teachingTaskRepo = ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        #endregion

        #region 共有方法

        /// <summary>
        /// 由系教研室ID与学期
        /// 取课程
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public IEnumerable<Course> GetCourseByDepartmentId(Guid departmentId, string term)
        {
            var currentTerm = new Term { YearTerm = term };

            //处理学期，为空则取当前学期
            if (string.IsNullOrWhiteSpace(term))
            {
                var termAppl = new TermAppl();
                currentTerm = termAppl.GetCurrentTerm();
            }

            //构造学年学期，与教务匹配
            var courses = _teachingTaskRepo.Find(t =>
                t.XNXQ.XN == currentTerm.SplitTerm.XN &&
                t.XNXQ.XQ == currentTerm.SplitTerm.XQ &&
                t.Department_Id == departmentId
                ).Select(t =>
                    t.Course
                    ).Distinct();

            return courses;
        }

        #endregion

    }
}
