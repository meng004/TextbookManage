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
            //var id = new TbmisUserAppl(loginName).GetUser().SchoolId;
            var id = "60D6E947-EC9C-4A0A-AEA6-26673C046B3C".ConvertToGuid();
            //学期
            var yearTerm = new SchoolYearTerm(term);

            //var subscriptions = _subscriptionRepo.Find(t =>
            //    t.SchoolYearTerm.Year == yearTerm.Year && //当前学期
            //    t.SchoolYearTerm.Term == yearTerm.Term &&
            //    t.Bookseller_Id == id &&//书商
            //    t.SubscriptionState == FeedbackState.征订中
            //    ).Where(t =>
            //        !t.Feedback_Id.HasValue
            //        ); //未回告;

            var subscriptions = GetSubscriptionByState(term, id, FeedbackState.征订中).Where(t => !t.Feedback_Id.HasValue);

            return _adapter.Adapt<SubscriptionForFeedbackView>(subscriptions);
        }

        public ResponseView SubmitFeedback(IEnumerable<SubscriptionForFeedbackView> subscriptions, string loginName, string feedbackState, string remark)
        {
            //回告意见
            var sugg = feedbackState.ConvertToBool();
            //订单ID
            var ids = subscriptions.Select(t => t.SubscriptionId.ConvertToGuid());
            //回告状态
            FeedbackState state = FeedbackState.未征订;
            Enum.TryParse(feedbackState, out state);
            //返回消息
            var result = new ResponseView();
            //创建回告
            var feedback = SubscriptionService.CreateFeedback(loginName, state, remark);
            //修改订单，增加回告
            var subs = _subscriptionRepo.Find(t => ids.Contains(t.ID));
            foreach (var item in subs)
            {
                //添加回告
                item.Feedback = feedback;
                //修改订单状态
                item.SubscriptionState = state;
                _subscriptionRepo.Modify(item);
            }
            //_subscriptionRepo.Modify(
            //    t => ids.Contains(t.ID),
            //    d => new Subscription { Feedback = feedback }
            //    );
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
            IList<Bookseller> booksellers = new List<Bookseller>();
            if (string.IsNullOrWhiteSpace(loginName))
            {
                booksellers.Add(
                    new Bookseller
                    {
                        ID = Guid.Empty,
                        Name = "你没有权限"
                    });
            }
            else
            {
                var user = new TbmisUserAppl(loginName).GetUser();


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
                    //t.Feedback.FeedbackState == state
                t.SubscriptionState == state
                );
        }

        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionByBooksellerId(string term, string booksellerId, string feedbackStateName)
        {
            //书商ID
            var id = booksellerId.ConvertToGuid();
            //回告状态
            FeedbackState state = FeedbackState.未征订;
            Enum.TryParse(feedbackStateName, out state);

            IEnumerable<Subscription> subs = new List<Subscription>();

            subs = GetSubscriptionByState(term, id, state);

            //switch (state)
            //{
            //    case FeedbackState.征订中:
            //        subs = _subscriptionRepo.Find(t =>
            //            t.SchoolYearTerm.Year == yearTerm.Year &&
            //            t.SchoolYearTerm.Term == yearTerm.Term &&
            //            t.Bookseller_Id == id
            //            ).Where(t =>
            //                !t.Feedback_Id.HasValue
            //                );
            //        break;
            //    case FeedbackState.征订成功:
            //        subs = GetSubscriptionByState(term, id, FeedbackState.征订成功);
            //        break;
            //    case FeedbackState.征订失败:
            //        subs = GetSubscriptionByState(term, id, FeedbackState.征订失败);
            //        break;
            //    case FeedbackState.未知状态:
            //    case FeedbackState.未征订:
            //    default:
            //        break;
            //}

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
