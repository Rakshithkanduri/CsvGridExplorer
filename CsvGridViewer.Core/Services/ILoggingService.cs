using System;

namespace CsvGridViewer.Core.Services
{
    public interface ILoggingService
    {
        void LogInfo(string message);

        void LogError(string message, Exception? exception = null);
    }
}
