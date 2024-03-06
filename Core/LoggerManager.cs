using NLog;

namespace Core
{
    public static class LoggerManager
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static void LogInfo(string message)
        {
            Logger.Info(message);
        }

        public static void LogError(string message)
        {
            Logger.Error(message);
        }
    }
}