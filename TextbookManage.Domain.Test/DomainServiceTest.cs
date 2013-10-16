using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Domain;

namespace TextbookManage.Domain.Test
{
    [TestClass]
    public class DomainServiceTest
    {
        [TestMethod]
        public void ApprovalTest()
        {
            ApprovalService.CreateApproval<Models.DeclarationApproval>(new Models.Declaration(), "11", "22", true, null);
            ApprovalService.CreateApproval<Models.FeedbackApproval>(new Models.Feedback(), "11", "22", true, null);
            ApprovalService.CreateApproval<Models.TextbookApproval>(new Models.Textbook(), "11", "22", true, null);

        }

        //[TestMethod]
        //public void CreateStudentDeclarationTest()
        //{
        //    var declaration = DeclarationService.CreateDeclaration<Models.StudentDeclaration>("2011-2012-2", "201107884", Guid.NewGuid(), Guid.NewGuid(), "13107341111", "0734-8281111", 100);
        //    Assert.AreEqual(Models.RecipientType.学生, declaration.RecipientType);
        //}

        //[TestMethod]
        //public void CreateTeacherDeclarationTest()
        //{
        //    var declaration = DeclarationService.CreateDeclaration<Models.TeacherDeclaration>("2011-2012-2", "201107884", Guid.NewGuid(), Guid.NewGuid(), "13107341111", "0734-8281111", 100);
        //    Assert.AreEqual(Models.RecipientType.教师, declaration.RecipientType);
        //}
    }
}
