namespace TextbookManage.Infrastructure.InterceptionBehaviors
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Practices.Unity.InterceptionExtension;
    using TextbookManage.Infrastructure.Logger;    


    /// <summary>
    /// 异常日志行为
    /// </summary>
    public class ExceptionLoggerBehavior : IInterceptionBehavior
    {

        #region 字段

        /// <summary>
        /// 日志配置节为ExceptionLogger
        /// </summary>
        readonly ILogger _log = ServiceLocators.ServiceLocator.Current.GetInstance<ILogger>("ExceptionLogger");

        #endregion

        #region 拦截接口

        /// <summary>
        /// 向目标对象添加新接口
        /// </summary>
        /// <returns></returns>
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
            var methodReturn = getNext().Invoke(input, getNext);
            if (methodReturn.Exception != null)
            {
                _log.Write(methodReturn.Exception);
            }
            return methodReturn;
        }

        /// <summary>
        /// 拦截行为是否执行
        /// </summary>
        public bool WillExecute
        {
            get { return true; }
        }
        #endregion

    }
}
