using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories;


namespace TextbookManage.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        #region 私有变量

        private readonly IEntityFrameworkRepositoryContext _efContext;

        #endregion

        #region 构造函数

        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IEntityFrameworkRepositoryContext)
                this._efContext = context as IEntityFrameworkRepositoryContext;
        }
        #endregion

        #region 实现Repository

        public override IEnumerable<TAggregateRoot> GetAll()
        {
            //不启用更改跟踪，启用并行化查询
            return _dbSet.AsParallel().ToList();
        }

        public override IEnumerable<TAggregateRoot> Find(System.Linq.Expressions.Expression<Func<TAggregateRoot, bool>> expression)
        {
            //启用并行化查询
            return _dbSet.Where(expression).AsParallel().ToList();
        }

        public override TAggregateRoot Single(System.Linq.Expressions.Expression<Func<TAggregateRoot, bool>> expression)
        {
            return _dbSet.SingleOrDefault(expression);
        }

        public override TAggregateRoot First(System.Linq.Expressions.Expression<Func<TAggregateRoot, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public override void Add(TAggregateRoot entity)
        {
            _efContext.RegisterNew<TAggregateRoot>(entity);
        }

        public override void Remove(TAggregateRoot entity)
        {
            _efContext.RegisterDeleted<TAggregateRoot>(entity);
        }

        public override void Modify(TAggregateRoot entity)
        {
            _efContext.RegisterModified<TAggregateRoot>(entity);
        }

        public override IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            //将查询结果转换为实体，但不提供更改跟踪
            return _efContext.Context.Database.SqlQuery<TEntity>(sqlQuery, parameters).AsParallel().ToList();
        }

        public override int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //标准ADO.NET命令
            return _efContext.Context.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
        #endregion

        #region Proteced 属性

        /// <summary>
        /// 存储上下文
        /// </summary>
        protected IEntityFrameworkRepositoryContext EFContext
        {
            get { return this._efContext; }
        }

        /// <summary>
        /// 数据集
        /// </summary>
        protected DbSet<TAggregateRoot> _dbSet
        {
            get { return _efContext.Context.Set<TAggregateRoot>(); }
        }
        #endregion
    }
}
