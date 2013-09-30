using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Infrastructure.Logger;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Infrastructure.Test
{
    [TestClass]
    public class ServiceLocatorTest
    {
        [TestMethod]
        public void InitialUnityServiceLocator()
        {
            var log = ServiceLocator.Current.GetInstance<ILogger>("ExceptionLogger");
            Assert.IsNotNull(log);
        }

        [TestMethod]
        public void CacheBehavior()
        {
            var cache = new InterceptionBehaviors.CacheBehavior();
            Assert.IsInstanceOfType(cache, typeof(InterceptionBehaviors.CacheBehavior));
        }
    }
}
