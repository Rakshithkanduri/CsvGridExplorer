using System;
using System.Data;
using System.IO;
using CsvGridViewer.Core.Services;
using Xunit;

namespace CsvGridViewer.Core.Tests
{
    public class CsvParserTests
    {
        [Fact]
        public void Parse_ValidCsv_ReturnsExpectedDataTable()
        {
            string csv =
                "1,2,3" + Environment.NewLine +
                "4,5,6" + Environment.NewLine +
                "7,8,9";
            var parser = new CsvParser();

            DataTable table = parser.Parse(csv);

            Assert.Equal(3, table.Columns.Count);
            Assert.Equal(3, table.Rows.Count);
            Assert.Equal("1", table.Rows[0][0]);
            Assert.Equal("6", table.Rows[1][2]);
        }

        [Fact]
        public void Parse_EmptyCsv_ThrowsArgumentException()
        {
            string csv = string.Empty;
            var parser = new CsvParser();

            Assert.Throws<ArgumentException>(() => parser.Parse(csv));
        }

        [Fact]
        public void ParseFromFile_MissingFile_ThrowsFileNotFoundException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".csv");
            var parser = new CsvParser();

            Assert.Throws<FileNotFoundException>(() => parser.ParseFromFile(path));
        }

        [Fact]
        public void Parse_InvalidRowLength_ThrowsFormatException()
        {
            string csv =
                "1,2,3" + Environment.NewLine +
                "4,5" + Environment.NewLine +
                "7,8,9";
            var parser = new CsvParser();

            Assert.Throws<FormatException>(() => parser.Parse(csv));
        }
    }
}
