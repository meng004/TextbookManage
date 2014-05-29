using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.Models;

namespace TextbookManage.Applications.Impl
{
    public class TermAppl
    {

        #region 私有变量

        private readonly ITermRepository _repo = ServiceLocator.Current.GetInstance<ITermRepository>();
        #endregion

        #region 共有方法

        /// <summary>
        /// 取全部学年学期
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Term> GetAll()
        {
            return _repo.GetAll();
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

    }
}
