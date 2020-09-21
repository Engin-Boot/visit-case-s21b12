using System.IO;
using Xunit;

namespace SenderVisitCount.Test
{
    public class SenderUnitTest
    {
        private static string  ReturnCsvPath(string file)
        {
            var path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            return path;
        }

        [Fact]
        public void IfFileExists()
        {
            var path = ReturnCsvPath("Footfall_DataSet.csv");
            var sender = new ReadingFile();
            if (File.Exists(path))
                Assert.True(File.Exists(path));

            var destinationTemp = Directory.GetCurrentDirectory() + "\\Temp folder" + @"\" + "Footfall_DataSet.csv";
            File.Copy(path, destinationTemp, true);
            File.Delete(path);

            var ex = Assert.Throws<FileNotFoundException>(() => sender.ReadCsv());
            Assert.Equal("The required file not found", ex.Message);

            File.Copy(destinationTemp, path, true);
            File.Delete(destinationTemp);
        }

        [Fact]
        public void CheckIfDataIsCorrectFormat()
        {
            var sender = new ReadingFile();
            var data = sender.ReadCsv();
            var stringInCorrectFormat = data.StartsWith("Date,Time");
            Assert.True(stringInCorrectFormat);

        }

    }
}