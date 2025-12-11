using System;
using System.IO;
using System.Windows.Forms;
using CsvGridViewer.Core.Services;

namespace CsvGridViewer.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string logFilePath = Path.Combine(desktopPath, "CsvGridViewer.log");

            ILoggingService logger = new FileLoggingService(logFilePath);
            ICsvParser csvParser = new CsvParser();

            Application.ThreadException += (sender, args) =>
            {
                logger.LogError("Unhandled UI exception.", args.Exception);
                MessageBox.Show(
                    "An unexpected error occurred. Please check the log file on your Desktop.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (args.ExceptionObject is Exception ex)
                {
                    logger.LogError("Unhandled non-UI exception.", ex);
                }
            };

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Application.Run(new MainForm(csvParser, logger, baseDirectory));
        }
    }
}
