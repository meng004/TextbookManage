using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.Models.Comparer;

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

        #region 汇总申报，生成订单
        /// <summary>
        /// 对教材汇总，生成订单
        /// </summary>
        /// <param name="studentDeclarations">学生用书申报</param>
        /// <param name="teacherDeclarations">教师用书申报</param>
        /// <returns></returns>
        public static IEnumerable<Subscription> CreateSubscriptions(IEnumerable<StudentDeclarationJiaoWu> studentDeclarations, IEnumerable<TeacherDeclarationJiaoWu> teacherDeclarations)
        {
            //合并教师用书申报与学生用书申报
            var declarations = studentDeclarations.Union<DeclarationJiaoWu>(teacherDeclarations);
            //分组
            var result = declarations
                .GroupBy(t => t.Textbook, new TextbookComparer())  //教材选择器
                .Select(m =>
                    {
                        //取教材ID相同的申报
                        var studentDeclarationJiaoWus = studentDeclarations.Where(d => d.Textbook.ID == m.Key.ID).ToList();
                        var teacherDeclarationJiaoWus = teacherDeclarations.Where(d => d.Textbook_Id == m.Key.ID).ToList();
                        //转换为教材用书申报
                        var studentDeclarationTextbooks = studentDeclarationJiaoWus.ConvertAll(Converter);
                        var teacherDeclarationTextbooks = teacherDeclarationJiaoWus.ConvertAll(Converter);

                        //新建订单
                        var subscription = new Subscription
                        {
                            ID = Guid.NewGuid(),
                            Textbook_Id = m.Key.ID,
                            SchoolYearTerm = declarations.FirstOrDefault().SchoolYearTerm,
                            Textbook = m.Key,
                            PlanCount = m.Sum(s => s.DeclarationCount),
                            SpareCount = 0,
                            SubscriptionDate = DateTime.Now,
                            SubscriptionState = Models.FeedbackState.未征订,
                            StudentDeclarations = studentDeclarationTextbooks,
                            TeacherDeclarations = teacherDeclarationTextbooks
                        };
                        return subscription;
                    });

            return result.ToList();
        }

        /// <summary>
        /// 按出版社教材汇总，生成订单
        /// </summary>
        /// <param name="studentDeclarations">教务学生用书申报</param>
        /// <param name="teacherDeclarations">教务教师用书申报</param>
        /// <returns></returns>
        public static IEnumerable<Subscription> CreateSubscriptionsByPress(IEnumerable<StudentDeclarationJiaoWu> studentDeclarations, IEnumerable<TeacherDeclarationJiaoWu> teacherDeclarations)
        {
            //合并教师用书申报与学生用书申报
            var declarations = studentDeclarations.Union<DeclarationJiaoWu>(teacherDeclarations);
            //分组
            var result = declarations.GroupBy(t =>
                t, new PressTextbookComparer<DeclarationJiaoWu>())  //使用出版社教材选择器
                .Select(m =>
                {
                    //取出版社教材ID相同的申报
                    var studentDeclarationJiaoWus = studentDeclarations.Where(d =>
                        d.Textbook.Press == m.Key.Textbook.Press &&
                        d.Textbook_Id == m.Key.Textbook_Id
                        ).ToList();
                    var teacherDeclarationJiaoWus = teacherDeclarations.Where(d =>
                        d.Textbook.Press == m.Key.Textbook.Press &&
                        d.Textbook_Id == m.Key.Textbook_Id
                        ).ToList();
                    //转换为教材用书申报
                    var studentDeclarationTextbooks = studentDeclarationJiaoWus.ConvertAll(Converter);
                    var teacherDeclarationTextbooks = teacherDeclarationJiaoWus.ConvertAll(Converter);
                    //新建订单
                    var subscription = new Subscription
                    {
                        ID = Guid.NewGuid(),
                        Textbook_Id = m.Key.Textbook_Id.Value,
                        SchoolYearTerm = m.Key.SchoolYearTerm,
                        Textbook = m.Key.Textbook,
                        PlanCount = m.Sum(s => s.DeclarationCount),
                        SpareCount = 0,
                        SubscriptionDate = DateTime.Now,
                        SubscriptionState = Models.FeedbackState.未征订,
                        StudentDeclarations = studentDeclarationTextbooks,
                        TeacherDeclarations = teacherDeclarationTextbooks
                    };
                    return subscription;
                });

            return result.ToList();
        }

        /// <summary>
        /// 按学院教材汇总，生成订单
        /// </summary>
        /// <param name="declarations">教务学生用书</param>
        /// <returns></returns>
        public static IEnumerable<Subscription> CreateSubscriptionsBySchool(
            IEnumerable<StudentDeclarationJiaoWu> studentDeclarations,
            IEnumerable<TeacherDeclarationJiaoWu> teacherDeclarations
            )
        {
            //合并教师用书申报与学生用书申报
            var declarations = studentDeclarations.Union<DeclarationJiaoWu>(teacherDeclarations);
            //分组
            var result = declarations.GroupBy(t =>
                t, new SchoolTextbookComparer<DeclarationJiaoWu>())  //学院教材选择器
                .Select(m =>
                {
                    //取学院ID教材ID相同的申报
                    var studentDeclarationJiaoWus = studentDeclarations.Where(d =>
                        d.School_Id == m.Key.School_Id &&
                        d.Textbook_Id == m.Key.Textbook_Id
                        ).ToList();
                    var teacherDeclarationJiaoWus = teacherDeclarations.Where(d =>
                        d.School_Id == m.Key.School_Id &&
                        d.Textbook_Id == m.Key.Textbook_Id
                        ).ToList();

                    //转换为教材用书申报
                    var studentDeclarationTextbooks = studentDeclarationJiaoWus.ConvertAll(Converter);
                    var teacherDeclarationTextbooks = teacherDeclarationJiaoWus.ConvertAll(Converter);
                    //新建订单
                    var subscription = new Subscription
                    {
                        ID = Guid.NewGuid(),
                        Textbook_Id = m.Key.Textbook_Id.Value,
                        SchoolYearTerm = m.Key.SchoolYearTerm,
                        Textbook = m.Key.Textbook,
                        PlanCount = m.Sum(s => s.DeclarationCount),
                        SpareCount = 0,
                        SubscriptionDate = DateTime.Now,
                        SubscriptionState = Models.FeedbackState.未征订,
                        StudentDeclarations = studentDeclarationTextbooks,
                        TeacherDeclarations = teacherDeclarationTextbooks
                    };
                    return subscription;
                });

            return result.ToList();
        }

        #endregion

        #region 类转换器

        /// <summary>
        /// 转换器
        /// 将教务学生用书申报转换为学生用书申报
        /// </summary>
        /// <param name="declaration">教务学生用书申报</param>
        /// <returns></returns>
        private static StudentDeclarationJiaoWu Converter(StudentDeclarationJiaoWu declaration)
        {
            var studentDeclaration = new StudentDeclaration()
            {
                //Course_Id = declaration.Course_Id,
                //DataSign_Id = declaration.DataSign_Id,
                //DeclarationCount = declaration.DeclarationCount,
                ID = declaration.ID,
                //Department_Id = declaration.Department_Id,
                //School_Id = declaration.School_Id,
                //SchoolYearTerm = declaration.SchoolYearTerm,
                //Sfgd = declaration.Sfgd,
                //Textbook_Id = declaration.Textbook_Id
                HadViewFeedback = false,
                ViewFeedbackDate = null,
                DeclarationJiaoWu = declaration
            };

            declaration.DeclarationTextbook = studentDeclaration;

            return declaration;
        }
        /// <summary>
        /// 转换器
        /// 将教务教师用书申报转换为教师用书申报
        /// </summary>
        /// <param name="declaration">教务教师用书申报</param>
        /// <returns></returns>
        private static TeacherDeclarationJiaoWu Converter(TeacherDeclarationJiaoWu declaration)
        {
            var teacherDeclaration = new TeacherDeclaration()
            {
                //Course_Id = item.Course_Id,
                //DataSign_Id = item.DataSign_Id,
                //DeclarationCount = item.DeclarationCount,
                ID = declaration.ID,
                //Department_Id = item.Department_Id,
                //School_Id = item.School_Id,
                //SchoolYearTerm = item.SchoolYearTerm,
                //Sfgd = item.Sfgd,
                //Textbook_Id = item.Textbook_Id
                HadViewFeedback = false,
                ViewFeedbackDate = null,
                DeclarationJiaoWu = declaration
            };
            declaration.DeclarationTextbook = teacherDeclaration;
            return declaration;
        }
        #endregion

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
        /// <summary>
        /// 取回告状态
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<BaseModel> GetFeedbackState()
        {
            //返回models
            var models = new List<BaseModel>();
            //回告状态的值数组
            var valueArray = (int[])Enum.GetValues(typeof(FeedbackState));
            //数组转换为List
            var values = new List<int>(valueArray);
            //构建model
            values.ForEach(t =>
                {
                    var model = new BaseModel
                    {
                        Id = t.ToString(),
                        Num = t,
                        Name = Enum.GetName(typeof(FeedbackState), t)
                    };
                    models.Add(model);
                });

            return models;
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
