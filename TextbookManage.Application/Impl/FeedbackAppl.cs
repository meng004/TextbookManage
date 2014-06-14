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
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Applications.Impl
{
    public class FeedbackAppl : IFeedbackAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ISubscriptionRepository _subscriptionRepo;//= ServiceLocator.Current.GetInstance<ISubscriptionRepository>();

        #endregion

        #region 构造函数

        public FeedbackAppl(ITypeAdapter adapter, ISubscriptionRepository subscriptionRepo)
        {
            _adapter = adapter;
            _subscriptionRepo = subscriptionRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionWithNotFeedback(string loginName)
        {
            //取当前登录用户的机构ID
            var id = new TbmisUserAppl(loginName).GetUser().SchoolId;
            var term = new TermAppl().GetMaxTerm();

            var subscriptions = _subscriptionRepo.Find(t =>
                t.SchoolYearTerm.Year == term.SchoolYearTerm.Year && //当前学期
                t.SchoolYearTerm.Term == term.SchoolYearTerm.Term &&
                t.Bookseller_Id == id  //书商
                //t.GetFeedbackState() == FeedbackState.征订中                
                ).Where(t =>
                    !t.Feedback_Id.HasValue
                    ); //未回告;

            return _adapter.Adapt<SubscriptionForFeedbackView>(subscriptions);
        }

        public ResponseView SubmitFeedback(IEnumerable<SubscriptionForFeedbackView> subscriptions, string loginName, string feedbackState, string remark)
        {
            var sugg = feedbackState.ConvertToBool();
            var person = new TbmisUserAppl(loginName).GetUser().TbmisUserName;

            var repo = ServiceLocator.Current.GetInstance<ISubscriptionRepository>();

            var result = new ResponseView();
            //创建回告
            var feedback = Domain.SubscriptionService.CreateFeedback(person, sugg, remark);
            //取出订单
            foreach (var item in subscriptions)
            {
                var id = item.SubscriptionId.ConvertToGuid();
                var sub = repo.First(t => t.ID == id);
                sub.Feedback = feedback;
                repo.Modify(sub);
            }


            try
            {
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "回告失败";
                return result;
            }
        }

        public IEnumerable<BooksellerView> GetBookseller(string loginName)
        {
            var user = new TbmisUserAppl(loginName).GetUser();
            IList<Bookseller> booksellers = new List<Bookseller>();

            if (user.IsInRole("教材科"))
            {
                booksellers = new BooksellerAppl().GetAll().ToList();
            }
            else
            {
                booksellers.Add(
                    new Bookseller
                    {
                        ID = (Guid)user.SchoolId,
                        Name = user.SchoolName
                    });
            }
            return _adapter.Adapt<BooksellerView>(booksellers);
        }

        public IEnumerable<FeedbackStateView> GetFeedbackState()
        {
            IList<FeedbackStateView> views = new List<FeedbackStateView>();
            foreach (var item in Enum.GetValues(typeof(FeedbackState)))
            {
                var view = new FeedbackStateView
                {
                    Id = item.ToString(),
                    Name = Enum.GetName(typeof(FeedbackState), item)
                };

                views.Add(view);

            }
            var item1 = views.First(t => t.Name == FeedbackState.未征订.ToString());
            var item2 = views.First(t => t.Name == FeedbackState.未知状态.ToString());
            views.Remove(item1);
            views.Remove(item2);

            return views;
        }

        /// <summary>
        /// 根据回告状态，取订单
        /// </summary>
        /// <param name="term"></param>
        /// <param name="booksellerId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IEnumerable<Subscription> GetSubscriptionByState(string term, Guid booksellerId, FeedbackState state)
        {
            var yearTerm = new SchoolYearTerm(term);
            return _subscriptionRepo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year &&
                t.SchoolYearTerm.Term == yearTerm.Term &&
                t.Bookseller_Id == booksellerId &&
                t.Feedback.FeedbackState == state
                );
        }

        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionByBooksellerId(string booksellerId, string feedbackStateName)
        {
            var term = new TermAppl().GetMaxTerm();
            var id = booksellerId.ConvertToGuid();
            FeedbackState state = FeedbackState.未知状态;
            Enum.TryParse(feedbackStateName, out state);

            IEnumerable<Subscription> subs = new List<Subscription>();

            switch (state)
            {
                case FeedbackState.征订中:
                    subs = _subscriptionRepo.Find(t =>
                        t.SchoolYearTerm.Year == term.SchoolYearTerm.Year &&
                        t.SchoolYearTerm.Term == term.SchoolYearTerm.Term &&
                        t.Bookseller_Id == id
                        ).Where(t =>
                            !t.Feedback_Id.HasValue
                            );
                    break;
                case FeedbackState.征订成功:
                    subs = GetSubscriptionByState(term.YearTerm, id, FeedbackState.征订成功);
                    break;
                case FeedbackState.征订失败:
                    subs = GetSubscriptionByState(term.YearTerm, id, FeedbackState.征订失败);
                    break;
                case FeedbackState.未知状态:
                case FeedbackState.未征订:
                default:
                    break;
            }

            return _adapter.Adapt<SubscriptionForFeedbackView>(subs);
        }

        public FeedbackView GetFeedbackBySubscriptionId(string subscriptionId)
        {
            var id = subscriptionId.ConvertToGuid();
            var subscription = _subscriptionRepo.First(t => t.ID == id);
            if (subscription.Feedback != null)
            {
                return _adapter.Adapt<FeedbackView>(subscription.Feedback);
            }
            else
            {
                return new FeedbackView { Remark = subscription.FeedbackState.ToString() };
            }
        }

        public string GetFeedbackPerson(string loginName)
        {
            var name = new TbmisUserAppl(loginName).GetUser().TbmisUserName;
            return name;
        }

        #endregion

    }
}
