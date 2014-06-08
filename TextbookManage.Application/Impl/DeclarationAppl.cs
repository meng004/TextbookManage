using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Domain.Models;
using System.Text;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Applications.Impl
{
    public class DeclarationAppl : IDeclarationAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ITeacherRepository _teacherRepo;// = ServiceLocator.Current.GetInstance<ITeacherRepository>();
        private readonly ITeachingTaskRepository _teachingTaskRepo;// = ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        private readonly ITextbookRepository _textbookRepo;//= ServiceLocator.Current.GetInstance<ITextbookRepository>();

        #endregion

        #region 构造函数

        public DeclarationAppl(ITypeAdapter adapter, ITeacherRepository teacherRepo, ITeachingTaskRepository teachingTaskRepo, ITextbookRepository textbookRepo)
        {
            _adapter = adapter;
            _teacherRepo = teacherRepo;
            _teachingTaskRepo = teachingTaskRepo;
            _textbookRepo = textbookRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            var school = new SchoolAppl().GetSchoolOfUser(loginName);
            school = school.OrderBy<School, string>(t => t.Name);
            return _adapter.Adapt<SchoolView>(school);
        }

        public IEnumerable<DepartmentView> GetDepartmentByLoginName(string loginName, string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            //显示全部教研室
            var departments = new DepartmentAppl().GetDepartmentBySchoolId(id);
            //排序
            departments = departments.OrderBy<Department, string>(t => t.Name);
            return _adapter.Adapt<DepartmentView>(departments);
        }

        public IEnumerable<CourseView> GetCourseByDepartmentId(string departmentId)
        {
            var id = departmentId.ConvertToGuid();
            //取最大学年学期
            var term = new TermAppl().GetMaxTerm();
            var courses = new CourseAppl().GetCourseByDepartmentId(id, term.YearTerm);
            courses = courses.OrderBy(t => t.Num);

            return _adapter.Adapt<CourseView>(courses);
        }

        public IEnumerable<TeachingTaskView> GetTeachingTaskByDepartmentId(string departmentId, string courseId)
        {
            //取最大学期
            var term = new TermAppl().GetMaxTerm();
            //数据类型转换
            var depaId = departmentId.ConvertToGuid();
            var courId = courseId.ConvertToGuid();

            var teachingTask = _teachingTaskRepo.Find(t =>
                t.SchoolYearTerm.Year == term.SchoolYearTerm.Year &&
                t.SchoolYearTerm.Term == term.SchoolYearTerm.Term &&
                t.Department_Id == depaId &&
                t.Course_Id == courId
                );

            //转ViewModel
            teachingTask = teachingTask.OrderBy(t => t.TeachingTaskNum);
            return _adapter.Adapt<TeachingTaskView>(teachingTask);
        }

        public IEnumerable<TextbookForDeclarationView> GetTextbooksByName(string name, string isbn)
        {
            IEnumerable<Textbook> models = new List<Textbook>();

            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                }
                else
                {
                    models = _textbookRepo.Find(t => t.Isbn.Contains(isbn));
                }
            }
            else
            {
                models = _textbookRepo.Find(t => t.Name.Contains(name));
            }

            models = models.OrderBy(t => t.Name);
            return _adapter.Adapt<TextbookForDeclarationView>(models);
        }

        //public ResponseView SubmitStudentDeclaration(IEnumerable<TeachingTaskView> teachingTaskViews, string textbookId, string loginName, string mobile, string telephone, string declarationCount)
        public ResponseView SubmitStudentDeclaration(DeclarationView view)
        {
            //数据类型转换

            var count = view.DeclarationCount.ConvertToInt();
            //取对象
            var term = new TermAppl().GetMaxTerm().YearTerm;  //学期
            var teacId = new TbmisUserAppl(view.Declarant).GetUser().TbmisUserId;  //教师ID
            var teacher = _teacherRepo.First(t => t.ID == teacId);  //教师


            var repo = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();//CUD专用仓储

            //重载构造函数参数的写法，使得仓储共用工作单元，实现事务
            //配置文件中要添加name为Update的IUnitOfWork的Mapto

            //var declRepo = ServiceLocator.Current.GetInstance<IDeclarationRepository>(new ParameterOverrides()
            //        {
            //            {"unitOfWork", ServiceLocator.Current.GetInstance<IUnitOfWork>("Update")}
            //        });
            //var subRepo = ServiceLocator.Current.GetInstance<ISubscriptionRepository>(new ParameterOverrides()
            //        {
            //            {"unitOfWork", ServiceLocator.Current.GetInstance<IUnitOfWork>("Update")}
            //        });  

            //操作响应类
            var result = new ResponseView();
            //错误消息
            var faultMessage = string.Empty;
            //返回消息
            var messageForResponse = new StringBuilder();
            //成功数量
            var successCount = 0;

            //需要教材
            //if (!view.NotNeedTextbook)
            //{
            //    //取教材
            //    var textId = view.TextbookId.ConvertToGuid();
            //    var book = _textbookRepo.First(t => t.ID == textId);  //教材

            //    //为教学任务中的每个学生班级创建用书申报
            //    foreach (var item in view.TeachingTaskNums)
            //    {
            //        //取教学任务
            //        var task = _teachingTaskRepo.First(t => t.TeachingTaskNum == item);

            //        //创建学生用书申报
            //        var declaration = Domain.DeclarationService.CreateDeclaration<StudentDeclaration>(term, item, textId, teacId, view.Mobile, view.Telephone, count, view.NotNeedTextbook);


            //        //取出教学任务中的学生班级，依次处理
            //        foreach (var proClass in task.ProfessionalClasses)
            //        {
            //            //检查班级是否满足申报条件
            //            if (Domain.DeclarationService.CanDeclaration(proClass, book, ref faultMessage))
            //            {
            //                //创建申报班级
            //                Domain.DeclarationService.CreateDeclarationClass(declaration, proClass);
            //            }
            //            else
            //            {
            //                //记录出错信息
            //                messageForResponse.Append(faultMessage);
            //                faultMessage = string.Empty;
            //            }
            //        }

            //        //检查可申报该教材的班级数量
            //        if (declaration.DeclarationClasses.Count() == task.ProfessionalClasses.Count())
            //        {
            //            //将申报添加到仓储
            //            repo.Add(declaration);
            //            successCount++;
            //        }
            //    }

            //}
            //else    //不需要教材
            //{
            //    foreach (var item in view.TeachingTaskNums)
            //    {
            //        //创建学生用书申报
            //        var declaration = Domain.DeclarationService.CreateDeclaration<StudentDeclaration>(term, item, null, teacId, view.Mobile, view.Telephone, count, view.NotNeedTextbook);

            //        //将申报添加到仓储
            //        repo.Add(declaration);
            //        successCount++;
            //    }
            //}
            try
            {
                //将申报保存到数据库
                repo.Context.Commit();
                //返回消息
                result.Message = string.Format("共{0}个教学班，成功{1}个教学班",
                    view.TeachingTaskNums.Count(),
                    successCount
                    );
                //如果没有全部成功提交，增加错误消息
                if (view.TeachingTaskNums.Count() != successCount)
                {
                    result.Message += string.Format("，失败{0}个教学班{1}失败原因：{2}",
                        view.TeachingTaskNums.Count() - successCount,
                        " ",
                        messageForResponse
                        );
                }

                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "提交学生用书申报失败";
                return result;
            }
        }

        public ResponseView SubmitTeacherDeclaration(DeclarationView view)
        {
            //类型转换
            var textId = view.TextbookId.ConvertToGuid();
            var teacId = new TbmisUserAppl(view.Declarant).GetUser().TbmisUserId;
            var count = view.DeclarationCount.ConvertToInt();
            //当前学期
            var term = new TermAppl().GetMaxTerm().YearTerm;
            //操作响应类
            var result = new ResponseView();

            try
            {
                ////CUD仓储
                //var repo = ServiceLocator.Current.GetInstance<ITeacherDeclarationRepository>();
                ////创建申报
                //var declaration = Domain.DeclarationService.CreateDeclaration<TeacherDeclaration>(term, view.TeachingTaskNums.First(), textId, teacId, view.Mobile, view.Telephone, count, view.NotNeedTextbook);
                ////保存
                //repo.Add(declaration);
                ////提交到数据库
                //repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "提交教师用书申报失败";
                return result;
            }
        }

        public IEnumerable<ProfessionalClassView> GetProfessionalClassByTeachingTaskNum(string teachingTaskNum)
        {
            IEnumerable<ProfessionalClass> proClass = _teachingTaskRepo.First(t =>
                t.TeachingTaskNum == teachingTaskNum
                ).ProfessionalClasses;

            proClass = proClass.OrderBy(t => t.Name);

            return _adapter.Adapt<ProfessionalClassView>(proClass);
        }

        public IEnumerable<DeclarationForTeachingTaskView> GetDeclarationByTeacingTaskNum(string teachingTaskNum)
        {
            //IEnumerable<Declaration> decl = _teachingTaskRepo.First(t =>
            //    t.TeachingTaskNum == teachingTaskNum
            //    ).Declarations;

            //decl = decl.OrderBy(t => t.TeachingTask_Num);

            var decl = new List<Declaration>();
            return _adapter.Adapt<DeclarationForTeachingTaskView>(decl);
        }

        public string CalculateDeclarationCount(IEnumerable<TeachingTaskView> views)
        {
            var count = 0;
            foreach (var item in views)
            {
                var teachingTask = _teachingTaskRepo.First(t =>
                    t.TeachingTaskNum == item.TeachingTaskNum
                    );

                count += teachingTask.StudentCount;
            }
            return count.ToString();
        }

        #endregion

    }
}
