using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace SampleCleanArchitecture.LoggerService
{
    public static class NLogService
    {
        private static bool _isConfigured = false;

        /// <summary>
        /// Configures NLog globally from the embedded or external nlog.config file.
        /// </summary>
        public static void ConfigureNLog(string configPath = "nlog.config")
        {
            if (_isConfigured)
                return;

            LogManager.Setup().LoadConfigurationFromFile(configPath);
            _isConfigured = true;
        }

        /// <summary>
        /// Creates a logger instance for the specified type.
        /// </summary>
        public static ILogger<T> CreateLogger<T>()
        {
            ConfigureNLog(); // ensure configuration is loaded
            var factory = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.AddNLog();
            });
            return factory.CreateLogger<T>();
        }
    }
}
