using log4net;
using System;

namespace SEDC.Lamazon.Services
{
    public class BaseService
    {
        private readonly ILog _logger;
        public BaseService()
        {
            _logger = LogManager.GetLogger(ToString());
        }

        public void LogDebug(string message, Exception? ex = null)
        {
            if (ex == null)
            {
                _logger?.Debug(message);
            }
            else
            {
                _logger?.Debug(message, ex);
            }
        }
        public void LogInfo(string message, Exception? ex = null)
        {
            if (ex == null)
            {
                _logger?.Info(message);
            }
            else
            {
                _logger?.Info(message, ex);
            }
        }
        public void LogWarn(string message, Exception? ex = null)
        {
            if (ex == null)
            {
                _logger?.Warn(message);
            }
            else
            {
                _logger?.Warn(message, ex);
            }
        }
        public void LogError(string message, Exception? ex = null)
        {
            if (ex == null)
            {
                _logger?.Error(message);
            }
            else
            {
                _logger?.Error(message, ex);
            }
        }
    }
}
