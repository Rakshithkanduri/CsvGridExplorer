using System;
using System.IO;
using CsvGridViewer.Core.Services;
using Xunit;

namespace CsvGridViewer.Core.Tests
{
    public class FileLoggingServiceTests
    {
        [Fact]
        public void LogError_WritesToFile()
        {
            string tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempFolder);

            string logPath = Path.Combine(tempFolder, "test.log");
            var logger = new FileLoggingService(logPath);

            logger.LogError("Test error message.");

            Assert.True(File.Exists(logPath));
            string content = File.ReadAllText(logPath);
            Assert.Contains("Test error message.", content);
        }

        [Fact]
        public void Constructor_EmptyPath_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FileLoggingService(string.Empty));
        }
    }
}
