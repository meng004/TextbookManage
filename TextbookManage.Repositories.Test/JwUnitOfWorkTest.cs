using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Infrastructure.UnitOfWork;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure;

namespace TextbookManage.Repositories.Test
{
    [TestClass]
    public class JwUnitOfWorkTest
    {

        [TestMethod]
        public void JwUnitOfWork()
        {
            var uow = ServiceLocator.Current.GetInstance<IUnitOfWork>("JwUow");
            Assert.IsInstanceOfType(uow, typeof(JwUnitOfWork));
        }

        [TestMethod]
        public void JwRepository()
        {
            var repo = ServiceLocator.Current.GetInstance<IRepository<School>>("Jw");

            Assert.IsInstanceOfType(repo.uow, typeof(JwUnitOfWork));
        }

        [TestMethod]
        public void Term()
        {

            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<Term>(uow);
            var current = repo.GetAll();

            Assert.IsTrue(current.Count() > 1);
        }

        [TestMethod]
        public void DataSign()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<DataSign>(uow);
            var current = repo.GetAll().First();
            Assert.IsNotNull(current);
        }

        [TestMethod]
        public void School()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<School>(uow);
            var current = repo.GetAll().First();
            Assert.IsNotNull(current);
        }

        [TestMethod]
        public void Department()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<Department>(uow);
            var current = repo.GetAll().First();
            Assert.IsNotNull(current);
        }

        [TestMethod]
        public void Teacher()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<Teacher>(uow);
            var current = repo.GetAll().First();
            Assert.IsNotNull(current);
        }

        [TestMethod]
        public void Student()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<Student>(uow);
            var current = repo.GetAll().First();
            Assert.IsNotNull(current);
        }

        [TestMethod]
        public void TeachingTask()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Repository<TeachingTask>(uow);

            var current = repo.Find(t => (t.XN == "2011-2012") && (t.XQ == "2"));
            Assert.IsTrue(current.Count() > 0);
        }

        [TestMethod]
        public void StudentCountSqlQuery()
        {
            Guid id = "362BAC7C-0269-4C65-97A8-7F4D1CD6E6A7".ConvertToGuid();
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Jw.StudentRepository(uow);
            var result = repo.GetStudentCountById(id);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void GetStudentClassByTeachingTask()
        {
            var num = "201105820";
            IUnitOfWork uow = new JwUnitOfWork();
            var taskRepo = new Jw.TeachingTaskRepository(uow);
            var classRepo = new Jw.StudentClassRepository(uow);
            var stuRepo = new Jw.StudentRepository(uow);
            var stuClass = new Applications.Jw.TeachingTaskServiceImpl(taskRepo, classRepo, stuRepo);

            var result = stuClass.GetStudentClassById(num);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetCurrentTermString()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Jw.TermRepository(uow);
            var app = new Applications.Jw.TermServiceImpl(repo);
            var result = app.GetCurrent();

            Assert.AreEqual("2011-2012-2", result);
        }

        [TestMethod]
        public void GetAllTermString()
        {
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Jw.TermRepository(uow);
            var app = new Applications.Jw.TermServiceImpl(repo);
            var result = app.GetAll();

            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetGradeBySchoolId()
        {
            string id = "E2C70D6C-3F45-4DDD-8FA2-E8A5B021BD16";
            IUnitOfWork uow = new JwUnitOfWork();
            var repo = new Jw.StudentClassRepository(uow);
            var stuRepo = new Jw.StudentRepository(uow);
            var app = new Applications.Jw.StudentClassServiceImpl(repo,stuRepo);

            var result = app.GetGradeBySchoolId(id);

            Assert.IsTrue(result.Count() > 0);
        }
    }
}
