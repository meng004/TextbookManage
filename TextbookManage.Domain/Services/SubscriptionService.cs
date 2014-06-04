using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain
{
    public class SubscriptionService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="textbookId"></param>
        /// <param name="booksellerId"></param>
        /// <param name="declarations"></param>
        /// <param name="planCount"></param>
        /// <param name="spareCount"></param>
        /// <returns></returns>
        public static Subscription CreateSubscription(Guid subscriptionId, Guid textbookId, Guid booksellerId, SchoolYearTerm term, int planCount, int spareCount)
        {
            var sub = new Subscription
            {
                Bookseller_Id = booksellerId,
                PlanCount = planCount,
                SpareCount = spareCount,
                SubscriptionDate = DateTime.Now,
                ID = subscriptionId,
                Textbook_Id = textbookId,
                SchoolYearTerm = term
            };
            return sub;
        }

        /// <summary>
        /// 对教材进行汇总
        /// </summary>
        /// <param name="declarations">学生用书申报</param>
        /// <returns></returns>
        public static IEnumerable<Subscription> CreateSubscriptions(IEnumerable<StudentDeclarationJiaoWu> declarations)
        {
            //根据教材分组，统计申报数量
            //var result = from d in declarations
            //             group d by d.Textbook
            //                 into g
            //                 select new Subscription
            //                {
            //                    SubscriptionId = Guid.NewGuid(),
            //                    Textbook = g.Key,
            //                    Textbook_Id = g.Key.TextbookId,
            //                    PlanCount = g.Sum(t => t.DeclarationCount),
            //                    SpareCount = 0,
            //                    SubscriptionDate = DateTime.Now,
            //                    Term = declarations.FirstOrDefault().Term,
            //                    Declarations = declarations.Where(t => t.Textbook_Id == g.Key.TextbookId).ToList()
            //                };

            var result = declarations
                .GroupBy(t => t.Textbook, new TextbookComparer())
                //.GroupBy(t => t.Textbook)
                .Select(m =>
                    {
                        var declarationJiaoWus = declarations.Where(d => d.Textbook.ID == m.Key.ID).ToList();
                        var studentDeclarations = new List<StudentDeclaration>();
                        var id = Guid.NewGuid();
                        foreach (var item in declarationJiaoWus)
                        {
                            var studentDeclaration = new StudentDeclaration();

                            studentDeclaration.Course_Id = item.Course_Id;
                            studentDeclaration.DataSign_Id = item.DataSign_Id;
                            studentDeclaration.DeclarationCount = item.DeclarationCount;
                            studentDeclaration.ID = item.ID;
                            studentDeclaration.Department_Id = item.Department_Id;
                            studentDeclaration.School_Id = item.School_Id;
                            studentDeclaration.SchoolYearTerm = item.SchoolYearTerm;
                            studentDeclaration.Sfgd = item.Sfgd;
                            studentDeclaration.Textbook_Id = item.Textbook_Id;
                            studentDeclaration.Subscription_Id = id;

                            studentDeclarations.Add(studentDeclaration);
                        }
                        var subscription = new Subscription
                        {
                            ID = id,
                            Textbook_Id = m.Key.ID,
                            SchoolYearTerm = declarations.FirstOrDefault().SchoolYearTerm,
                            Textbook = m.Key,
                            PlanCount = m.Sum(s => s.DeclarationCount),
                            SpareCount = 0,
                            SubscriptionDate = DateTime.Now,
                            StudentDeclarations = studentDeclarations
                        };
                        return subscription;
                    });

            return result.ToList();
        }

        /// <summary>
        /// 对教材进行汇总
        /// </summary>
        /// <param name="declarations">教师用书申报</param>
        /// <returns></returns>
        public static IEnumerable<Subscription> CreateSubscriptions(IEnumerable<TeacherDeclarationJiaoWu> declarations)
        {
            //根据教材分组，统计申报数量
            //var result = from d in declarations
            //             group d by d.Textbook
            //                 into g
            //                 select new Subscription
            //                {
            //                    SubscriptionId = Guid.NewGuid(),
            //                    Textbook = g.Key,
            //                    Textbook_Id = g.Key.TextbookId,
            //                    PlanCount = g.Sum(t => t.DeclarationCount),
            //                    SpareCount = 0,
            //                    SubscriptionDate = DateTime.Now,
            //                    Term = declarations.FirstOrDefault().Term,
            //                    Declarations = declarations.Where(t => t.Textbook_Id == g.Key.TextbookId).ToList()
            //                };

            var result = declarations
                .GroupBy(t => t.Textbook, new TextbookComparer())
                //.GroupBy(t => t.Textbook)
                .Select(m => 
                    {
                        var declarationJiaoWus = declarations.Where(d => d.Textbook.ID == m.Key.ID).ToList();
                        var teacherDeclarations = new List<TeacherDeclaration>();
                        var id = Guid.NewGuid();
                        foreach (var item in declarationJiaoWus)
                        {
                            var teacherDeclaration = new TeacherDeclaration();

                            teacherDeclaration.Course_Id = item.Course_Id;
                            teacherDeclaration.DataSign_Id = item.DataSign_Id;
                            teacherDeclaration.DeclarationCount = item.DeclarationCount;
                            teacherDeclaration.ID = item.ID;
                            teacherDeclaration.Department_Id = item.Department_Id;
                            teacherDeclaration.School_Id = item.School_Id;
                            teacherDeclaration.SchoolYearTerm = item.SchoolYearTerm;
                            teacherDeclaration.Sfgd = item.Sfgd;
                            teacherDeclaration.Textbook_Id = item.Textbook_Id;
                            teacherDeclaration.Subscription_Id = id;

                            teacherDeclarations.Add(teacherDeclaration);
                        }
                        var subscription = new Subscription
                        {
                            ID = id,
                            Textbook_Id = m.Key.ID,
                            SchoolYearTerm = declarations.FirstOrDefault().SchoolYearTerm,
                            Textbook = m.Key,
                            PlanCount = m.Sum(s => s.DeclarationCount),
                            SpareCount = 0,
                            SubscriptionDate = DateTime.Now,
                            TeacherDeclarations = teacherDeclarations
                        };
                        return subscription;
                    });

            return result.ToList();
        }

        /// <summary>
        /// 向订单添加回告
        /// </summary>
        /// <param name="subscriptionPlan">订单</param>
        /// <param name="feedBackState">回告状态，成功或失败</param>
        /// <param name="remark">回告说明</param>
        /// <param name="feedbackPerson">回告人</param>
        /// <returns></returns>
        public static Feedback CreateFeedback(string feedbackPerson, bool feedBackState, string remark)
        {
            //创建回告
            var feedback = new Feedback
            {
                FeedbackDate = DateTime.Now, //true为征订成功
                FeedbackState = feedBackState ? FeedbackState.征订成功 : FeedbackState.征订失败,
                Remark = remark,
                Person = feedbackPerson, //教材科审核中
                ApprovalState = ApprovalState.教材科审核中 /*订单添加回告*/

            };

            return feedback;
        }


        #region 开课学院、学生学院

        /// <summary>
        /// 获取学生学院，教学任务的学生所在学院
        /// </summary>
        /// <param name="declarations">用书申报</param>
        /// <returns></returns>
        //public static IEnumerable<School> GetSchoolsForStudent(IEnumerable<Declaration> declarations)
        //{
        //    //var schools = (from d in declarations  //取用书申报
        //    //               from p in d.TeachingTask.ProfessionalClasses  //取学生班级
        //    //               select p.School).Distinct();

        //    var schools = declarations
        //        .SelectMany(t => t.TeachingTask.ProfessionalClasses)
        //        .Select(p => p.School)
        //        .Distinct().ToList();

        //    return schools;
        //}

        /// <summary>
        /// 获取开课学院，教材申报学院
        /// </summary>
        /// <param name="declarations">用书申报</param>
        /// <returns></returns>
        //public static IEnumerable<School> GetSchoolsForTeacher(IEnumerable<Declaration> declarations)
        //{
        //    //取开课学院
        //    //var schools = (from d in declarations
        //    //               select d.TeachingTask.Department.School).Distinct();

        //    var schools = declarations
        //        .Select(t => t.TeachingTask.Department.School)
        //        .Distinct();

        //    return schools.ToList();
        //}
        #endregion

    }
}
