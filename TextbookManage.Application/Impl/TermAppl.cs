using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;

namespace TextbookManage.Applications.Impl
{
    public class TermAppl : ITermAppl
    {

        #region 私有变量
        private readonly ITypeAdapter _adapter = ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ITermRepository _repo = ServiceLocator.Current.GetInstance<ITermRepository>();
        #endregion

        #region 共有方法

        /// <summary>
        /// 取全部学年学期
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Term> GetAll()
        {
            return _repo.GetAll().OrderByDescending(t => t.YearTerm);
        }

        /// <summary>
        /// 取当前学年学期
        /// </summary>
        /// <returns></returns>
        public Term GetCurrentTerm()
        {
            var term = _repo.First(t => t.DqXnXqBz == "1");
            return term;
        }

        public Term GetMaxTerm()
        {
            var terms = _repo.GetAll();
            var max = terms.Max(t => t.YearTerm);
            var term = terms.First(t => t.YearTerm == max);

            return term;
        }
        #endregion


        public IEnumerable<TermView> GetAllTerms()
        {
            var terms = GetAll();
            return _adapter.Adapt<TermView>(terms);
        }

        public TermView GetCurrent()
        {
            var term = GetCurrentTerm();
            return _adapter.Adapt<TermView>(term);
        }


    }
}
