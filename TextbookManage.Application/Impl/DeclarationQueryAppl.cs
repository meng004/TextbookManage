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
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Applications.Impl
{
    public class DeclarationQueryAppl : IDeclarationQueryAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;// = ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ITeachingTaskRepository _teachingTaskRepo;// = ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        private readonly IDeclarationRepository _declarationRepo;//= ServiceLocator.Current.GetInstance<IDeclarationRepository>();

        #endregion

        #region 构造函数

        public DeclarationQueryAppl(ITypeAdapter adapter, ITeachingTaskRepository teachingTaskRepo, IDeclarationRepository declarationRepo)
        {
            _adapter = adapter;
            _teachingTaskRepo = teachingTaskRepo;
            _declarationRepo = declarationRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            var user = new TbmisUserAppl(loginName).GetUser();
            IEnumerable<School> schools = new List<School>();

            //领导，显示全部学院
            if (user.IsInRole("教材科") || user.IsInRole("教务处"))
            {
                schools = new SchoolAppl().GetSchools();
            }
            else
            {
                schools = new SchoolAppl().GetSchoolOfUser(loginName);
            }

            schools = schools.OrderBy(t => t.Name);

            return _adapter.Adapt<SchoolView>(schools);
        }

        public IEnumerable<DepartmentView> GetDepartmentBySchoolId(string loginName, string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            var user = new TbmisUserAppl(loginName).GetUser();
            IEnumerable<Department> departments = new List<Department>();

            ////领导角色，显示全部教研室
            //if (user.IsInRole("学院院长") || user.IsInRole("教材科") || user.IsInRole("教务处"))
            //{
            //    departments = new DepartmentAppl().GetDepartmentBySchoolId(id);
            //}
            //else
            //{
            //    departments = new DepartmentAppl().GetDepartmentBySchoolId(loginName, id);
            //}

            //显示全部教研室
            departments = new DepartmentAppl().GetDepartmentBySchoolId(id);

            departments = departments.OrderBy(t => t.Name);
            return _adapter.Adapt<DepartmentView>(departments);
        }

        public IEnumerable<TermView> GetTerm()
        {
            var terms = new TermAppl().GetAll();
            //排序
            terms = terms.OrderByDescending(t => t.YearTerm);

            return _adapter.Adapt<TermView>(terms);
        }

        public IEnumerable<RecipientTypeView> GetRecipientType()
        {
            IList<RecipientTypeView> views = new List<RecipientTypeView>();

            foreach (var item in Enum.GetValues(typeof(RecipientType)))
            {
                var view = new RecipientTypeView
                {
                    Id = item.ToString(),
                    Name = Enum.GetName(typeof(RecipientType), item)
                };
                views.Add(view);
            }

            var removeItem = views.FirstOrDefault(t => t.Name == "全部");

            views.Remove(removeItem);

            return views;
        }

        public IEnumerable<CourseView> GetCourseByDepartmentId(string departmentId, string term)
        {
            var id = departmentId.ConvertToGuid();
            var courses = new CourseAppl().GetCourseByDepartmentId(id, term);

            courses = courses.OrderBy(t => t.Num);
            return _adapter.Adapt<CourseView>(courses);
        }

        public IEnumerable<DeclarationForQueryView> GetDeclarationByCourseId(string courseId, string departmentId, string term, string recipientTypeName)
        {
            var courId = courseId.ConvertToGuid();
            var depaId = departmentId.ConvertToGuid();

            RecipientType type = RecipientType.Student;
            Enum.TryParse(recipientTypeName, out type);

            //var declarations = _teachingTaskRepo.Find(t =>
            //    t.SchoolYearTerm.Year == term.Substring(0, 9) &&
            //    t.SchoolYearTerm.Term == term.Substring(10, 1) &&
            //    t.Course_Id == courId &&
            //    t.Department_Id == depaId
            //    ).SelectMany(t =>
            //        t.Declarations
            //        ).Where(t =>
            //            t.RecipientType == type
            //            );
            var declarations = new List<DeclarationJiaoWu>();

            switch (type)
            {
                case RecipientType.Student:
                    declarations = GetStudentDeclarations(courId, depaId, term);
                    break;
                case RecipientType.Teacher:
                    declarations = GetTeacherDeclarations(courId, depaId, term);
                    break;
            }

            //排序
            //declarations = declarations.OrderByDescending(t => t.DeclarationDate);

            var views = _adapter.Adapt<DeclarationForQueryView>(declarations);
            return views;
        }
        /// <summary>
        /// 取教师用书申报
        /// </summary>
        /// <param name="courId">课程ID</param>
        /// <param name="depaId">部门ID</param>
        /// <param name="term">学年学期</param>
        /// <returns></returns>
        private List<DeclarationJiaoWu> GetTeacherDeclarations(Guid courId, Guid depaId, string term)
        {
            var yearTerm = new SchoolYearTerm(term);
            var repo = ServiceLocator.Current.GetInstance<ITeacherDeclarationJiaoWuRepository>();
            var declarations = repo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term &&
                t.Course_Id == courId &&
                t.Department_Id == depaId
                );
            return (List<DeclarationJiaoWu>)declarations;
        }
        /// <summary>
        /// 取学生用书申报
        /// </summary>
        /// <param name="courId">课程ID</param>
        /// <param name="depaId">部门ID</param>
        /// <param name="term">学年学期</param>
        /// <returns></returns>
        private List<DeclarationJiaoWu> GetStudentDeclarations(Guid courId, Guid depaId, string term)
        {
            var yearTerm = new SchoolYearTerm(term);
            var repo = ServiceLocator.Current.GetInstance<IStudentDeclarationJiaoWuRepository>();
            var declarations = repo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term &&
                t.Course_Id == courId &&
                t.Department_Id == depaId
                );
            return (List<DeclarationJiaoWu>)declarations;
        }

        public IEnumerable<ApprovalView> GetDeclarationApproval(string declarationId)
        {
            //var id = declarationId.ConvertToGuid();
            //var approvals = _declarationRepo.First(t => 
            //    t.ID == id
            //    ).Approvals;

            //approvals = approvals.OrderByDescending(t => t.ApprovalDate).ToList();
            //return _adapter.Adapt<ApprovalView>(approvals);
            return new List<ApprovalView>();
        }

        public FeedbackView GetFeedbackByStudentDeclarationId(string declarationId)
        {
            var id = declarationId.ConvertToGuid();
            var repo = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();

            var declaration = repo.First(t => t.ID == id);
            //未下订单
            if (declaration == null)
                return new FeedbackView { Remark = FeedbackState.未征订.ToString() };
            else
            {
                //未查看过回告，修改状态
                if (!declaration.HadViewFeedback)
                {
                    //查看公告
                    declaration.ViewFeedback();
                    //修改查看时间
                    repo.Modify(declaration);
                    repo.Context.Commit();
                }
                return _adapter.Adapt<FeedbackView>(declaration.Subscription.Feedback);
            }
        }

        public FeedbackView GetFeedbackByTeacherDeclarationId(string declarationId)
        {
            var id = declarationId.ConvertToGuid();
            var repo = ServiceLocator.Current.GetInstance<ITeacherDeclarationRepository>();

            var declaration = repo.First(t => t.ID == id);
            //未下订单
            if (declaration == null)
                return new FeedbackView { Remark = FeedbackState.未征订.ToString() };
            else
            {
                //未查看过回告，修改状态
                if (!declaration.HadViewFeedback)
                {
                    //查看公告
                    declaration.ViewFeedback();
                    //修改查看时间
                    repo.Modify(declaration);
                    repo.Context.Commit();
                }
                return _adapter.Adapt<FeedbackView>(declaration.Subscription.Feedback);
            }
        }
        #endregion

    }
}
