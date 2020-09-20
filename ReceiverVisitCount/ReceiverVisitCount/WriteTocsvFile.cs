using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ReceiverVisitCount
{
    public class WriteTocsvFile
    {
        public bool FootfallDayWeekCsvFileWriter(string date, float aggregateData,string filename)
        {
            try
            {
                string csvOutputFilePath = Directory.GetCurrentDirectory();
                string csvFileName = filename;
                csvOutputFilePath += @"\" + csvFileName;

                string format = "d/M/yyyy";
                DateTime convertedDate = DateTime.ParseExact(date, format, null);

                int year = convertedDate.Year;
                int month = convertedDate.Month;
                int dateDay = convertedDate.Day;

                var csv = new StringBuilder();
                var dayHeader = "Day";
                var monthHeader = "Month";
                var yearHeader = "Year";
                var valueHeader = "Aggregated Value";
                var myDay = dateDay.ToString();
                var myMonth = month.ToString();
                var myYear = year.ToString();
                var myValue = aggregateData.ToString();


                var headerLine = string.Format("{0},{1},{2},{3}\n", dayHeader, monthHeader, yearHeader, valueHeader, Environment.NewLine);
                csv.Append(headerLine);
                var dataLine = string.Format("{0},{1},{2},{3}", myDay, myMonth, myYear, myValue, Environment.NewLine);
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
                string csvOutputFilePath = Directory.GetCurrentDirectory();
                string csvFileName = "FootfallLastMonthCsv.csv";
                csvOutputFilePath += @"\" + csvFileName;

                var csv = new StringBuilder();

                var monthHeader = "Month";
                var valueHeader = "Peak Value";
                var myMonth = month.ToString();
                var myValue = peakValue.ToString();

                var headerLine = string.Format("{0},{1}\n", monthHeader, valueHeader, Environment.NewLine);
                csv.Append(headerLine);
                var dataLine = string.Format("{0},{1}", myMonth, myValue, Environment.NewLine);
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
