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
            if (booksellers.Count == 0)
            {
                var bookseller = new Bookseller
                {
                    ID = Guid.Empty,
                    Name = "没有需要审核的书商"
                };
                booksellers.Add(bookseller);
            }

            return _adapter.Adapt<BooksellerView>(booksellers);
        }

        public IEnumerable<FeedbackForApprovalView> GetFeedbackWithNotApproval(string loginName, string booksellerId)
        {
            //登录用户
            var user = new TbmisUserAppl(loginName).GetUser();
            //书商ID
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
            //审核意见
            var sugg = suggestion.ConvertToBool();
            //审核部门，审核人
            var user = new TbmisUserAppl(loginName).GetUser();
            var division = user.SchoolName;
            var auditor = user.TbmisUserName;
            //回告ID
            var ids = feedbacks.Select(t => t.FeedbackId.ConvertToGuid());
            //消息类
            var result = new ResponseView();
            //保存到db
            try
            {
                //处理审核记录
                var backs = _repo.Find(t => ids.Contains(t.ID)).ToList();
                backs.ForEach(t =>
                    {
                        Domain.ApprovalService.CreateApproval<FeedbackApproval>(t, division, auditor, sugg, remark);
                    });

                _repo.Context.Commit();
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "提交审核失败";
            }
            return result;
        }
        #endregion

    }
}
