namespace TextbookManage.Domain.IRepositories
{

    using System.Collections.Generic;
    using TextbookManage.Domain.Models;

    /// <summary>
    /// 执行sql语句，操作数据
    /// </summary>
    public interface ISql
    {
        /// <summary>
        /// 执行sql查询
        /// </summary>
        /// <typeparam name="TEntity">Entity type to map query results</typeparam>
        /// <param name="sqlQuery">
        /// Dialect Query 
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer > {0}
        /// </example>
        /// </param>
        /// <param name="parameters">A vector of parameters values</param>
        /// <returns>
        /// Enumerable results 
        /// </returns>
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
            where TEntity : class,IEntity;

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="sqlCommand">
        /// Command to execute
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer > {0}
        /// </example>
        ///</param>
        /// <param name="parameters">A vector of parameters values</param>
        /// <returns>The number of affected records</returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);

    }
}
