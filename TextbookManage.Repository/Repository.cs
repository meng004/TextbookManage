namespace TextbookManage.Repositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity;
    using TextbookManage.Infrastructure.UnitOfWork;

    public class Repository<TAggregateRoot> : TextbookManage.Domain.IRepositories.IRepository<TAggregateRoot>, IDisposable
        where TAggregateRoot : class,TextbookManage.Domain.IAggregateRoot
    {

        #region 私有变量

        /// <summary>
        /// 工作单元，数据上下文
        /// </summary>
        protected DbContext _unitOfWork;

        #endregion

        #region 构造函数

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
            {
                throw new ArgumentNullException("unit of work");
            }

            if (unitOfWork is DbContext)
            {
                _unitOfWork = unitOfWork as DbContext;
            }
            else
            {
                throw new ArgumentException("Invalid unit of work");
            }
        }
        #endregion

        #region IDispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                    _unitOfWork = null;
                }
        }
        ~Repository()
        {
            Dispose(false);
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 取数据集
        /// </summary>
        /// <returns></returns>
        protected DbSet<TAggregateRoot> DbSet
        {
            get { return _unitOfWork.Set<TAggregateRoot>(); }
        }

        public IUnitOfWork uow
        {
            get
            {
                return _unitOfWork as IUnitOfWork;
            }
        }

        #endregion

        #region IRepository

        public virtual IEnumerable<TAggregateRoot> GetAll()
        {
            //启用并行化
            return DbSet.AsParallel().ToList();
        }

        public virtual IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return DbSet.Where(expression).AsParallel().ToList();
        }

        //public virtual IEnumerable<TAggregateRoot> GetPaged(int pageIndex, int pageCount, Expression<Func<TAggregateRoot, bool>> expression)
        //{
        //    return DbSet.Where(expression).Skip(pageCount * pageIndex).Take(pageCount).ToList();
        //}

        public virtual TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return DbSet.SingleOrDefault(expression);
        }

        public virtual TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }

        public virtual void Add(TAggregateRoot entity)
        {
            
            uow.RegisterAdded(entity);
        }

        public virtual void Remove(TAggregateRoot entity)
        {
            uow.RegisterRemoved(entity);
        }

        public virtual void Modify(TAggregateRoot entity)
        {
            uow.RegisterModified(entity);
        }

        #endregion

        #region ISql

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity
        {
            //将查询结果转换为实体，但不提供更改跟踪
            return _unitOfWork.Database.SqlQuery<TEntity>(sqlQuery, parameters).AsParallel().ToList();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //标准ADO.NET命令
            return _unitOfWork.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }


        #endregion

    }
}
