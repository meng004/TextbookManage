namespace TextbookManage.Repositories
{

    using System.Data.Entity;
    using TextbookManage.Domain.Models;
    using TextbookManage.Infrastructure.UnitOfWork;
    using TextbookManage.Repositories.Mapping;

    public class JwUnitOfWork : DbContext,IUnitOfWork
    {
        static JwUnitOfWork()
        {
            Database.SetInitializer<JwUnitOfWork>(null);
        }

        public JwUnitOfWork()
            : base("Name=JwContext")
        {
        }

        public DbSet<DataSign> DataSigns { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachingTask> TeachingTasks { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DataSignMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new SchoolMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new TeachingTaskMap());
            modelBuilder.Configurations.Add(new TermMap());
            modelBuilder.Configurations.Add(new StudentClassMap());
        }


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
