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
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;
using TextbookManage.Domain;
using System.Linq;

namespace TextbookManage.Applications.Test
{

    [TestClass]
    public class SubscriptionTests
    {
        private ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private ITeachingTaskRepository _teachingTaskRepo;//= ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        private IStudentDeclarationRepository _stuDeclRepo;// = ServiceLocator.Current.GetInstance<IStudentDeclarationRepository>();
        private ITeacherDeclarationRepository _teaDeclRepo;// = ServiceLocator.Current.GetInstance<ITeacherDeclarationRepository>();
        private IStudentDeclarationJiaoWuRepository _stuDeclJiaoWuRepo;
        private ITeacherDeclarationJiaoWuRepository _teaDeclJiaoWuRepo;
        private ISubscriptionRepository _subscriptionRepo;
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
            _stuDeclJiaoWuRepo = new StudentDeclarationJiaoWuRepository(_context);
            _teaDeclJiaoWuRepo = new TeacherDeclarationJiaoWuRepository(_context);
            _stuDeclRepo = new StudentDeclarationRepository(_context);
            _teaDeclRepo = new TeacherDeclarationRepository(_context);
            _subscriptionRepo = new SubscriptionRepository(_context);

            _appl = new SubscriptionAppl(
                _adapter, 
                _stuDeclJiaoWuRepo, 
                _teaDeclJiaoWuRepo, 
                _stuDeclRepo, 
                _teaDeclRepo,
                _subscriptionRepo
                );
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

        [TestMethod]
        public void SaveSubscriptionWithStudentDeclaration()
        {
            //取未征订学生申报
            var studentDeclarations = _appl.GetNotSubscriptionStudentDeclarationJiaoWu("2013-2014-2");
            var teacherDeclarations = _appl.GetNotSubscriptionTeacherDeclarationJiaoWu("2013-2014-2");
            //生成订单
            var subscriptions = SubscriptionService.CreateSubscriptionsByPress(studentDeclarations, teacherDeclarations);
            //保存
            var repo = new SubscriptionRepository(_context);
            for (int i = 0; i < subscriptions.Count(); i = i + 300)
            {
                foreach (var item in subscriptions.Skip(i).Take(300))
                {
                    repo.Add(item);
                }
                repo.Context.Commit();
            }           

            var ids = subscriptions.Select(d => d.ID);
            var result = repo.Find(t => ids
                .Contains(t.ID)
                );
            Assert.AreEqual(subscriptions.Count(), result.Count());
        }

    }
}
