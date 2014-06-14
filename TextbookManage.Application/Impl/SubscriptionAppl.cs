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
    public class SubscriptionAppl : ISubscriptionAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ITeachingTaskRepository _teachingTaskRepo;//= ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        private readonly IStudentDeclarationRepository _stuDeclRepo;// = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();
        private readonly ITeacherDeclarationRepository _teaDeclRepo;// = ServiceLocator.Current.GetInstance<ITeacherDeclarationRepository>();
        private readonly IStudentDeclarationJiaoWuRepository _stuDeclJiaoWuRepo;
        private readonly ITeacherDeclarationJiaoWuRepository _teaDeclJiaoWuRepo;

        #endregion

        #region 构造函数

        public SubscriptionAppl(ITypeAdapter adapter, ITeachingTaskRepository teachingTaskRepo, IStudentDeclarationJiaoWuRepository stuDeclJiaoWuRepo, ITeacherDeclarationJiaoWuRepository teaDeclJiaoWuRepo, IStudentDeclarationRepository stuDeclRepo, ITeacherDeclarationRepository teaDeclRepo)
        {
            _adapter = adapter;
            _teachingTaskRepo = teachingTaskRepo;
            _stuDeclRepo = stuDeclRepo;
            _teaDeclRepo = teaDeclRepo;
            _stuDeclJiaoWuRepo = stuDeclJiaoWuRepo;
            _teaDeclJiaoWuRepo = teaDeclJiaoWuRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<BooksellerView> GetBookseller()
        {
            var bookserller = new BooksellerAppl().GetAll();
            return _adapter.Adapt<BooksellerView>(bookserller);
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionByTextbook(string textbookName, string isbn)
        {
            var term = new TermAppl().GetMaxTerm();

            var yearTerm = new SchoolYearTerm(term.YearTerm);

            //取全部未下订单的申报
            var query = _stuDeclJiaoWuRepo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term
                ).OfType<StudentDeclaration>()

                .Where(t =>
                    !t.Subscription_Id.HasValue
                    ).Where(t =>
                        t.Textbook_Id.HasValue
                        );
            IEnumerable<Declaration> declarations = new List<Declaration>();
            //按教材名称或ISBN模糊查询
            if (string.IsNullOrWhiteSpace(textbookName))
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {

                }
                else
                {
                    declarations = query.Where(t => t.Textbook.Isbn.Contains(isbn));
                }
            }
            else
            {
                declarations = query.Where(t => t.Textbook.Name.Contains(textbookName));
            }
            //由申报创建订单
            var subs = Domain.SubscriptionService.CreateSubscriptions(declarations);
            subs = subs.OrderBy(t => t.Textbook.Name);
            var result = _adapter.Adapt<SubscriptionForSubmitView>(subs);
            return result;
        }

        public IEnumerable<SchoolView> GetSchoolWithNotSub()
        {
            var term = new TermAppl().GetMaxTerm().YearTerm;
            //取学生申报，取学生学院
            var stuDecl = _stuDeclRepo.Find(t =>
                t.Term == term &&
                t.ApprovalState == ApprovalState.终审通过
                ).Where(t =>
                    !t.Subscription_Id.HasValue
                    );

            var stuSchool = stuDecl.SelectMany(t =>
                t.DeclarationClasses
                ).Select(t =>
                    t.ProfessionalClass.School
                    ).Distinct();

            //取教师申报，取教师学院
            var teaDecl = _teaDeclRepo.Find(t =>
                t.Term == term &&
                t.ApprovalState == ApprovalState.终审通过
                ).Where(t =>
                    !t.Subscription_Id.HasValue
                    );

            var teaSchool = teaDecl.Select(t =>
                t.TeachingTask.Department.School
                ).Distinct();
            //合并
            var concatSchools = stuSchool.Union(teaSchool).Distinct(new TextbookManage.Domain.Comparer.SchoolComparer());
            IList<School> schools = concatSchools.Distinct().OrderBy(t => t.Name).ToList();

            //检查
            if (schools.Count() == 0)
            {
                schools = new List<School>()
                {
                    new School()
                    {
                        SchoolId=default(Guid),
                        Name="没有未下订单的学院"
                    }
                };
            }
            return _adapter.Adapt<SchoolView>(schools);

        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionBySchoolId(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            var term = new TermAppl().GetMaxTerm().YearTerm;
            //取未下订单的学生申报
            IEnumerable<Declaration> stuDecl = _stuDeclRepo.Find(t =>
                t.Term == term &&
                t.ApprovalState == ApprovalState.终审通过
                ).Where(t =>
                    !t.Subscription_Id.HasValue
                    ).SelectMany(t =>
                        t.DeclarationClasses
                        ).Where(t =>
                            t.ProfessionalClass.School_Id == id
                            ).Select(t =>
                                t.Declaration
                                );

            //取未下订单的教师申报
            IEnumerable<Declaration> teaDecl = _teaDeclRepo.Find(t =>
                t.Term == term &&
                t.TeachingTask.Department.School_Id == id &&
                t.ApprovalState == ApprovalState.终审通过
                ).Where(t =>
                    !t.Subscription_Id.HasValue
                    );

            //合并申报
            var decls = stuDecl.Concat(teaDecl);
            //创建订单
            var subs = Domain.SubscriptionService.CreateSubscriptions(decls);
            subs = subs.OrderBy(t => t.Textbook.Name);
            var result = _adapter.Adapt<SubscriptionForSubmitView>(subs);
            return result;
        }

        public ResponseView SubmitSubscription(IEnumerable<SubscriptionForSubmitView> subscriptions, string booksellerId, string spareCount)
        {
            //类型转换
            var bookseId = booksellerId.ConvertToGuid();
            var spare = spareCount.ConvertToInt();
            //学期
            var term = new TermAppl().GetMaxTerm();
            //CUD仓储
            var declRepo = ServiceLocator.Current.GetInstance<IDeclarationRepository>();
            //操作响应类
            var result = new ResponseView();

            try
            {
                foreach (var item in subscriptions)
                {
                    var subId = item.SubscriptionId.ConvertToGuid();
                    var textbookId = item.TextbookId.ConvertToGuid();
                    var planCount = item.DeclarationCount.ConvertToInt();
                    //创建订单
                    var sub = Domain.SubscriptionService.CreateSubscription(subId, textbookId, bookseId, term.YearTerm, planCount, spare);
                    //为申报关联订单
                    foreach (var declItem in item.Declarations)
                    {
                        var id = declItem.DeclarationId.ConvertToInt();
                        var decl = declRepo.First(t => t.DeclarationId == id);
                        decl.Subscription = sub;
                        declRepo.Modify(decl);
                    }
                }

                declRepo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                var msg = e.Message;
                result.IsSuccess = false;
                result.Message = "征订失败";
                return result;
            }
        }

        #endregion

    }
}
