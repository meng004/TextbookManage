using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain
{
    public class DeclarationService
    {

        #region 创建申报

        /// <summary>
        /// 创建学生用书申报
        /// </summary>
        /// <param name="teachingTaskNum">教学任务</param>
        /// <param name="professionalClassId">学生班级ID</param>
        /// <param name="textbookId">申报的教材</param>
        /// <param name="teacherId">申报人ID</param>
        /// <param name="declarationCount">申报数量</param>
        /// <param name="mobile">移动电话</param>
        /// <returns></returns>
        //public static T CreateDeclaration<T>(string term, string teachingTaskNum, Guid? textbookId, Guid teacherId, string mobile, string telephone, int declarationCount, bool notNeedTextbook)
        //    where T : Declaration, new()
        //{
        //    //创建用书申报
        //    var model = new T
        //    {
        //        Term = term,  //学年学期
        //        TeachingTask_Num = teachingTaskNum,  //教学班编号
        //        Textbook_Id = notNeedTextbook ? null : textbookId,  //教材ID
        //        Teacher_Id = teacherId,  //申报人ID，
        //        Mobile = mobile,
        //        Telephone = telephone,
        //        DeclarationCount = declarationCount,//申报数量
        //        //RecipientType = RecipientType.学生,
        //        ApprovalState = ApprovalState.教研室审核中, //审核状态为学院审核中                
        //        DeclarationDate = DateTime.Now,
        //        HadViewFeedback = false,//是否已查看回告
        //        NotNeedTextbook = notNeedTextbook
        //    };

        //    return model;
        //}

        /*
        /// <summary>
        /// 创建教师用书申报
        /// </summary>
        /// <param name="teachingTaskNum"></param>
        /// <param name="textId"></param>
        /// <param name="teacId"></param>
        /// <param name="mobile"></param>
        /// <param name="telephone"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static TeacherDeclaration CreateTeacherDeclaration(string term, string teachingTaskNum, Guid textbookId, Guid teacherId, string mobile, string telephone, int declarationCount)
        {
            //创建用书申报
            var model = new TeacherDeclaration
            {
                Term = term,  //学年学期
                TeachingTask_Num = teachingTaskNum,  //教学班编号
                Textbook_Id = textbookId,  //教材ID
                Teacher_Id = teacherId,  //申报人ID，
                Mobile = mobile,
                Telephone = telephone,
                DeclarationCount = declarationCount,//申报数量
                RecipientType = RecipientType.教师,
                ApprovalState = ApprovalState.学院审核中, //审核状态为学院审核中                
                DeclarationDate = DateTime.Now,
                HadViewFeedback = false//是否已查看回告
            };

            return model;
        }
         */

        /// <summary>
        /// 创建学生用书申报班级
        /// </summary>
        /// <param name="declaration"></param>
        /// <param name="proClass"></param>
        /// <returns></returns>
        //public static void CreateDeclarationClass(StudentDeclaration declaration, ProfessionalClass proClass)
        //{
        //    var declarationClass = new DeclarationClass
        //    {
        //        DeclarationId = declaration.DeclarationId,
        //        ProfessionalClass_Id = proClass.ProfessionalClassId,
        //        DeclarationCount = proClass.StudentCount
        //    };
        //    //添加到申报的班级列表中
        //    declaration.DeclarationClasses.Add(declarationClass);
        //}

        /*
        /// <summary>
        /// 创建教师申报
        /// </summary>
        /// <param name="teachingTask"></param>
        /// <param name="textbook"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public static TeacherDeclaration CreateTeacherDeclaration(TeachingTask teachingTask, Textbook textbook, Teacher teacher)
        {
            //创建用书申报
            TeacherDeclaration model = new TeacherDeclaration
            {
                DeclarationDate = DateTime.Now,
                HadViewFeedback = false,//是否已查看回告
                Textbook = textbook,
                ApprovalState = ApprovalState.SchoolApproving, //审核状态为学院审核中
                DeclarationCount = 1,//申报数量为1
                TeachingTask = teachingTask,
                Declarant = teacher,
                RecipientType = RecipientType.Teacher
            };

            return model;
        }
        */

        /// <summary>
        /// 是否可以申报该教材
        /// </summary>
        /// <param name="professionalClass">学生班级</param>
        /// <param name="textbook">教材</param>
        /// <param name="message">返回操作结果消息</param>
        //public static bool CanDeclaration(ProfessionalClass professionalClass, Textbook textbook, ref string message)
        //{
        //    if (professionalClass.IsSameDeclaration(textbook.TextbookId))
        //    {
        //        message += string.Format("{0}已申报《{1}》！",
        //            professionalClass.Name,
        //            textbook.Name
        //            );
        //        return false;
        //    }
        //    else if (professionalClass.IsReleased(textbook.TextbookId))
        //    {
        //        message = string.Format("{0}已有{1}名学生领用《{2}》！",
        //            professionalClass.Name,
        //            professionalClass.StudentCountOfTextbook(textbook.TextbookId),
        //            textbook.Name
        //            );
        //        return false;
        //    }

        //    return true;
        //}
        #endregion

        #region 审核记录

        /// <summary>
        /// 创建审核记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auditor"></param>
        /// <param name="division"></param>
        /// <param name="suggestion"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static T CreateApproval<T>(string auditor, string division, bool suggestion, string remark)
            where T : Approval, new()
        {
            var model = new T
            {
                ApprovalDate = DateTime.Now,
                Auditor = auditor,
                Division = division,
                Suggestion = suggestion,
                Remark = remark
            };
            return model;
        }
        #endregion

        #region 申报进度

        /// <summary>
        /// 创建学院申报进度
        /// </summary>
        /// <param name="teachingTasks"></param>
        /// <returns></returns>
        //public static IEnumerable<SchoolProgress> CreateSchoolProgress(IEnumerable<TeachingTask> teachingTasks)
        //{
        //    //分组运算不能启用并行化
        //    var query = teachingTasks.GroupBy(t =>
        //        t.Department.School
        //        ).Select(t =>
        //            new SchoolProgress
        //            {
        //                School = new School { SchoolId = t.Key.SchoolId, Name = t.Key.Name },
        //                TotalCount = t.Count(),
        //                FinishedCount = t.Count(d => HasStudentDeclaration(d.Declarations))
        //            });
        //    //var query = from t in teachingTasks
        //    //            group t by t.Department.School
        //    //                into g
        //    //                select new SchoolProgress
        //    //                {
        //    //                    School = new School { SchoolId = g.Key.SchoolId, Name = g.Key.Name },
        //    //                    TotalCount = g.Count(),
        //    //                    FinishedCount = g.Count(t => HasStudentDeclaration(t.Declarations))
        //    //                };

        //    return query.ToList();

        //}

        /// <summary>
        /// 创建教研室申报进度
        /// </summary>
        /// <param name="teachingTasks"></param>
        /// <returns></returns>
        //public static IEnumerable<DepartmentProgress> CreateDepartmentProgress(IEnumerable<TeachingTask> teachingTasks)
        //{
        //    //分组运算不能启用并行化
        //    var query = teachingTasks
        //        .GroupBy(t => new { t.Department, t.Course, t.DataSign })
        //        .Select(s => new DepartmentProgress
        //        {
        //            School = s.Key.Department.School,
        //            Course = s.Key.Course,
        //            Department = s.Key.Department,
        //            DataSign = s.Key.DataSign,
        //            TotalCount = s.Count(),
        //            FinishedCount = s.Count(f => HasStudentDeclaration(f.Declarations.ToList()))
        //        });

        //    //var query = from t in teachingTasks
        //    //            group t by new { t.Department, t.Course, t.DataSign }
        //    //                into g
        //    //                select new DepartmentProgress
        //    //                {
        //    //                    School = g.Key.Department.School,
        //    //                    Course = g.Key.Course,
        //    //                    Department = g.Key.Department,
        //    //                    DataSign = g.Key.DataSign,
        //    //                    TotalCount = g.Count(),
        //    //                    FinishedCount = g.Count(t => HasStudentDeclaration(t.Declarations))
        //    //                };
        //    return query.ToList();
        //}

        /// <summary>
        /// 申报中是否有终审通过的学生用书申报
        /// </summary>
        /// <param name="declarations"></param>
        /// <returns></returns>
        //public static bool HasStudentDeclaration(IEnumerable<Declaration> declarations)
        //{
        //    foreach (var item in declarations)
        //    {
        //        //学生用书，且终审通过
        //        if (item.RecipientType == RecipientType.学生 && item.ApprovalState == ApprovalState.终审通过)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        #endregion



    }
}
