using log4net;
using System;

namespace ThesisManagement_Core.Utility
{
    public class CommonLogger : Exception
    {
        private ILog log = null;

        /// <summary>
        /// 初始化Logger
        /// </summary>
        /// <param name="loggerLevel"></param>
        public CommonLogger(CommonLoggerLevel loggerLevel = CommonLoggerLevel.Error)
        {
            //switch (loggerLevel)
            //{
            //    case CommonLoggerLevel.Info:
            //        logger = LogManager.GetLogger("LoggerAppenderInfo");
            //        break;
            //    case CommonLoggerLevel.Error:
            //        logger = LogManager.GetLogger("LoggerAppenderError");
            //        break;
            //    case CommonLoggerLevel.Debug:
            //        logger = LogManager.GetLogger("LoggerAppenderDebug");
            //        break;
            //    default:
            //        logger = LogManager.GetLogger("LoggerAppenderError");
            //        break;
            //}
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">错误异常类</param>
        public void WriteLog(string message, Exception exception = null, CommonLoggerLevel loggerLevel = CommonLoggerLevel.Error, string parameter = null)
        {
            try
            {
                #region 重载parameter参数完善异常日志信息
                message = parameter == null ? message : message + parameter;
                #endregion

                log = GetLogger(loggerLevel);

                switch (loggerLevel)
                {
                    case CommonLoggerLevel.Info:
                        OutputInfoLevel(message, exception);
                        break;
                    case CommonLoggerLevel.Error:
                        OutputErrorLevel(message, exception);
                        break;
                    case CommonLoggerLevel.Debug:
                        OutputDebugLevel(message, exception);
                        break;
                    default:
                        OutputErrorLevel(message, exception);
                        break;
                }
            }
            catch (Exception ex)
            {
                //eat
            }
        }

        #region 私有方法

        private ILog GetLogger(CommonLoggerLevel loggerLevel)
        {
            ILog logger = null;
            switch (loggerLevel)
            {
                case CommonLoggerLevel.Info:
                    logger = LogManager.GetLogger(Startup.Repository.Name, "LoggerAppenderInfo");
                    break;
                case CommonLoggerLevel.Error:
                    logger = LogManager.GetLogger(Startup.Repository.Name, "LoggerAppenderError");
                    break;
                case CommonLoggerLevel.Debug:
                    logger = LogManager.GetLogger(Startup.Repository.Name, "LoggerAppenderDebug");
                    break;
                default:
                    logger = LogManager.GetLogger(Startup.Repository.Name, "LoggerAppenderError");
                    break;
            }
            return logger;
        }

        /// <summary>
        /// 记录Info level的信息
        /// </summary>
        /// <param name="message">记录信息</param>
        /// <param name="exception">异常信息</param>
        private void OutputInfoLevel(string message, Exception exception)
        {
            try
            {
                if (exception == null)
                    log.Info(message);
                else
                    log.Info(message, exception);
            }
            catch (Exception ex)
            {
                //eat
            }
        }

        /// <summary>
        /// 记录Error level的信息
        /// </summary>
        /// <param name="message">记录信息</param>
        /// <param name="exception">异常信息</param>
        private void OutputErrorLevel(string message, Exception exception)
        {
            try
            {
                if (exception == null)
                    log.Error(message);
                else
                    log.Error(message, exception);
            }
            catch (Exception ex)
            {
                //eat
            }
        }

        /// <summary>
        /// 记录Debug level的信息
        /// </summary>
        /// <param name="message">记录信息</param>
        /// <param name="exception">异常信息</param>
        private void OutputDebugLevel(string message, Exception exception)
        {
            try
            {
                if (exception == null)
                    log.Debug(message);
                else
                    log.Debug(message, exception);
            }
            catch (Exception ex)
            {
                //eat
            }
        }

        #endregion
    }
}
