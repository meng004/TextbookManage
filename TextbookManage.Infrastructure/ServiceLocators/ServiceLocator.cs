
namespace TextbookManage.Infrastructure.ServiceLocators
{

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System;
    using System.Linq;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {

        #region 私有变量

        private readonly IUnityContainer _container;

        private static readonly ServiceLocator _instance = new ServiceLocator();
        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private static void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_instance != null)
                    _instance.Dispose();
            }

        }
        ~ServiceLocator()
        {
            Dispose(false);
        }
        #endregion

        #region 构造函数
        private ServiceLocator()
        {
            //读取配置文件，如app.config，web.config，向Unity容器注册对象
            //UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //_container = new UnityContainer();
            //section.Configure(_container);

            //从外部类，向Unity容器注册对象
            _container = new UnityContainer();

            //取配置类
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces()
                    //.ImplementedInterfaces
                    .Contains(typeof(IUnityBootstrapper)));
            //注册类型
            foreach (var item in profiles)
            {
                var bootstraper = Activator.CreateInstance(item) as IUnityBootstrapper;
                bootstraper.RegisterTypes(_container);
            }
        }

        #endregion

        #region 公共属性

        public static ServiceLocator Current
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        #region 实现接口

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.ResolveAll<TService>();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.ResolveAll(serviceType, new ResolverOverride[0]);
        }

        public TService GetInstance<TService>(string key)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve<TService>(key, new ResolverOverride[0]);
        }

        public TService GetInstance<TService>()
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve<TService>();
        }

        public object GetInstance(Type serviceType, string key)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve(serviceType, key, new ResolverOverride[0]);
        }

        public object GetInstance(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve(serviceType, new ResolverOverride[0]);
        }

        public object GetService(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve(serviceType, new ResolverOverride[0]);
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 参数转换
        /// </summary>
        /// <param name="overridedArguments"></param>
        /// <returns></returns>
        private static IEnumerable<ParameterOverride> GetParameterOverrides(object overridedArguments)
        {
            List<ParameterOverride> overrides = new List<ParameterOverride>();
            Type argumentsType = overridedArguments.GetType();
            argumentsType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToList()
                .ForEach(property =>
                {
                    var propertyValue = property.GetValue(overridedArguments, null);
                    var propertyName = property.Name;
                    overrides.Add(new ParameterOverride(propertyName, propertyValue));
                });
            return overrides;
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 使用重载构造函数参数，创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="overridedArguments"></param>
        /// <returns></returns>
        public TService GetInstance<TService>(object overridedArguments)
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            var overrides = GetParameterOverrides(overridedArguments);
            return _container.Resolve<TService>(overrides.ToArray());
        }

        /// <summary>
        /// 使用重载构造函数参数，获取实例
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="overridedArguments"></param>
        /// <returns></returns>
        public object GetInstance(Type serviceType, object overridedArguments)
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            var overrides = GetParameterOverrides(overridedArguments);
            return _container.Resolve(serviceType, overrides.ToArray());
        }
        #endregion

    }
}
