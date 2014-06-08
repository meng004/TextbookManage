using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Applications.Impl
{
    public class FeedbackApprovalAppl : IFeedbackApprovalAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;
        private readonly IFeedbackRepository _repo;

        #endregion

        #region 构造函数

        public FeedbackApprovalAppl(ITypeAdapter adapter, IFeedbackRepository repo)
        {
            _adapter = adapter;
            _repo = repo;
        }
        #endregion

        #region 实现接口

        public string GetAuditor(string loginName)
        {
            var user = new TbmisUserAppl(loginName).GetUser();
            return user.TbmisUserName;
        }

        public IEnumerable<BooksellerView> GetBooksellerWithNotApproval(string loginName)
        {
            //系统用户
            var user = new TbmisUserAppl(loginName).GetUser();
            //当前学期
            var term = new TermAppl().GetMaxTerm();

            IList<Bookseller> booksellers = new List<Bookseller>();

            //如果是教务处或教材科，取全部学院
            if (user.IsInRole("教务处"))
            {
                var bookseller = _repo.Find(t =>
                    t.ApprovalState == ApprovalState.教务处审核中
                    ).SelectMany(t =>
                        t.Subscriptions
                        ).Select(t =>
                            t.Bookseller
                            ).Distinct();
                booksellers = bookseller.ToList();
            }
            else if (user.IsInRole("教材科"))
            {
                var bookseller = _repo.Find(t =>
                    t.ApprovalState == ApprovalState.教材科审核中
                    ).SelectMany(t =>
                        t.Subscriptions
                        ).Select(t =>
                            t.Bookseller
                            ).Distinct();
                booksellers = bookseller.ToList();
            }
            if (booksellers.Count > 0)
            {
                return _adapter.Adapt<BooksellerView>(booksellers);
            }
            else
            {
                IEnumerable<BooksellerView> school = new List<BooksellerView>
                {
                    new BooksellerView { BooksellerId = string.Empty, Name = "没有需要审核的书商" }
                };
                return school;
            }
        }

        public IEnumerable<FeedbackForApprovalView> GetFeedbackWithNotApproval(string loginName, string booksellerId)
        {
            //登录用户
            var user = new TbmisUserAppl(loginName).GetUser();
            //当前学期
            var term = new TermAppl().GetMaxTerm();
            var id = booksellerId.ConvertToGuid();

            IEnumerable<Feedback> feedbacks = new List<Feedback>();

            //如果是教务处或教材科，取全部
            if (user.IsInRole("教务处"))
            {
                var feedback = _repo.Find(t =>
                    t.ApprovalState == ApprovalState.教务处审核中 &&
                    t.Subscriptions.FirstOrDefault().Bookseller_Id == id
                    );
                feedbacks = feedback;
            }
            else if (user.IsInRole("教材科"))
            {
                var feedback = _repo.Find(t =>
                    t.ApprovalState == ApprovalState.教材科审核中 &&
                    t.Subscriptions.FirstOrDefault().Bookseller_Id == id
                    );
                feedbacks = feedback;
            }

            return _adapter.Adapt<FeedbackForApprovalView>(feedbacks);
        }

        public ResponseView SubmitFeedbackApproval(IEnumerable<FeedbackForApprovalView> feedbacks, string loginName, string suggestion, string remark)
        {
            var sugg = suggestion.ConvertToBool();
            var user = new TbmisUserAppl(loginName).GetUser();
            var division = user.SchoolName;
            var auditor = user.TbmisUserName;

            var repo = ServiceLocator.Current.GetInstance<IFeedbackRepository>();
            var result = new ResponseView();

            //处理审核记录
            foreach (var item in feedbacks)
            {
                var id = item.FeedbackId.ConvertToGuid();
                var feedback = repo.First(t => t.ID == id);
                Domain.ApprovalService.CreateApproval<FeedbackApproval>(feedback, division, auditor, sugg, remark);
            }
            //保存到db
            try
            {
                repo.Context.Commit();
                return result;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "提交审核失败";
                return result;
            }
        }
        #endregion

    }
}
