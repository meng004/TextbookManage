using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.Comparer;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;

namespace TextbookManage.Applications.Impl
{
    public class SubscriptionAppl : ISubscriptionAppl, IDisposable
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly IStudentDeclarationRepository _stuDeclRepo;// = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();
        private readonly ITeacherDeclarationRepository _teaDeclRepo;// = ServiceLocator.Current.GetInstance<ITeacherDeclarationRepository>();
        private readonly IStudentDeclarationJiaoWuRepository _stuDeclJiaoWuRepo;
        private readonly ITeacherDeclarationJiaoWuRepository _teaDeclJiaoWuRepo;
        private readonly ISubscriptionRepository _subscriptionRepo;
        private readonly IRepositoryContext _contextForUpdate;

        #endregion

        public void Dispose()
        {
        }

        #region 构造函数

        public SubscriptionAppl(ITypeAdapter adapter,
            IStudentDeclarationJiaoWuRepository stuDeclJiaoWuRepo,
            ITeacherDeclarationJiaoWuRepository teaDeclJiaoWuRepo,
            IStudentDeclarationRepository stuDeclRepo,
            ITeacherDeclarationRepository teaDeclRepo,
            ISubscriptionRepository subscriptionRepo,
            IRepositoryContext context
            )
        {
            _adapter = adapter;
            _stuDeclRepo = stuDeclRepo;
            _teaDeclRepo = teaDeclRepo;
            _stuDeclJiaoWuRepo = stuDeclJiaoWuRepo;
            _teaDeclJiaoWuRepo = teaDeclJiaoWuRepo;
            _subscriptionRepo = subscriptionRepo;
            _contextForUpdate = context;
        }
        #endregion

        #region 实现接口
        
        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsByTextbook(string term, string textbookName, string isbn)
        {
            //删除未征订的订单
            RemoveNotSubscription();
            _subscriptionRepo.Context.Commit();
            //取未征订的申报
            var studentDeclarations = GetNotSubscriptionStudentDeclarationJiaoWu(term);
            var teacherDeclarations = GetNotSubscriptionTeacherDeclarationJiaoWu(term);
            //合并
            var declarations = studentDeclarations.Union<DeclarationJiaoWu>(teacherDeclarations);
            //按教材筛选
            IEnumerable<DeclarationJiaoWu> query;
            //教材名称为空，则按ISBN筛选
            if (string.IsNullOrWhiteSpace(textbookName))
                if (string.IsNullOrWhiteSpace(isbn))
                    query = declarations;
                else
                    query = declarations.Where(t => t.Textbook.Isbn.Contains(isbn));
            else
                query = declarations.Where(t => t.Textbook.Name.Contains(textbookName));
            //生成订单
            var subscriptions = SubscriptionService.CreateSubscriptions(
                query.OfType<StudentDeclarationJiaoWu>(),
                query.OfType<TeacherDeclarationJiaoWu>()
                ).ToList();
            //写入DB
            subscriptions.ForEach(t => _subscriptionRepo.Add(t));
            _subscriptionRepo.Context.Commit();
            //返回
            return _adapter.Adapt<SubscriptionForSubmitView>(subscriptions.OrderBy(t => t.Textbook.Name));
        }

        public IEnumerable<SchoolView> GetSchoolWithNotSub(string term)
        {
            //删除未征订的订单
            RemoveNotSubscription();
            _subscriptionRepo.Context.Commit();
            //比较器
            var comparer = new SchoolComparer();
            //取未征订申报的学院
            var studentSchools = GetNotSubscriptionStudentDeclarationJiaoWu(term)
                .Select(t => t.School)
                .Distinct(comparer);  //去除重复学院
            var teacherSchools = GetNotSubscriptionTeacherDeclarationJiaoWu(term)
                .Select(t => t.School)
                .Distinct(comparer);  //去除重复学院
            //合并学院
            var unionSchools = studentSchools
                .Union(teacherSchools);

            //取学院
            var schools = unionSchools
                .Distinct(comparer)
                .OrderBy(t => t.Name)  //按学院名称排序
                .ToList();

            //检查
            if (schools.Count() == 0)
            {
                schools = new List<School>()
                {
                    new School()
                    {
                        ID=Guid.Empty,
                        Name="没有未下订单的学院"
                    }
                };
            }
            return _adapter.Adapt<SchoolView>(schools);
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsBySchoolId(string term, string schoolId)
        {
            //删除未征订的订单
            RemoveNotSubscription();
            _subscriptionRepo.Context.Commit();

            var id = schoolId.ConvertToGuid();
            //取未征订的申报
            var studentDeclarations = GetNotSubscriptionStudentDeclarationJiaoWu(term)
                .Where(t => t.School_Id == id);
            var teacherDeclarations = GetNotSubscriptionTeacherDeclarationJiaoWu(term)
                .Where(t => t.School_Id == id);

            //创建订单
            var subscriptions = SubscriptionService.CreateSubscriptionsBySchool(studentDeclarations, teacherDeclarations);
            //写入DB
            subscriptions.ToList().ForEach(t => _subscriptionRepo.Add(t));
            _subscriptionRepo.Context.Commit();
            //DTO
            var result = _adapter.Adapt<SubscriptionForSubmitView>(subscriptions.OrderBy(t => t.Textbook.Name));
            return result;
        }

        public IEnumerable<string> GetPressWithNotSub(string term)
        {
            //删除未征订的订单
            RemoveNotSubscription();
            _subscriptionRepo.Context.Commit();
            //取未征订申报的教材出版社
            var studentPress = GetNotSubscriptionStudentDeclarationJiaoWu(term)
                .Select(t => t.Textbook.Press);
            var teacherPress = GetNotSubscriptionTeacherDeclarationJiaoWu(term)
                .Select(t => t.Textbook.Press);
            //合并
            var press = studentPress
                .Union(teacherPress)
                .Distinct()
                .OrderBy(t => t)
                .ToList();
            //检查
            if (press.Count() == 0)
            {
                press = new List<string> { "没有未征订的用书申报" };
            }

            return press;
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsByPress(string term, string press)
        {
            
            //删除未征订的订单
            RemoveNotSubscription();
            _subscriptionRepo.Context.Commit();
            //取未征订的申报
            var studentDeclarations = GetNotSubscriptionStudentDeclarationJiaoWu(term)
                .Where(t => t.Textbook.Press == press);
            var teacherDeclarations = GetNotSubscriptionTeacherDeclarationJiaoWu(term)
                .Where(t => t.Textbook.Press == press);

            //创建订单
            var subscriptions = SubscriptionService.CreateSubscriptionsByPress(studentDeclarations, teacherDeclarations).ToList();

            //写入DB
            subscriptions.ForEach(t => _subscriptionRepo.Add(t));
            _subscriptionRepo.Context.Commit();

            //DTO
            var result = _adapter.Adapt<SubscriptionForSubmitView>(subscriptions.OrderBy(t => t.Textbook.Name));
            return result;
        }

        public ResponseView SubmitSubscriptions(string booksellerId, string spareCount, IEnumerable<SubscriptionForSubmitView> subscriptions)
        {
            //类型转换
            var sellerId = booksellerId.ConvertToGuid();
            var spare = spareCount.ConvertToInt();
            var ids = subscriptions.Select(t => t.SubscriptionId.ConvertToGuid());
            //操作响应类
            var result = new ResponseView();
            //保存至DB
            try
            {
                //修改订单
                _subscriptionRepo.Modify(
                    t => ids.Contains(t.ID),
                    s => new Subscription
                    {
                        Bookseller_Id = sellerId,
                        SpareCount = spare,
                        SubscriptionState = FeedbackState.征订中
                    });

                //删除订单
                //RemoveNotSubscription();
                //写入DB
                _subscriptionRepo.Context.Commit();
            }
            catch (Exception e)
            {
                var msg = e.Message;
                result.IsSuccess = false;
                result.Message = "征订失败";
            }
            return result;
        }

        public IEnumerable<FeedbackStateView> GetFeedbackState()
        {
            var models = SubscriptionService.GetFeedbackState();
            var result = _adapter.Adapt<FeedbackStateView>(models);
            return result;
        }

        public IEnumerable<SubscriptionForSubmitView> GetSubscriptions(string term, FeedbackStateView state)
        {
            //学期
            var yearTerm = new SchoolYearTerm(term);
            //订单状态
            var subscriptionState = FeedbackState.未征订;
            Enum.TryParse(state.Name, out subscriptionState);
            //取订单
            var subscriptions = _subscriptionRepo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term &&
                t.SubscriptionState == subscriptionState
                );
            var result = _adapter.Adapt<SubscriptionForSubmitView>(subscriptions);
            return result;
        }

        public ResponseView RemoveSubscriptions(IEnumerable<SubscriptionForSubmitView> subscriptions)
        {
            //取订单ID
            var ids = subscriptions.Select(d => d.SubscriptionId.ConvertToGuid());
            //操作响应类
            var result = new ResponseView();

            //批量删除
            try
            {
                _subscriptionRepo.Remove(t => ids.Contains(t.ID));
                _subscriptionRepo.Context.Commit();
            }
            catch (Exception e)
            {
                var msg = e.Message;
                result.IsSuccess = false;
                result.Message = "征订失败";
            }
            return result;
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 取学年学期未征订的学生用书申报
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public List<StudentDeclarationJiaoWu> GetNotSubscriptionStudentDeclarationJiaoWu(string term)
        {
            //学年学期
            var yearTerm = new SchoolYearTerm(term);
            var context1 = _stuDeclJiaoWuRepo.Context;
            var context2 = _stuDeclRepo.Context;
            //是否归档等于0
            var query = _stuDeclJiaoWuRepo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term &&
                t.Sfgd == "0" //0确认征订教材，2确认不要教材，1确认取消教材
                );
            //已征订
            var decl = _stuDeclRepo.Find(t =>
                t.DeclarationJiaoWu.SchoolYearTerm.Year == yearTerm.Year &&
                t.DeclarationJiaoWu.SchoolYearTerm.Term == yearTerm.Term
                ).Select(d => d.ID);
            //未征订
            var result = from d in query
                         where !decl.Contains(d.ID)
                         select d;
            return result.ToList();
        }

        /// <summary>
        /// 取学年学期未征订的教师用书申报
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public List<TeacherDeclarationJiaoWu> GetNotSubscriptionTeacherDeclarationJiaoWu(string term)
        {
            //学年学期
            var yearTerm = new SchoolYearTerm(term);

            //是否归档等于4
            var query = _teaDeclJiaoWuRepo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term &&
                t.Sfgd == "4" //0申报中，1学院审核中，2教材科审核中，3教务处审核中，4审核完成，A学院审核未通过，B教学建设科审核未通过，C教务处审核未通过
                );
            //已征订
            var decl = _teaDeclRepo.Find(t =>
                t.DeclarationJiaoWu.SchoolYearTerm.Year == yearTerm.Year &&
                t.DeclarationJiaoWu.SchoolYearTerm.Term == yearTerm.Term
                ).Select(t => t.ID);
            //未征订
            var result = from d in query
                         where !decl.Contains(d.ID)
                         select d;
            return result.ToList();
        }

        public void RemoveNotSubscription()
        {
            _subscriptionRepo.Remove(t =>
                t.SubscriptionState == FeedbackState.未征订);
        }
        #endregion

    }
}
