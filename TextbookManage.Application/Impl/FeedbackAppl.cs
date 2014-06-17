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
using TextbookManage.Domain;

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

        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionWithNotFeedback(string term, string loginName)
        {
            //取当前用户的书商ID
            var id = new TbmisUserAppl(loginName).GetUser().SchoolId;
            //学期
            var yearTerm = new SchoolYearTerm(term);

            var subscriptions = _subscriptionRepo.Find(t =>
                t.SchoolYearTerm.Year == yearTerm.Year && //当前学期
                t.SchoolYearTerm.Term == yearTerm.Term &&
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
            var ids = subscriptions.Select(t => t.SubscriptionId.ConvertToGuid());
            var result = new ResponseView();
            //创建回告
            var feedback = Domain.SubscriptionService.CreateFeedback(person, sugg, remark);
            //修改订单，增加回告
            _subscriptionRepo.Modify(
                t => ids.Contains(t.ID),
                d => new Subscription { Feedback = feedback }
                );
            try
            {
                _subscriptionRepo.Context.Commit();

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "回告失败";
            }
            return result;
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
            var models = SubscriptionService.GetFeedbackState();
            var result = _adapter.Adapt<FeedbackStateView>(models);
            return result;
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

        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionByBooksellerId(string term, string booksellerId, string feedbackStateName)
        {
            var yearTerm = new SchoolYearTerm(term);
            var id = booksellerId.ConvertToGuid();
            FeedbackState state = FeedbackState.未征订;
            Enum.TryParse(feedbackStateName, out state);

            IEnumerable<Subscription> subs = new List<Subscription>();

            switch (state)
            {
                case FeedbackState.征订中:
                    subs = _subscriptionRepo.Find(t =>
                        t.SchoolYearTerm.Year == yearTerm.Year &&
                        t.SchoolYearTerm.Term == yearTerm.Term &&
                        t.Bookseller_Id == id
                        ).Where(t =>
                            !t.Feedback_Id.HasValue
                            );
                    break;
                case FeedbackState.征订成功:
                    subs = GetSubscriptionByState(term, id, FeedbackState.征订成功);
                    break;
                case FeedbackState.征订失败:
                    subs = GetSubscriptionByState(term, id, FeedbackState.征订失败);
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
