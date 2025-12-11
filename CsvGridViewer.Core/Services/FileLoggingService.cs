using System;
using System.IO;
using System.Text;

namespace CsvGridViewer.Core.Services
{
    /// <summary>
    /// File-based logger implementation.
    /// </summary>
    public sealed class FileLoggingService : ILoggingService
    {
        private readonly string _logFilePath;

        public FileLoggingService(string logFilePath)
        {
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                throw new ArgumentException("Log file path must be provided.", nameof(logFilePath));
            }

            _logFilePath = logFilePath;
        }

        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogError(string message, Exception? exception = null)
        {
            var fullMessage = exception == null
                ? message
                : $"{message}{Environment.NewLine}{exception}";

            WriteLog("ERROR", fullMessage);
        }

        private void WriteLog(string level, string message)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append('[')
                  .Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                  .Append("] [")
                  .Append(level)
                  .Append("] ")
                  .AppendLine(message);

                var directory = Path.GetDirectoryName(_logFilePath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.AppendAllText(_logFilePath, sb.ToString());
            }
            catch
            {
                // Swallow logging failures to avoid breaking the app.
            }
        }
    }
}
