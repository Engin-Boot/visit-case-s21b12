using System;
using System.Globalization;
using System.IO;
using System.Text;


namespace ReceiverVisitCount
{
    public class WriteToCsvFile
    {
        public bool FootfallDayWeekCsvFileWriter(string date, float aggregateData,string filename)
        {
            try
            {
                var csvOutputFilePath = Directory.GetCurrentDirectory();
                var csvFileName = filename;
                csvOutputFilePath += @"\" + csvFileName;

                const string format = "d/M/yyyy";
                var convertedDate = DateTime.ParseExact(date, format, null);

                var year = convertedDate.Year;
                var month = convertedDate.Month;
                var dateDay = convertedDate.Day;

                var csv = new StringBuilder();
                const string dayHeader = "Day";
                const string monthHeader = "Month";
                const string yearHeader = "Year";
                const string valueHeader = "Aggregated Value";
                var myDay = dateDay.ToString();
                var myMonth = month.ToString();
                var myYear = year.ToString();
                var invC = CultureInfo.InvariantCulture;
                var myValue = aggregateData.ToString(invC);


                var headerLine = string.Format($"{dayHeader}, {monthHeader}, {yearHeader}, {valueHeader}\n");
                csv.Append(headerLine);
                var dataLine = string.Format($"{myDay}, {myMonth}, {myYear}, {myValue}");
                csv.Append(dataLine);

                File.WriteAllText(csvOutputFilePath, csv.ToString());
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e + "Cannot Write To File");
                throw;
            }
        }
        public bool FootfallLastMonthCsvFileWriter(int month, int peakValue)
        {
            try
            {
                var csvOutputFilePath = Directory.GetCurrentDirectory();
                const string csvFileName = "FootfallLastMonthCsv.csv";
                csvOutputFilePath += @"\" + csvFileName;

                var csv = new StringBuilder();

                const string monthHeader = "Month";
                const string valueHeader = "Peak Value";
                var myMonth = month.ToString();
                var myValue = peakValue.ToString();

                var headerLine = string.Format($"{monthHeader}, {valueHeader}\n");
                csv.Append(headerLine);
                var dataLine = string.Format($"{myMonth}, {myValue}");
                csv.Append(dataLine);

                File.WriteAllText(csvOutputFilePath, csv.ToString());
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e + "Cannot Write To File");
                throw;
            }
        }
    }
}
