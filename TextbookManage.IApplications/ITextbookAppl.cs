using System.Collections.Generic;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;


namespace TextbookManage.IApplications
{

    public interface ITextbookAppl
    {
        /// <summary>
        /// 取出版社
        /// </summary>
        /// <returns></returns>
        [Cache(CacheMethod.Get)]
        IEnumerable<PressView> GetPresses();

        /// <summary>
        /// 新增教材
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        [Cache(CacheMethod.Remove)]
        ResponseView Add(TextbookView textbook);

        /// <summary>
        /// 修改教材
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        [Cache(CacheMethod.Remove)]
        ResponseView Modify(TextbookView textbook);

        /// <summary>
        /// 删除教材
        /// </summary>
        /// <param name="textbooks"></param>
        /// <returns></returns>
        [Cache(CacheMethod.Remove)]
        ResponseView Remove(IEnumerable<TextbookView> textbooks);

        /// <summary>
        /// 由教材ID，取教材
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        TextbookView GetById(string textbookId);

        /// <summary>
        /// 由教材名称或ISBN，取教材
        /// </summary>
        /// <param name="textbookName"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
     
        IEnumerable<TextbookView> GetByName(string textbookName, string isbn);


    }
}
