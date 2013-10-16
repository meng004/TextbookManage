namespace TextbookManage.Domain.IRepositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public interface IRepository<TAggregateRoot> : ISql
        where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// 仓储上下文
        /// </summary>
        IRepositoryContext Context { get; }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageCount">每页记录数量</param>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        //IEnumerable<TAggregateRoot> GetPaged(int pageIndex, int pageCount, Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 单对象查询
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns>单个对象</returns>
        TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 首个对象查询
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(TAggregateRoot entity);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TAggregateRoot entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Modify(TAggregateRoot entity);

    }
}
