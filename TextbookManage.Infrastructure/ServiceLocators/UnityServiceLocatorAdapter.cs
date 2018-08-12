
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using CommonServiceLocator;
using Unity;
using Unity.Resolution;


namespace TextbookManage.Infrastructure.ServiceLocators
{
    /// <summary>
    /// Unity与ServiceLocator的适配器
    /// </summary>
    public class UnityServiceLocatorAdapter : IServiceLocator, IDisposable
    {

        #region 私有变量

        private readonly IUnityContainer _container;
        #endregion

        #region 构造函数

        public UnityServiceLocatorAdapter(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        ~UnityServiceLocatorAdapter()
        {
            Dispose(false);
        }
        #endregion

        #region 实现接口

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.ResolveAll<TService>();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.ResolveAll(serviceType, new ResolverOverride[0]);
        }

        public TService GetInstance<TService>(string key)
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve<TService>(key, new ResolverOverride[0]);
        }

        public TService GetInstance<TService>()
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve<TService>();
        }

        public object GetInstance(Type serviceType, string key)
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve(serviceType, key, new ResolverOverride[0]);
        }

        public object GetInstance(Type serviceType)
        {
            if (this._container == null)
            {
                throw new ObjectDisposedException("container");
            }
            return _container.Resolve(serviceType, new ResolverOverride[0]);
        }

        public object GetService(Type serviceType)
        {
            if (this._container == null)
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
