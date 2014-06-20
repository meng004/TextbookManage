using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextbookManage.Infrastructure.Logger
{
    public enum LoggerName
    {
        /// <summary>
        /// 普通记录
        /// 存放于Log.txt
        /// </summary>
        Logger,
        /// <summary>
        /// 异常记录
        /// 存放与ExceptionLog.txt
        /// </summary>
        ExceptionLogger
    }
}
