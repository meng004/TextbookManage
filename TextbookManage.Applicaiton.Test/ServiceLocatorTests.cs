using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.IApplications;
using TextbookManage.Applications.Impl;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Repositories;
using TextbookManage.Repositories.EntityFramework;
using TextbookManage.Domain;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.Infrastructure.Logger;
using Microsoft.Practices.Unity.InterceptionExtension;
using TextbookManage.Infrastructure.InterceptionBehaviors;
using Rhino.Mocks;

namespace TextbookManage.Applications.Test
{

    public class UnityBootstraper : IUnityBootstrapper
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.AddNewExtension<Interception>();
            container.RegisterType<ITypeAdapter, AutoMapperTypeAdapter>()
                .RegisterType<ICacheProvider, EntLibCacheProvider>(new ContainerControlledLifetimeManager())
                //异常记录器
                .RegisterType<ILogger, Log4netLogger>(LoggerName.ExceptionLogger.ToString(), new InjectionConstructor(LoggerName.ExceptionLogger.ToString()))
                //日志记录器
                .RegisterType<ILogger, Log4netLogger>(LoggerName.Logger.ToString(), new InjectionConstructor(LoggerName.Logger.ToString()))
                .RegisterType<IRepositoryContext, EntityFrameworkRepositoryContext>()
                .RegisterType<IRepository<IAggregateRoot>, EntityFrameworkRepository<IAggregateRoot>>();

            ////测试异常日志AOP专用
            var repo = new MockRepository();
            var stub = repo.Stub<ITermRepository>();
            stub.Expect(t => t.GetAll())
                .Throw(new ArgumentNullException("测试抛出的异常"));
            repo.ReplayAll();
            container.RegisterInstance<ITermRepository>(stub);

            //执行异常日志测试时，注释该语句
            //container.RegisterType<ITermRepository, TermRepository>();

            container.RegisterType<ITermAppl, TermAppl>(
                //new Interceptor<InterfaceInterceptor>(),
                //new InterceptionBehavior<CacheBehavior>(),
                //new InterceptionBehavior<ExceptionLoggerBehavior>()
                );
        }
    }


    [TestClass]
    public class ServiceLocatorTests
    {
        [TestMethod]
        public void UnityInitializeFromExternalClass_GetAutoMapperTypeAdapter()
        {
            var adapter = ServiceLocator.Current.GetInstance<ITypeAdapter>();
            Assert.IsInstanceOfType(adapter, typeof(AutoMapperTypeAdapter));
        }

        [TestMethod]
        public void UnityInitializeFromExternalClass_GetTermRepository()
        {
            var repo = ServiceLocator.Current.GetInstance<ITermRepository>();
            var terms = repo.GetAll();
            Assert.IsTrue(terms.Count() > 0);
        }

        /// <summary>
        /// 需要调试，进入拦截器
        /// </summary>
        [TestMethod]
        public void UnityInitializeFromExternalClass_CacheInterception()
        {
            var appl = ServiceLocator.Current.GetInstance<ITermAppl>();
            var terms = appl.GetAllTerms();
            var terms2 = appl.GetAllTerms();
            Assert.IsTrue(terms2.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "测试抛出的异常")]
        public void UnityInitializeFromExternalClass_LogInterception()
        {
            var appl = ServiceLocator.Current.GetInstance<ITermAppl>();
            var terms = appl.GetAllTerms();
        }

        [TestMethod]
        public void UnityInitializeFromExternalClass_GetInstance()
        {
            var appl = ServiceLocator.Current.GetInstance<TermAppl>();
            Assert.IsNotNull(appl);
        }
    }
}
