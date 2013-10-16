using System.Collections.Generic;
using TextbookManage.ViewModels;
using System.ServiceModel;


namespace TextbookManage.IApplications
{
    /// <summary>
    /// cas映射操作
    /// </summary>
    [ServiceContract]
    public interface ICasMapperAppl
    {
        /// <summary>
        /// 批量导入映射
        /// </summary>
        /// <param name="casMappers"></param>
        [OperationContract]
        ResponseView Import(IEnumerable<CasMapperView> casMappers);
        /// <summary>
        /// 添加cas映射
        /// </summary>
        /// <param name="casMapper"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseView Add(CasMapperView casMapper);
        /// <summary>
        /// 修改Cas映射
        /// </summary>
        /// <param name="casMapper"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseView Modify(CasMapperView casMapper);
        /// <summary>
        /// 移除cas映射
        /// </summary>
        /// <param name="casMapper"></param>
        /// <returns></returns>        
        [OperationContract]
        ResponseView Remove(CasMapperView casMapper);
        /// <summary>
        /// 由cas数字身份证号，取登录名
        /// </summary>
        /// <param name="casNetId"></param>
        /// <returns></returns>        
        [OperationContract]
        string GetUsernameByCasNetId(string casNetId);

    }
}
