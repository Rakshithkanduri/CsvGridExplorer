using System;
using System.Data;
using System.IO;

namespace CsvGridViewer.Core.Services
{
    /// <summary>
    /// Simple CSV parser with basic validation.
    /// </summary>
    public sealed class CsvParser : ICsvParser
    {
        public DataTable Parse(string csvContent)
        {
            if (string.IsNullOrWhiteSpace(csvContent))
            {
                throw new ArgumentException("CSV content is empty.", nameof(csvContent));
            }

            var table = new DataTable("CsvData");

            using var reader = new StringReader(csvContent);
            string? line;
            int lineNumber = 0;
            int expectedColumnCount = -1;

            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var cells = line.Split(',');

                if (expectedColumnCount < 0)
                {
                    expectedColumnCount = cells.Length;

                    for (int i = 0; i < expectedColumnCount; i++)
                    {
                        table.Columns.Add($"Column{i + 1}", typeof(string));
                    }
                }
                else if (cells.Length != expectedColumnCount)
                {
                    throw new FormatException(
                        $"Row {lineNumber} has {cells.Length} columns but expected {expectedColumnCount}.");
                }

                var row = table.NewRow();
                for (int i = 0; i < expectedColumnCount; i++)
                {
                    row[i] = cells[i].Trim();
                }

                table.Rows.Add(row);
            }

            if (table.Rows.Count == 0)
            {
                throw new FormatException("CSV does not contain any data rows.");
            }

            return table;
        }

        public DataTable ParseFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path must be provided.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("CSV file not found.", filePath);
            }

            var content = File.ReadAllText(filePath);
            return Parse(content);
        }
    }
}
