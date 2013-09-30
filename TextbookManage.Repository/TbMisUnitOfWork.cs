namespace TextbookManage.Repositories
{

    using System.Data.Entity;
    using TextbookManage.Domain.Models;
    using TextbookManage.Infrastructure.UnitOfWork;
    using TextbookManage.Repositories.Mapping;

    public class TbMisUnitOfWork
        : DbContext, IUnitOfWork
    {

        #region 构造函数

        static TbMisUnitOfWork()
        {
            Database.SetInitializer<TbMisUnitOfWork>(null);
        }

        public TbMisUnitOfWork()
            : base("TbMisContext")
        {
        }

        #endregion

        #region 模型集合

        //public DbSet<Approval> Approvals { get; set; }
        public DbSet<Bookseller> Booksellers { get; set; }
        //public DbSet<BooksellerStaff> BooksellerStaffs { get; set; }
        public DbSet<Declaration> Declarations { get; set; }
        //public DbSet<Feedback> Feedbacks { get; set; }
        //public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ReleaseRecord> ReleaseRecords { get; set; }
        //public DbSet<StudentReleaseRecord> ReleaseRecord_Student { get; set; }
        //public DbSet<TeacherReleaseRecord> ReleaseRecord_Teacher { get; set; }
        //public DbSet<StockRecord> StockRecords { get; set; }
        public DbSet<Storage> Storages { get; set; }
        //public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Textbook> Textbooks { get; set; }
        #endregion

        #region 模型映射

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApprovalMap());
            modelBuilder.Configurations.Add(new DeclarationApprovalMap());
            modelBuilder.Configurations.Add(new FeedbackApprovalMap());
            modelBuilder.Configurations.Add(new BooksellerMap());
            modelBuilder.Configurations.Add(new BooksellerStaffMap());
            modelBuilder.Configurations.Add(new DeclarationMap());
            modelBuilder.Configurations.Add(new FeedbackMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new ReleaseRecordMap());
            modelBuilder.Configurations.Add(new StudentReleaseRecordMap());
            modelBuilder.Configurations.Add(new TeacherReleaseRecordMap());
            modelBuilder.Configurations.Add(new StockRecordMap());
            modelBuilder.Configurations.Add(new StorageMap());
            modelBuilder.Configurations.Add(new SubscriptionMap());
            modelBuilder.Configurations.Add(new TextbookMap());
        }
        #endregion

        #region IUnitOfWork

        public void Commit()
        {
            SaveChanges();
        }

        public void RegisterAdded<TEntity>(TEntity entity) where TEntity : class,IEntity
        {
            Set<TEntity>().Add(entity);
        }

        public void RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            //var entry = Entry<TEntity>(entity);
            //if (entry.State == System.Data.EntityState.Detached)
            //{
            //    entry.State = System.Data.EntityState.Modified;
            //}
            Set<TEntity>().Attach(entity);
            var entry = Entry(entity);
            entry.State = System.Data.EntityState.Modified;
        }

        public void RegisterRemoved<TEntity>(TEntity entity) where TEntity : class,IEntity
        {
            Set<TEntity>().Attach(entity);
            Set<TEntity>().Remove(entity);
        }

        #endregion

    }
}
