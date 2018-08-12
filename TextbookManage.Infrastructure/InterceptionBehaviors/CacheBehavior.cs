using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace TextbookManage.Infrastructure.InterceptionBehaviors
{

    using System;
    using System.Collections.Generic;
    using System.Text;
    using TextbookManage.Infrastructure.Cache;
    using TextbookManage.Infrastructure.ServiceLocators;

    public class CacheBehavior : IInterceptionBehavior
    {

        #region 字段

        /// <summary>
        /// 缓存对象
        /// </summary>
        readonly ICacheProvider _cache = ServiceLocator.Current.GetInstance<ICacheProvider>();

        #endregion

        #region Private Methods

        /// <summary>
        /// 构造缓存的Key
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string CreateKey(IMethodInvocation input)
        {
            //拦截目标名称
            //var interfaceName = input.Target.ToString();
            //方法名称
            var methodName = input.MethodBase.Name;
            //key
            //var key = string.Format("{0}_{1}", interfaceName, methodName);

            return methodName;
        }

        /// <summary>
        /// 根据指定的<see cref="CacheAttribute"/>以及<see cref="IMethodInvocation"/>实例，
        /// 获取与某一特定参数值相关的键名。
        /// </summary>
        /// <param name="input"><see cref="IMethodInvocation"/>实例。</param>
        /// <returns>与某一特定参数值相关的键名。</returns>
        private static string CreateValueKey(IMethodInvocation input)
        {
            //用参数值构造valKey
            if (input.Arguments != null &&
                input.Arguments.Count > 0)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < input.Arguments.Count; i++)
                {
                    if (input.Arguments[i] != null)
                    {
                        sb.Append(input.Arguments[i].ToString());
                    }
                    else
                    {
                        sb.Append("NULL");
                    }
                    if (i != input.Arguments.Count - 1)
                        sb.Append("_");
                }
                return sb.ToString();
            }
            else
                return "NULL";
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="input">调用拦截目标时的输入信息。</param>
        /// <param name="getNext">通过行为链来获取下一个拦截行为的委托。</param>        
        /// <returns>返回信息</returns>
        private IMethodReturn CreateMethodReturnForGet(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //取拦截目标的方法名称
            
            //根据实现类与方法，构造key
            var key = CreateKey(input);

            //根据方法的输入参数值构造valKey
            var valKey = CreateValueKey(input);

            //是否已存在该方法的缓存，不存在则调用方法，并将结果写入缓存
            try
            {
                if (_cache.Exists(key, valKey))
                {
                    var obj = _cache.Get(key, valKey);
                    var arguments = new object[input.Arguments.Count];
                    input.Arguments.CopyTo(arguments, 0);
                    return new VirtualMethodReturn(input, obj, arguments);
                }
                else
                {
                    var methodReturn = getNext().Invoke(input, getNext);
                    if (methodReturn.ReturnValue != null)
                    {
                        _cache.Add(key, valKey, methodReturn.ReturnValue);
                    }
                    return methodReturn;
                }
            }
            catch (Exception ex)
            {
                return new VirtualMethodReturn(input, ex);
            }
        }


        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="input">调用拦截目标时的输入信息。</param>
        /// <param name="getNext">通过行为链来获取下一个拦截行为的委托。</param>        
        /// <returns>返回信息</returns>
        private IMethodReturn CreateMethodReturnForRemove(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            try
            {
                //移除该拦截目标的全部缓存
                var target = input.Target.GetType();
                _cache.Remove(target);

                var methodReturn = getNext().Invoke(input, getNext);
                return methodReturn;
            }
            catch (Exception ex)
            {
                return new VirtualMethodReturn(input, ex);
            }
        }


        #endregion

        #region IInterceptionBehavior Members

        /// <summary>
        /// 获取当前行为需要拦截的对象类型接口。
        /// </summary>
        /// <returns>所有需要拦截的对象类型接口。</returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        /// <summary>
        /// 通过实现此方法来拦截调用并执行所需的拦截行为。
        /// </summary>
        /// <param name="input">调用拦截目标时的输入信息。</param>
        /// <param name="getNext">通过行为链来获取下一个拦截行为的委托。</param>
        /// <returns>从拦截目标获得的返回信息。</returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //取拦截目标
            var method = input.MethodBase;

            //方法是否定义了缓存属性
            if (method.IsDefined(typeof(CacheAttribute), false))
            {
                //取缓存属性
                var cacheAttribute = (CacheAttribute)method.GetCustomAttributes(typeof(CacheAttribute), false)[0];
                //Get则写缓存，Remove则清除缓存
                switch (cacheAttribute.Method)
                {
                    case CacheMethod.Get:
                       return CreateMethodReturnForGet(input, getNext);
                      

                    case CacheMethod.Remove:
                      return  CreateMethodReturnForRemove(input, getNext);
                        
                    default:
                        return getNext().Invoke(input, getNext);
                }
            }

            return getNext().Invoke(input, getNext);
        }


        /// <summary>
        /// 获取一个<see cref="Boolean"/>值，该值表示当前拦截行为被调用时，是否真的需要执行
        /// 某些操作。
        /// </summary>
        public bool WillExecute
        {
            get { return true; }
        }

        #endregion

    }
}
