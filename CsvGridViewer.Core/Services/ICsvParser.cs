using System.Data;

namespace CsvGridViewer.Core.Services
{
    /// <summary>
    /// Provides CSV parsing operations.
    /// </summary>
    public interface ICsvParser
    {
        DataTable Parse(string csvContent);

        DataTable ParseFromFile(string filePath);
    }
}
