using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextbookManage.Domain.Test
{
    [Flags]
    public enum Week
    {
        monday = 1,
        tuesday = 2,
        wednesday = 4,
        thursday = 8,
        friday = 16,
        saturday = 32,
        sunday = 64
    }
    /// <summary>
    /// EnumTests 的摘要说明
    /// </summary>
    [TestClass]
    public class EnumTests
    {

        //public EnumTests()
        //{
        //    //
        //    //TODO:  在此处添加构造函数逻辑
        //    //
        //}

        //private TestContext testContextInstance;

        ///// <summary>
        /////获取或设置测试上下文，该上下文提供
        /////有关当前测试运行及其功能的信息。
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        //[TestInitialize()]
        //public void MyTestInitialize() 
        //{ }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetValues_typeofInt()
        {
            int i = 0;
            foreach (var item in Enum.GetValues(typeof(Week)))
            {
                i = (int)item;
            }
            Assert.IsInstanceOfType(i, typeof(int));
        }

        [TestMethod]
        public void FlagAnd()
        {
            int i = 0;
            var flag = Week.monday | Week.wednesday;
            i = (int)flag;
            Assert.AreEqual(5, i);
        }

        [TestMethod]
        public void FlagContains()
        {
            var flag = Week.monday | Week.wednesday;
            var i = flag & Week.monday;
            var j = flag & Week.sunday;
            Assert.IsTrue(i == Week.monday);
            Assert.IsTrue(j == Week.wednesday);
        }

        [TestMethod]
        public void FlagXor()
        {
            var flag = Week.monday | Week.wednesday | Week.sunday;
            Assert.IsTrue(flag.HasFlag(Week.wednesday));
        }

        [TestMethod]
        public void GetFeedbackState()
        {
            var models = SubscriptionService.GetFeedbackState();
            Assert.IsNotNull(models);
        }
    }
}
