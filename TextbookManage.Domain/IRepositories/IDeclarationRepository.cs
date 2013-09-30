namespace TextbookManage.Domain.IRepositories
{

    using System.Collections.Generic;

    public interface IDeclarationRepository : IRepository<Models.Declaration>
    {
        /// <summary>
        /// 取回告
        /// </summary>
        /// <param name="declarationId"></param>
        /// <returns></returns>
        Models.Feedback GetFeedbackByDeclarationId(int declarationId);


    }
}
