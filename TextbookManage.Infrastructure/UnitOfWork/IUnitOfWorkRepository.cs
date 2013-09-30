namespace TextbookManage.Infrastructure.UnitOfWork
{

    /// <summary>
    /// 工作单元仓储
    /// </summary>
    public interface IUnitOfWorkRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// 持久化新增实体
        /// </summary>
        /// <param name="item"></param>
        void PersistAdded(TEntity entity);
        /// <summary>
        /// 持久化变更实体
        /// </summary>
        /// <param name="item"></param>
        void PersistModified(TEntity entity);
        /// <summary>
        /// 持久化删除实体
        /// </summary>
        /// <param name="item"></param>
        void PersistRemoved(TEntity entity);
    }
}
