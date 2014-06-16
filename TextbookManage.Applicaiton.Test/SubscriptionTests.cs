using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.IRepositories;
using System.Transactions;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Repositories;
using TextbookManage.IApplications;
using TextbookManage.Applications.Impl;

namespace TextbookManage.Applicaitons.Test
{
    /// <summary>
    /// 用于测试的子类
    /// </summary>
    internal class SubscriptionForTest : SubscriptionAppl
    {
        public SubscriptionForTest(ITypeAdapter adapter, ITeachingTaskRepository teachingTaskRepo, IStudentDeclarationJiaoWuRepository stuDeclJiaoWuRepo, ITeacherDeclarationJiaoWuRepository teaDeclJiaoWuRepo, IStudentDeclarationRepository stuDeclRepo, ITeacherDeclarationRepository teaDeclRepo)
            : base(adapter, teachingTaskRepo, stuDeclJiaoWuRepo, teaDeclJiaoWuRepo, stuDeclRepo, teaDeclRepo)
        {

        }

    }
    [TestClass]
    public class SubscriptionTests
    {
        private ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private ITeachingTaskRepository _teachingTaskRepo;//= ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        private IStudentDeclarationRepository _stuDeclRepo;// = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();
        private ITeacherDeclarationRepository _teaDeclRepo;// = ServiceLocator.Current.GetInstance<ITeacherDeclarationRepository>();
        private IStudentDeclarationJiaoWuRepository _stuDeclJiaoWuRepo;
        private ITeacherDeclarationJiaoWuRepository _teaDeclJiaoWuRepo;
        private SubscriptionAppl _appl;
        //仓储上下文
        IRepositoryContext _context;
        //事务
        TransactionScope _trans;
        [TestInitialize]
        public void Initialize()
        {
            _context = new EntityFrameworkRepositoryContext();
            _trans = new TransactionScope();

            _adapter = new AutoMapperTypeAdapter();
            _teachingTaskRepo = new TeachingTaskRepository(_context);
            _stuDeclJiaoWuRepo = new StudentDeclarationJiaoWuRepository(_context);
            _teaDeclJiaoWuRepo = new TeacherDeclarationJiaoWuRepository(_context);
            _stuDeclRepo = new StudentDeclarationRepository(_context);
            _teaDeclRepo = new TeacherDeclarationRepository(_context);
            _appl = new SubscriptionForTest(_adapter, _teachingTaskRepo, _stuDeclJiaoWuRepo, _teaDeclJiaoWuRepo, _stuDeclRepo, _teaDeclRepo);
        }

        [TestCleanup]
        public void Cleanup()
        {
            //回滚事务，清除对数据库的操作，如新建记录
            _trans.Dispose();

        }


        [TestMethod]
        public void GetNotSubscriptionStudentDeclarationJiaoWu_201320142_EqualExpected()
        {
            var term = "2013-2014-2";
            var actual = _appl.GetNotSubscriptionStudentDeclarationJiaoWu(term).Count;
            var expected = 1179;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNotSubscriptionTeacherDeclarationJiaoWu_201320142_EqualExpected()
        {
            var term = "2013-2014-2";
            var actual = _appl.GetNotSubscriptionTeacherDeclarationJiaoWu(term).Count;
            var expected = 290;
            Assert.AreEqual(expected, actual);
        }

    }
}
