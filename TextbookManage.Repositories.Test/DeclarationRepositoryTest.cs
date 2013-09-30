using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories;
using TextbookManage.Infrastructure.UnitOfWork;

namespace TextbookManage.Repositories.Test
{
    [TestClass]
    public class DeclarationRepositoryTest
    {
        [TestMethod]
        public void AddTeacherDeclaration()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var textRepo = new Repository<Textbook>(uow);
            var textbook = new Textbook
            {
                Author = "123",
                Edition = 1,
                Isbn = "1234",
                IsSelfCompile = false,
                Name = "123",
                PageCount = 100,
                Press = "清华",
                PressAddress = "北京",
                Price = 9.08m,
                PrintCount = 1,
                PublishDate = DateTime.Now.AddYears(-2),
                TextbookType = "国家统编"
            };
            textRepo.Add(textbook);

            var declRepo = new Repository<TeacherDeclaration>(uow);
            var stuDeclaration = new TeacherDeclaration
            {
                ApprovalState = ApprovalState.ReadyToSubmit,
                DeclarationCount = 10,
                DeclarationDate = DateTime.Now,
                HadViewFeedback = false,
                Mobile = "123",
                Teacher_ID = Guid.NewGuid(),
                TeachingTask_Num = "123",
                Telephone = "123",
                Term = "2012-2013-1",
                Textbook_ID = textbook.TextbookID                
            };
            declRepo.Add(stuDeclaration);

            uow.Commit();

            Assert.AreNotEqual(0, textbook.TextbookID);
            Assert.AreNotEqual(0, stuDeclaration.DeclarationID);
        }

        [TestMethod]
        public void AddStudentDeclaration()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var textRepo = new Repository<Textbook>(uow);
            var textbook = textRepo.GetAll().First();

            var declRepo = new Repository<StudentDeclaration>(uow);
            var stuDeclaration = new StudentDeclaration
            {
                ApprovalState = ApprovalState.ReadyToSubmit,
                DeclarationCount = 10,
                DeclarationDate = DateTime.Now,
                HadViewFeedback = false,
                Mobile = "123",
                Teacher_ID = Guid.NewGuid(),
                TeachingTask_Num = "123",
                Telephone = "123",
                Term = "2012-2013-1",
                Textbook_ID = textbook.TextbookID
            };
            declRepo.Add(stuDeclaration);

            uow.Commit();
                        
            Assert.AreNotEqual(0, stuDeclaration.DeclarationID);
        }

        [TestMethod]
        public void GetEnum()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var declRepo = new Repository<Declaration>(uow);
            var decl = declRepo.GetAll().First();
            Assert.IsInstanceOfType(decl.RecipientType, typeof(RecipientType));
            Assert.IsInstanceOfType(decl.ApprovalState, typeof(ApprovalState));
        }

        [TestMethod]
        public void GetTeacherDeclaration()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var declRepo = new Repository<TeacherDeclaration>(uow);
            var decl = declRepo.GetAll().First();
            Assert.IsInstanceOfType(decl, typeof(TeacherDeclaration));
        }

        [TestMethod]
        public void GetStudentDeclaration()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var declRepo = new Repository<StudentDeclaration>(uow);
            var decl = declRepo.GetAll().First();
            Assert.IsInstanceOfType(decl, typeof(StudentDeclaration));
        }

        [TestMethod]
        public void GetDeclaration()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var declRepo = new Repository<Declaration>(uow);
            var decl = declRepo.GetAll();
            Assert.IsTrue(decl.Count() > 0);
        }

        //[TestMethod]
        //public void AddApproval()
        //{
        //    IUnitOfWork uow = new TbMisUnitOfWork();
        //    var declRepo = new Repository<TeacherDeclaration>(uow);
        //    var appRepo = new Repository<DeclarationApproval>(uow);
        //    var decl = declRepo.First(t => t.ApprovalState == ApprovalState.ReadyToSubmit);
        //    var app = new DeclarationApproval
        //    {
        //        ApprovalDate = DateTime.Now,
        //        Auditor = "张三",
        //        Declaration = decl,
        //        Division = "教务处",
        //        Suggestion = true,
        //        Remark = "很好"
        //    };
        //    appRepo.Add(app);
        //    uow.Commit();
        //    Assert.AreNotEqual(0, app.ApprovalID);
        //}

        //[TestMethod]
        //public void GetApprovalDeclaration()
        //{
        //    IUnitOfWork uow = new TbMisUnitOfWork();
            
        //    var appRepo = new Repository<Approval>(uow);

        //    var app = appRepo.First(t=>t.ApprovalTarget==ApprovalTarget.Declaration);

        //    Assert.IsInstanceOfType(app, typeof(DeclarationApproval));
        //}

        [TestMethod]
        public void ReleaseRecord()
        {
            IUnitOfWork uow = new TbMisUnitOfWork();
            var repo = new Repository<ReleaseRecord>(uow);
            var records = repo.GetAll();
            Assert.IsTrue(records.Count() > 0);
        }
    }
}
