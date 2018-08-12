using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories;
using Z.EntityFramework.Plus;

//using EntityFramework.Extensions;



namespace TextbookManage.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {

        #region 构造函数

        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IEntityFrameworkRepositoryContext repositoryContext)
                EfContext = repositoryContext;
        }
        #endregion

        #region 实现Repository

        public override IEnumerable<TAggregateRoot> GetAll()
        {
            //不启用更改跟踪，启用并行化查询
            return DbSet.AsParallel().ToList();
        }

        public override IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression)
        {
            //启用并行化查询
            return DbSet.Where(expression).AsParallel().ToList();
        }

        public override TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return DbSet.SingleOrDefault(expression);
        }

        public override TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }

        public override void Add(TAggregateRoot entity)
        {
            EfContext.RegisterNew(entity);
        }

        public override void Remove(TAggregateRoot entity)
        {
            EfContext.RegisterDeleted(entity);
        }

        public override void Modify(TAggregateRoot entity)
        {
            EfContext.RegisterModified(entity);            
        }

        public override IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            //将查询结果转换为实体，但不提供更改跟踪
            return EfContext.Context.Database.SqlQuery<TEntity>(sqlQuery, parameters).AsParallel().ToList();
        }

        public override int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //标准ADO.NET命令
            return EfContext.Context.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
        #endregion

        #region Protected 属性

        /// <summary>
        /// 存储上下文
        /// </summary>
        protected IEntityFrameworkRepositoryContext EfContext { get; }

        /// <summary>
        /// 数据集
        /// </summary>
        protected DbSet<TAggregateRoot> DbSet => EfContext.Context.Set<TAggregateRoot>();

        #endregion

        #region 使用Z.EntityFramework.Plus，实现批量删除、批量更新
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="expression"></param>
        public override void Remove(Expression<Func<TAggregateRoot, bool>> expression)
        {
            DbSet.Where(expression).Delete();
            //_dbSet.Delete(expression);
        }

        /// <summary>
        /// 批量更新
        /// 先筛选，后更新
        /// </summary>
        /// <param name="filterExpression">筛选表达式</param>
        /// <param name="updateExpression">更新表达式</param>
        public override void Modify(Expression<Func<TAggregateRoot, bool>> filterExpression, Expression<Func<TAggregateRoot, TAggregateRoot>> updateExpression)
        {
            //_dbSet.Update(filterExpression, updateExpression);
            DbSet.Where(filterExpression).Update(updateExpression);
        }

        #endregion
    }
}
