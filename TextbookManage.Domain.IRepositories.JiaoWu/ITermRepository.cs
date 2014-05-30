using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.IRepositories.JiaoWu
{
    public interface ITermRepository : IRepository<Term>
    {
        ///// <summary>
        ///// 得到当前学年 学期
        ///// </summary>
        ///// <returns></returns>
        //string GetCurrentTerm();

        ///// <summary>
        ///// 获取所有学年学期
        ///// </summary>
        ///// <returns></returns>
        //IList<Term> GetTermList();
    }
}
