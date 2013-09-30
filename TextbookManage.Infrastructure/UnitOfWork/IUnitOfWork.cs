namespace TextbookManage.Infrastructure.UnitOfWork
{

    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : System.IDisposable
    {

        /// <summary>
        /// 将变动实体持久化
        /// </summary>
        void Commit();
        /// <summary>
        /// 注册新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="repository"></param>
        void RegisterAdded<TEntity>(TEntity entity)
            where TEntity : class,IEntity;
        /// <summary>
        /// 注册变更实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="repository"></param>
        void RegisterModified<TEntity>(TEntity entity)
            where TEntity : class,IEntity;
        /// <summary>
        /// 注册删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="repository"></param>
        void RegisterRemoved<TEntity>(TEntity entity)
            where TEntity : class,IEntity;

    }
}
