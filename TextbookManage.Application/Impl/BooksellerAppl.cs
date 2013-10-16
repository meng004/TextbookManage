using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Applications.Impl
{
    public class BooksellerAppl
    {

        #region 私有变量

        private readonly IBooksellerRepository _repo = ServiceLocator.Current.GetInstance<IBooksellerRepository>();

        #endregion

        #region 共有方法

        /// <summary>
        /// 获取当前登录用户的书商
        /// </summary>
        /// <returns></returns>
        public Bookseller GetOfUser(string loginName)
        {
            var user = new TbmisUserAppl(loginName).GetUser();
            var bookseller = _repo.First(t => t.BooksellerId == user.TbmisUserId);
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
            var term = new TermAppl().GetCurrentTerm().YearTerm;
            //取学生用书申报
            var declarations = _repo.First(t =>
                t.BooksellerId == booksellerId
                ).Subscriptions.Where(t =>
                    t.Term == term &&
                    t.FeedbackState == FeedbackState.征订成功 &&
                    t.Feedback.ApprovalState == ApprovalState.终审通过
                    ).SelectMany(t =>
                        t.Declarations
                        ).OfType<StudentDeclaration>();
            //取学院
            var schools = declarations.SelectMany(t => t.DeclarationClasses).Select(t => t.ProfessionalClass.School).Distinct();

            return schools;
        }
        #endregion

    }
}
