using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.IRepositories.JiaoWu
{
    public interface ITextbookRepository : IRepository<Textbook>
    {
        // #region 获取教材信息


        // /// <summary>
        // /// 通过教材名称获取教材列表
        // /// </summary>
        // /// <param name="textBookName">教材名称</param>
        // /// <returns></returns>
        // IList<Textbook> GetTextbookListByName(string textBookName);

        // /// <summary>
        // /// 通过教材ISBN获取教材列表
        // /// </summary>
        // /// <param name="Isbn">isbn</param>
        // /// <returns></returns>
        // IList<Textbook> GetTextbookListByISBN(string Isbn);

        // /// <summary>
        // /// 通过教材id获取教材列表
        // /// </summary>
        // /// <param name="textbookId">教材ID</param>
        // /// <returns></returns>
        // Textbook GetTextbookById(Guid textbookId);

        //#endregion

    }
}
