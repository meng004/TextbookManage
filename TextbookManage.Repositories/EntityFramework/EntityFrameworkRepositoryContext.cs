using System.Data.Entity;
using System.Threading;
using TextbookManage.Domain.IRepositories;

namespace TextbookManage.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext,
        IEntityFrameworkRepositoryContext
    {

        #region 私有变量

        private readonly ThreadLocal<TbMisDbContext> localCtx = new ThreadLocal<TbMisDbContext>(() => new TbMisDbContext());

        #endregion

        #region 重写父类方法

        public override void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Remove(obj);
            Committed = false;
        }

        public override void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Modified;
            Committed = false;
        }

        public override void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Add(obj);
            Committed = false;
        }
        #endregion

        #region 实现RepositoryContex

        public override void Commit()
        {
            if (!Committed)
            {
                var validationErrors = localCtx.Value.GetValidationErrors();
                var count = localCtx.Value.SaveChanges();
                Committed = true;
            }
        }

        public override void Rollback()
        {
            Committed = false;
        }
        #endregion

        #region 重写Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!Committed)
                    Commit();
                localCtx.Value.Dispose();
                localCtx.Dispose();
                base.Dispose(disposing);
            }
        }
        #endregion

        #region IEntityFrameworkRepositoryContext Members

        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        #endregion

    }
}
