using System.Data.Entity;
using System.Threading;
using TextbookManage.Domain.IRepositories;

namespace TextbookManage.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext,
        IEntityFrameworkRepositoryContext
    {

        #region 私有变量

        private readonly ThreadLocal<TbMisDbContext> _localCtx = new ThreadLocal<TbMisDbContext>(() => new TbMisDbContext());

        #endregion

        #region 重写父类方法

        public override void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
        {
            _localCtx.Value.Set<TAggregateRoot>().Remove(obj);
            Committed = false;
        }

        public override void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
        {
            _localCtx.Value.Entry(obj).State = EntityState.Modified;
            Committed = false;
        }

        public override void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
        {
            _localCtx.Value.Set<TAggregateRoot>().Add(obj);
            Committed = false;
        }

        #endregion

        #region 实现RepositoryContext

        public override void Commit()
        {
            if (!Committed)
            {
                var validationErrors = _localCtx.Value.GetValidationErrors();
                var count = _localCtx.Value.SaveChanges();
                Committed = true;
            }
        }

        public override void Rollback()
        {
            //ClearRegistrations();
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
                _localCtx.Value.Dispose();
                _localCtx.Dispose();
                base.Dispose(disposing);
            }
        }
        #endregion

        #region IEntityFrameworkRepositoryContext Members

        public DbContext Context
        {
            get { return _localCtx.Value; }
        }

        #endregion

    }
}
