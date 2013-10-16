using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;


namespace TextbookManage.IApplications
{
    [ServiceContract]
    public interface ITextbookAppl
    {
        /// <summary>
        /// 取出版社
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<PressView> GetPresses();

        /// <summary>
        /// 新增教材
        /// </summary>
        /// <param name="textbook"></param>
        /// <param name="loginName">申报人</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView Add(TextbookView textbook, string loginName);

        /// <summary>
        /// 修改教材
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView Modify(TextbookView textbook);

        /// <summary>
        /// 删除教材
        /// </summary>
        /// <param name="textbooks"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView Remove(IEnumerable<TextbookForQueryView> textbooks);

        /// <summary>
        /// 由教材ID，取教材
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        TextbookView GetById(string textbookId);

        /// <summary>
        /// 由教材名称或ISBN，取教材
        /// </summary>
        /// <param name="textbookName"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TextbookForQueryView> GetByName(string textbookName, string isbn);
        /// <summary>
        /// 由登录名，取教材
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TextbookForQueryView> GetByLoginName(string loginName);
    }
}
