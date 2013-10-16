using System;
using System.Collections.Generic;
using TextbookManage.Domain.IRepositories;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;
using System.Linq;

namespace TextbookManage.Applications.Impl
{
    public class TextbookApprovalAppl : ITextbookApprovalAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;
        private readonly ITextbookRepository _textbookRepo;
        
        #endregion

        #region 构造函数

        public TextbookApprovalAppl(ITypeAdapter adapter, ITextbookRepository textbookRepo)
        {
            _adapter = adapter;
            _textbookRepo = textbookRepo;
        }
        #endregion

        #region 实现接口

        public string GetAuditor(string loginName)
        {
            return new TbmisUserAppl(loginName).GetUser().TbmisUserName;
        }

        /// <summary>
        /// 获取没有审核教材的学院列表
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolWithNotApproval(string loginName)
        {
            //系统用户
            var user = new TbmisUserAppl(loginName).GetUser();

            IList<School> schools = new List<School>();

            //如果是教务处或教材科，取全部学院
            if (user.IsInRole("教务处"))
            {
                var school = _textbookRepo.Find(t =>                    
                    t.ApprovalState == ApprovalState.教务处审核中
                    ).SelectMany(t =>
                        t.Declarant.Departments
                        ).Select(t =>
                            t.School
                            ).Distinct();
                schools = school.ToList();
            }
            else if (user.IsInRole("教材科"))
            {
                var school = _textbookRepo.Find(t =>
                    t.ApprovalState == ApprovalState.教材科审核中
                    ).SelectMany(t =>
                        t.Declarant.Departments
                        ).Select(t =>
                            t.School
                            ).Distinct();
                schools = school.ToList();
            }
            //如果是学院院长，返回所属学院
            else if (user.IsInRole("学院院长"))
            {
                var school = new School { SchoolId = (Guid)user.SchoolId, Name = user.SchoolName };
                schools.Add(school);
            }
            //处理结果
            if (schools.Count > 0)
            {
                return _adapter.Adapt<SchoolView>(schools);
            }
            else
            {
                IEnumerable<SchoolView> school = new List<SchoolView>
                {
                    new SchoolView { SchoolId = string.Empty, Name = "没有需要审核的学院" }
                };
                return school;
            }
        }

        /// <summary>
        /// 获取没有审核的教材列表
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<TextbookForQueryView> GetTextbookWithNotApproval(string loginName, string schoolId)
        {
            //登录用户
            var user = new TbmisUserAppl(loginName).GetUser();

            var id = schoolId.ConvertToGuid();

            IEnumerable<Textbook> books = new List<Textbook>();

            //如果是教务处或教材科，取全部
            if (user.IsInRole("教务处"))
            {
                books = _textbookRepo.Find(t =>
                   t.ApprovalState == ApprovalState.教务处审核中 &&
                   t.Declarant.Departments.Where(d =>
                       d.School_Id == id
                       ).Count() > 0
                       );

                //books = _schoolRepo.Find(t =>
                //    t.SchoolId == id
                //    ).SelectMany(t =>
                //        t.Departments
                //        ).SelectMany(t =>
                //            t.Teachers
                //            ).SelectMany(t =>
                //                t.Textbooks
                //                ).Where(t =>
                //                    t.ApprovalState == ApprovalState.教务处审核中
                //                    ).Distinct();
            }
            else if (user.IsInRole("教材科"))
            {
                books = _textbookRepo.Find(t =>
                    t.ApprovalState == ApprovalState.教材科审核中 &&
                    t.Declarant.Departments.Where(d =>
                        d.School_Id == id
                        ).Count() > 0
                        );
            }
            //如果是学院院长，返回所属学院
            else if (user.IsInRole("学院院长"))
            {
                books = _textbookRepo.Find(t =>
                    t.ApprovalState == ApprovalState.学院审核中 &&
                    t.Declarant.Departments.Where(d =>
                        d.School_Id == id
                        ).Count() > 0
                        );
            }
            //处理结果
            if (books.Count() > 0)
            {
                return _adapter.Adapt<TextbookForQueryView>(books);
            }
            else
            {
                return new List<TextbookForQueryView>();
            }
        }

        public ResponseView SubmitTextbookApproval(IEnumerable<TextbookForQueryView> textbooks, string loginName, string suggestion, string remark)
        {
            //类型转换
            var user = new TbmisUserAppl(loginName).GetUser();
            var auditor = user.TbmisUserName;
            var division = user.SchoolName;
            var sugg = suggestion.ConvertToBool();
            //CUD仓储
            var repo = ServiceLocator.Current.GetInstance<ITextbookRepository>();
            //操作响应类
            var result = new ResponseView();

            //处理审核记录
            foreach (var item in textbooks)
            {
                var id = item.TextbookId.ConvertToGuid();
                var book = repo.First(t => t.TextbookId == id);
                Domain.ApprovalService.CreateApproval<TextbookApproval>(book, division, auditor, sugg, remark);
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
