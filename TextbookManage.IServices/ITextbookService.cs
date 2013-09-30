using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices
{
    [ServiceContract]
    public interface ITextbookService
    {
        /// <summary>
        /// 由教师ID，取其申报的教材
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetByTeacherId(QueryRequest teacherId);

        /// <summary>
        /// 添加教材
        /// </summary>
        /// <param name="textbook"></param>
        /// <param name="teacherId"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse Add(AddRequest textbook);

        /// <summary>
        /// 取待审学院
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [OperationContract]        
        QueryCollectionResponse GetSchoolWithNotApproval(QueryRequest username);

        /// <summary>
        /// 根据用户名，学院ID
        /// 取待审核教材
        /// </summary>
        /// <param name="username"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        QueryCollectionResponse GetWithNotApproval(QueryRequest schoolId);

        /// <summary>
        /// 保存审核信息
        /// </summary>
        /// <param name="textbookId"></param>
        /// <param name="division"></param>
        /// <param name="auditor"></param>
        /// <param name="suggestion"></param>
        /// <param name="remark"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ModifyResponse AddApproval(ModifyRequest approval);

        /// <summary>
        /// 根据教材ID，取审核记录
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetApproval(QueryRequest textbookId);

        /// <summary>
        /// 根据教材ID，取教材
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QuerySingleResponse GetById(QueryRequest textbookId);

        /// <summary>
        /// 根据名称或ISBN
        /// 取教材
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetByName(QueryRequest textbookName);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="subscriptionIds"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        RemoveResponse Remove(RemoveRequest textbook);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="booksellerId"></param>
        /// <param name="spareCount"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ModifyResponse Modify(ModifyRequest textbook);
    }
}
