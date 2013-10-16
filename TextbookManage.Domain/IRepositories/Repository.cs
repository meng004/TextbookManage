namespace TextbookManage.Domain.IRepositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 仓储的抽象基类
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class,IAggregateRoot
    {

        #region 私有变量

        /// <summary>
        /// 工作单元，数据上下文
        /// </summary>
        private readonly IRepositoryContext _context;

        #endregion

        #region 构造函数

        public Repository(IRepositoryContext context)
        {
            this._context = context;
        }
         
        #endregion

        #region IRepository

        public IRepositoryContext Context
        {
            get { return this._context; }
        }

        public abstract IEnumerable<TAggregateRoot> GetAll();

        public abstract IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression);

        public abstract TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expression);

        public abstract TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> expression);

        public abstract void Add(TAggregateRoot entity);
        
        public abstract void Remove(TAggregateRoot entity);

        public abstract void Modify(TAggregateRoot entity);
        #endregion

        #region ISql

        public abstract IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity;

        public abstract int ExecuteCommand(string sqlCommand, params object[] parameters);
        #endregion

    }
}
