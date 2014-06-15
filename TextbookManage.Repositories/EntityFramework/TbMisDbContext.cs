namespace TextbookManage.Repositories.EntityFramework
{

    using System.Data.Entity;
    using TextbookManage.Domain.Models;
    using TextbookManage.Domain.Models.JiaoWu;
    using TextbookManage.Repositories.Mapping;
    using TextbookManage.Repositories.Mapping.JiaoWu;

    public class TbMisDbContext
        : DbContext
    {

        #region 构造函数

        static TbMisDbContext()
        {
            Database.SetInitializer<TbMisDbContext>(null);
        }

        public TbMisDbContext()
            : base("TbMisContext")
        {
        }

        #endregion

        #region 模型集合

        //教材数据集，只给出聚合根
        public DbSet<Approval> Approvals { get; set; }
        public DbSet<Bookseller> Booksellers { get; set; }
        public DbSet<BooksellerStaff> BooksellerStaffs { get; set; }
        public DbSet<CasMapper> CasMappers { get; set; }
        //public DbSet<Declaration> Declarations { get; set; }
        public DbSet<FeedbackApproval> FeedbackApprovals { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ReleaseRecord> ReleaseRecords { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StockRecord> StockRecords { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StudentReleaseRecord> StudentReleaseRecords { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TbmisUser> TbmisUsers { get; set; }
        public DbSet<TeacherReleaseRecord> TeacherReleaseRecords { get; set; }
        
        //教务基础数据集
        public DbSet<Course> Courses { get; set; }
        public DbSet<DataSign> DataSigns { get; set; }
        /// <summary>
        /// 抽象类，不映射
        /// </summary>
        //public DbSet<Declaration> Declarations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Press> Presses { get; set; }
        public DbSet<ProfessionalClass> ProfessionalClasses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudentDeclarationJiaoWu> StudentDeclarationJiaoWus { get; set; }  
        public DbSet<StudentDeclaration> StudentDeclarations { get; set; }   
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherDeclarationJiaoWu> TeacherDeclarationJiaoWus { get; set; }
        public DbSet<TeacherDeclaration> TeacherDeclarations { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachingTask> TeachingTasks { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Textbook> Textbooks { get; set; }

        #endregion

        #region 模型映射

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //教材对象映射
            modelBuilder.Configurations.Add(new ApprovalMap());
            modelBuilder.Configurations.Add(new BooksellerMap());
            modelBuilder.Configurations.Add(new BooksellerStaffMap());
            modelBuilder.Configurations.Add(new CasMapperMap());
            //modelBuilder.Configurations.Add(new DeclarationApprovalMap());
            modelBuilder.Configurations.Add(new FeedbackApprovalMap());
            modelBuilder.Configurations.Add(new FeedbackMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new ReleaseRecordMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new StockRecordMap());
            modelBuilder.Configurations.Add(new StorageMap());
            modelBuilder.Configurations.Add(new StudentReleaseRecordMap());
            modelBuilder.Configurations.Add(new SubscriptionMap());
            modelBuilder.Configurations.Add(new TbmisUserMap());
            modelBuilder.Configurations.Add(new TeacherReleaseRecordMap());


            //教务对象映射
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new DataSignMap());
            //modelBuilder.Configurations.Add(new DeclarationClassMap());
            //modelBuilder.Configurations.Add(new DeclarationMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new PressMap());
            modelBuilder.Configurations.Add(new ProfessionalClassMap());
            modelBuilder.Configurations.Add(new SchoolMap());
            modelBuilder.Configurations.Add(new StudentDeclarationJiaoWuMap());
            modelBuilder.Configurations.Add(new StudentDeclarationMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new TeacherDeclarationJiaoWuMap());
            modelBuilder.Configurations.Add(new TeacherDeclarationMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new TeachingTaskMap());
            modelBuilder.Configurations.Add(new TeachingTaskTeacherMap());
            modelBuilder.Configurations.Add(new TermMap());
            //modelBuilder.Configurations.Add(new TextbookApprovalMap());
            modelBuilder.Configurations.Add(new TextbookMap());

        }
        #endregion

    }
}
