using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;

namespace TextbookManage.Applications.Impl
{
    public class BooksellerAppl : IBooksellerAppl
    {

        #region 私有变量

        private readonly IBooksellerRepository _repo = ServiceLocator.Current.GetInstance<IBooksellerRepository>();
        private readonly ITypeAdapter _adapter = ServiceLocator.Current.GetInstance<ITypeAdapter>();

        #endregion

        #region 共有方法

        /// <summary>
        /// 获取当前登录用户的书商
        /// </summary>
        /// <returns></returns>
        public Bookseller GetOfUser(string loginName)
        {
            var user = new TbmisUserAppl(loginName).GetUser();
            var bookseller = _repo.First(t => t.ID == user.TbmisUserId);
            return bookseller;
        }

        /// <summary>
        /// 取全部书商
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Bookseller> GetAll()
        {
            return _repo.GetAll();
        }


        /// <summary>
        /// 根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<School> GetSchoolByLoginName(string loginName)
        {
            //登录名取书商ID
            var booksellerId = new TbmisUserAppl(loginName).GetUser().SchoolId;
            //取当前学期
            var term = new TermAppl().GetCurrentTerm().SchoolYearTerm;
            //取学生用书申报的ID集合
            var declarations = _repo.First(t =>
                t.ID == booksellerId
                ).Subscriptions.Where(t =>
                    t.SchoolYearTerm.Year == term.Year &&
                    t.SchoolYearTerm.Term == term.Term &&
                    t.FeedbackState == FeedbackState.征订成功 &&
                    t.Feedback.ApprovalState == ApprovalState.终审通过
                    ).SelectMany(t =>
                        t.StudentDeclarations
                        ).Select(t =>
                            t.ID
                            );
            //取学生班级
            var repo = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();

            //取学院
            var schools = new List<School>();
            foreach (var item in declarations)
            {
                var schoolsOfDeclaration = repo.GetSchools(item).ToList();
                if (schoolsOfDeclaration.Count > 0)
                    schools.Concat(schoolsOfDeclaration);
            }

            return schools.Distinct();
        }
        #endregion


        public IEnumerable<BooksellerView> GetBooksellers()
        {
            var bookserller = GetAll();
            return _adapter.Adapt<BooksellerView>(bookserller);
        }
    }
}
