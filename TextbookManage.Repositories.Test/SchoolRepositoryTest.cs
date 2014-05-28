﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Repositories;
using TextbookManage.Infrastructure;
using TextbookManage.Domain.Models;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain.IRepositories;

namespace TextbookManage.Repositories.Test
{
    [TestClass]
    public class SchoolRepositoryTest
    {


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
            var result = repo.Find(t => t.Term == "2011-2012-2");
            //.Where(t => t.CanSubscribe);
            Assert.IsTrue(result.Count() > 0);

            IEnumerable<Declaration> decl = teachingTaskRepo.First(t =>
                t.TeachingTaskNum == "201105820"
                ).Declarations;
            Assert.IsTrue(decl.Count() > 0);
        }

        [TestMethod]
        public void GetStudentDeclarationByRepo()
        {
            //IUnitOfWork uow = new TbMisUnitOfWork();
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new StudentDeclarationRepository(uow);
            var result = repo.Find(t => t.Term == "2011-2012-2");
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
        public void GetDataSign()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new DataSignRepository(uow);
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

        [TestMethod]
        public void GetStudentDeclaration()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new DeclarationRepository(uow);
            var result = repo.Find(t=>t.RecipientType==RecipientType.学生);
            Assert.IsTrue(result.Count() > 0);
        }

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
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new SubscriptionRepository(uow);
            var result = repo.GetAll();
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void GetTeacherDeclaration()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TeacherDeclarationRepository(uow);
            var result = repo.GetAll();
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

        [TestMethod]
        public void ApprovalStateIsWhat()
        {
            IRepositoryContext uow = new EntityFrameworkRepositoryContext();
            var repo = new TextbookRepository(uow);
            var id = "6D20B79F-75C4-48F1-8944-005B8BE872EC".ConvertToGuid();
            var result = repo.First(t => t.TextbookId == id);
            Assert.IsTrue(result.ApprovalState == ApprovalState.教务处审核中);
        }

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