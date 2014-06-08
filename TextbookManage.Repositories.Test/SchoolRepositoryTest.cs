using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Repositories;
using TextbookManage.Infrastructure;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models.JiaoWu;
using System.Transactions;

namespace TextbookManage.Repositories.Test
{
    [TestClass]
    public class SchoolRepositoryTest
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
        public void AddBookseller()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new BooksellerRepository(uow);
            var bookseller = new Bookseller { Contact = "张三", Name = "测试", Telephone = "123456" };
            repo.Add(bookseller);
            repo.Context.Commit();
            var result = repo.Single(t => t.Contact == bookseller.Contact && t.Name == bookseller.Name && t.Telephone == bookseller.Telephone);
            Assert.IsNotNull(result.ID);
        }

        [TestMethod]
        public void GetStudentDeclarationJiaoWu()
        {
            var repo = new StudentDeclarationJiaoWuRepository(_context);
            var results = repo.Find(t => t.SchoolYearTerm.Year == "2011-2012" && t.SchoolYearTerm.Term == "2");
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void GetTeacherDeclarationJiaoWu()
        {
            var repo = new TeacherDeclarationJiaoWuRepository(_context);
            var results = repo.Find(t => t.SchoolYearTerm.Year == "2011-2012" && t.SchoolYearTerm.Term == "2");
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void GetStudentDeclaration()
        {
            var repo = new StudentDeclarationRepository(_context);
            var results = repo.Find(t => t.SchoolYearTerm.Year == "2013-2014" && t.SchoolYearTerm.Term == "2");
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void GetTeacherDeclaration()
        {
            var repo = new TeacherDeclarationRepository(_context);
            var results = repo.Find(t => t.SchoolYearTerm.Year == "2013-2014" && t.SchoolYearTerm.Term == "2");
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void DeclarationCountOfStudentDeclaration()
        {
            var repo = new StudentDeclarationRepository(_context);
            var decls = repo.Find(t => t.SchoolYearTerm.Year == "2013-2014" && t.SchoolYearTerm.Term == "2");
            var result = decls.Sum(t => t.DeclarationCount);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeclarationCountOfTeacherDeclaration()
        {
            var repo = new TeacherDeclarationRepository(_context);
            var decls = repo.Find(t => t.SchoolYearTerm.Year == "2013-2014" && t.SchoolYearTerm.Term == "2");
            var result = decls.Sum(t => t.DeclarationCount);
            Assert.IsTrue(result > 0);
        }


        [TestMethod]
        public void GetDataSign()
        {
            var repo = new DataSignRepository(_context);
            var results = repo.GetAll();
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void GetStudentDeclarationsOfDepartment()
        {
            var repo = new DepartmentRepository(_context);
            var id = "B1D98237-5AB1-482A-BFC6-C2000E749962".ConvertToGuid();
            var result = repo.Single(t => t.ID == id);
            Assert.IsTrue(result.StudentDeclarationJiaoWus.Count > 0);
        }

        [TestMethod]
        public void TeachingTaskIsReleased()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TeachingTaskRepository(uow);
            var id = "4E16A2C2-1FD0-4487-B6CC-90BACF1F7EF4".ConvertToGuid();
            //var result = repo.IsReleased("201105758", id);
            //Assert.IsTrue(result);

            var task = repo.First(t => t.TeachingTaskNum == "201105758");
            var isreleased = task.IsReleased(id);
            Assert.IsTrue(isreleased);
        }

        [TestMethod]
        public void GetTbmisUserWithRole()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TbmisUserRepository(uow);
            var user = repo.First(t => t.UserName == "46010");
            Assert.IsTrue(user.IsInRole("教师"));
        }

        //[TestMethod]
        //public void GetDeclarationByMethod()
        //{
        //    //IUnitOfWork uow = new TbMisUnitOfWork();
        //    IUnitOfWork uow = new TextbookManage.Repositories.TbMisUnitOfWork();
        //    var repo = new DeclarationRepository(uow);
        //    var result = repo.Find(t => t.Term == "2012-2013-2").Where(t => t.CanSubscribe());
        //    Assert.IsTrue(result.Count() == 0);
        //}

        [TestMethod]
        public void GetDeclaration()
        {
            //IUnitOfWork uow = new TbMisUnitOfWork();
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new DeclarationRepository(uow);
            var teachingTaskRepo = new TeachingTaskRepository(uow);
            var result = repo.Find(t => t.SchoolYearTerm.Year == "2011-2012" && t.SchoolYearTerm.Term == "2");
            //.Where(t => t.CanSubscribe);
            Assert.IsTrue(result.Count() > 0);

            IEnumerable<TeachingTask> task = teachingTaskRepo.Find(t =>
                t.Course_Id == "684CC75B-AA96-4CBF-8172-E6B5DFC9183A".ConvertToGuid()
                && t.DataSign_Id == "A"
                && t.Department_Id == "CA89359F-06C7-48C0-B8EC-3E9559C4324B".ConvertToGuid()
                );
            Assert.IsTrue(task.Count() > 0);
        }

        [TestMethod]
        public void GetStudentDeclarationJiaoWuByRepo()
        {
            //IUnitOfWork uow = new TbMisUnitOfWork();
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new StudentDeclarationJiaoWuRepository(uow);
            var result = repo.GetAll();
                //Find(t => t.SchoolYearTerm.Year == "2011-2012" && t.SchoolYearTerm.Term == "2");
            //.Where(t => t.CanSubscribe);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetBookseller()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new BooksellerRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }


        [TestMethod]
        public void GetDepartment()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new DepartmentRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetProfessionalClass()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new ProfessionalClassRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetSchools()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new SchoolRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetStorage()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new StorageRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() == 0);
        }

        //[TestMethod]
        //public void GetStudentDeclaration()
        //{
        //    IRepositoryContext uow = new EntityFrameworkRepositoryContext();
        //    var repo = new DeclarationRepository(uow);
        //    var result = repo.Find(t => t.RecipientType == RecipientType.学生);
        //    Assert.IsTrue(result.Count() > 0);
        //}

        [TestMethod]
        public void GetStudentReleaseRecord()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new StudentReleaseRecordRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetStudent()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new StudentRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetSubscription()
        {
            var repo = new SubscriptionRepository(_context);
            var result = repo.Find(t=>t.SchoolYearTerm.Year=="2013-2014" && t.SchoolYearTerm.Term=="2");
            Assert.IsTrue(result.Count() > 0);
        }


        [TestMethod]
        public void GetTeacherReleaseRecord()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TeacherReleaseRecordRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void GetTeacher()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TeacherRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetTeachingTask()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TeachingTaskRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetTerm()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TermRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetTextbook()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TextbookRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }

        //[TestMethod]
        //public void ApprovalStateIsWhat()
        //{
        //    IRepositoryContext uow = new EntityFrameworkRepositoryContext();
        //    var repo = new TextbookRepository(uow);
        //    var id = "6D20B79F-75C4-48F1-8944-005B8BE872EC".ConvertToGuid();
        //    var result = repo.First(t => t.TextbookId == id);
        //    Assert.IsTrue(result.ApprovalState == ApprovalState.教务处审核中);
        //}

        [TestMethod]
        public void GetTbmisUser()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TbmisUserRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }


    }
}
