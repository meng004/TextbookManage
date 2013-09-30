namespace TextbookManage.Infrastructure.Logger
{

    using System;

    public interface ILogger
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="ex"></param>
        void Write(Exception ex);

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message"></param>
        void Write(string message);
    }
}
