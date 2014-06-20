using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Applications.Impl;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.Infrastructure.InterceptionBehaviors;
using TextbookManage.Infrastructure.Logger;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Repositories;
using TextbookManage.Repositories.EntityFramework;

namespace TextbookManage.Services
{
    public class UnityBootstrapper : IUnityBootstrapper
    {
        public void RegisterTypes(IUnityContainer container)
        {
            //注册拦截器
            container.AddNewExtension<Interception>();
            //Infrastructure
            container.RegisterType<ITypeAdapter, AutoMapperTypeAdapter>()
                .RegisterType<ICacheProvider, EntLibCacheProvider>(new ContainerControlledLifetimeManager())
                //异常记录器
                .RegisterType<ILogger, Log4netLogger>(LoggerName.ExceptionLogger.ToString(), new InjectionConstructor(LoggerName.ExceptionLogger.ToString()))
                //日志记录器
                .RegisterType<ILogger, Log4netLogger>(LoggerName.Logger.ToString(), new InjectionConstructor(LoggerName.Logger.ToString()));

            //Repository
            container.RegisterType<IBooksellerRepository, BooksellerRepository>()
                .RegisterType<IFeedbackRepository, FeedbackRepository>()
                //单例模式，否则报错 一个实体不能被多个上下文跟踪
                .RegisterType<IRepositoryContext, EntityFrameworkRepositoryContext>(new PerResolveLifetimeManager())
                .RegisterType<IRepository<IAggregateRoot>, EntityFrameworkRepository<IAggregateRoot>>()
                .RegisterType<ISubscriptionRepository, SubscriptionRepository>()
                .RegisterType<ITbmisUserRepository, TbmisUserRepository>();
            //JiaoWu Repository
            container.RegisterType<IDataSignRepository, DataSignRepository>()
                .RegisterType<IDepartmentRepository, DepartmentRepository>()
                .RegisterType<IPressRepository, PressRepository>()
                .RegisterType<IProfessionalClassRepository, ProfessionalClassRepository>()
                .RegisterType<ISchoolRepository, SchoolRepository>()
                .RegisterType<IStudentDeclarationJiaoWuRepository, StudentDeclarationJiaoWuRepository>()
                .RegisterType<IStudentDeclarationRepository, StudentDeclarationRepository>()
                .RegisterType<IStudentRepository, StudentRepository>()
                .RegisterType<ITeacherDeclarationJiaoWuRepository, TeacherDeclarationJiaoWuRepository>()
                .RegisterType<ITeacherDeclarationRepository, TeacherDeclarationRepository>()
                .RegisterType<ITeacherRepository, TeacherRepository>()
                .RegisterType<ITeachingTaskRepository, TeachingTaskRepository>()
                .RegisterType<ITermRepository, TermRepository>()
                .RegisterType<ITextbookRepository, TextbookRepository>();

            //Application
            container.RegisterType<IFeedbackAppl, FeedbackAppl>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<CacheBehavior>(),
                new InterceptionBehavior<ExceptionLoggerBehavior>()
                )
                .RegisterType<IFeedbackApprovalAppl, FeedbackApprovalAppl>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<CacheBehavior>(),
                new InterceptionBehavior<ExceptionLoggerBehavior>()
                )
                .RegisterType<ISubscriptionAppl, SubscriptionAppl>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<CacheBehavior>(),
                new InterceptionBehavior<ExceptionLoggerBehavior>()
                )
                .RegisterType<ITermAppl, TermAppl>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<CacheBehavior>(),
                new InterceptionBehavior<ExceptionLoggerBehavior>()
                )
                .RegisterType<ITextbookAppl, TextbookAppl>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<CacheBehavior>(),
                new InterceptionBehavior<ExceptionLoggerBehavior>()
                );
        }
    }
}