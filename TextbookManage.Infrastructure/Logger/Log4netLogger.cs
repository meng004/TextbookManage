namespace TextbookManage.Infrastructure.Logger
{
    using System;

    /// <summary>
    /// 日志类
    /// </summary>
    public class Log4netLogger : ILogger
    {

        #region Private Fields

        private readonly log4net.ILog log;

        #endregion

        #region 构造函数

        /// <summary>
        /// 传入配置文件中logger名称
        /// 用来调用不同的设置
        /// 如：异常日志、审计日志
        /// </summary>
        /// <param name="logger"></param>
        public Log4netLogger(string name)
        {
            log = log4net.LogManager.GetLogger(name);
        }
        #endregion

        #region 实现接口

        /// <summary>
        /// 将指定的字符串信息写入日志。
        /// </summary>
        /// <param name="message">需要写入日志的字符串信息。</param>
        public void Write(string message)
        {
            log.Info(message);
        }

        /// <summary>
        /// 将指定的<see cref="Exception"/>实例详细信息写入日志。
        /// </summary>
        /// <param name="ex">需要将详细信息写入日志的<see cref="Exception"/>实例。</param>
        public void Write(Exception ex)
        {
            log.Error("Exception caught", ex);
        }
        #endregion

    }
}
