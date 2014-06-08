using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Domain.IRepositories;
using System.Transactions;
using TextbookManage.Repositories.EntityFramework;
using System.Linq;
using TextbookManage.Infrastructure;

namespace TextbookManage.Repositories.Test
{
    [TestClass]
    public class DeclarationTests
    {
        //仓储上下文
        IRepositoryContext _context;
        //事务
        TransactionScope _trans;
        [TestInitialize]
        public void Initialize()
        {
            _context = new EntityFrameworkRepositoryContext();
            _trans = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //回滚事务，清除对数据库的操作，如新建记录
            _trans.Dispose();
        }

        [TestMethod]
        public void GetProfessionalClassesForDeclaration_IsExist()
        {
            var repo = new StudentDeclarationRepository(_context);
            var id = "63BBECCB-E8B2-4EF6-BF36-0F16387F2611".ConvertToGuid();
            var result = repo.GetProfessionalClasses(id);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetProfessionalClassesForDeclaration_NotExist()
        {
            var repo = new StudentDeclarationRepository(_context);
            var id = Guid.NewGuid();
            var result = repo.GetProfessionalClasses(id);
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void GetDeclarationCount()
        {
            var repo = new StudentDeclarationRepository(_context);
            var id = "63BBECCB-E8B2-4EF6-BF36-0F16387F2611".ConvertToGuid();
            var result = repo.GetProfessionalClasses(id).ToList();
            var declarationCount = repo.Single(t => t.ID == id).DeclarationCount;
            var sum = result.Sum(t => t.StudentCount);
            Assert.IsTrue(sum <= declarationCount);
        }

        [TestMethod]
        public void GetSchoolsForDeclaration_IsExist()
        {
            var repo = new StudentDeclarationRepository(_context);
            var id = "63BBECCB-E8B2-4EF6-BF36-0F16387F2611".ConvertToGuid();
            var result = repo.GetSchools(id).ToList();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetSchoolsForDeclaration_NotExist()
        {
            var repo = new StudentDeclarationRepository(_context);
            var id = Guid.NewGuid();
            var result = repo.GetSchools(id).ToList();
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
