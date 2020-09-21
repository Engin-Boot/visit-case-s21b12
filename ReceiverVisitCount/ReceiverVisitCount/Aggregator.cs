using System;
using System.Collections.Generic;
using System.Linq;


namespace ReceiverVisitCount
{
   public class Aggregator
    {
        public float CountHours(List<string> myHourList)
        {
            var myCountHour = 0;
            for (var i = 0; i < myHourList.Count; i++)
            {
                myCountHour += 1;
            }
            return myCountHour;
        }

        public int CountDateFreq(string myDate,List<string> dateList)
        {
            var countFreq = 0;
            foreach (var data in dateList)
            {
                if (myDate == data)
                    countFreq++;
            }
            return countFreq;
        }
        private float SumOfDateCountFreq(Dictionary<string, float> dateCount)
        {
            var addCount = 0F;

            foreach (var kvp in dateCount)
            {
                addCount += kvp.Value;
            }
            return addCount;
        }
        private int GetPeakInAMonth(Dictionary<string, int> previousMonthDates)
        {
            return previousMonthDates.Keys.Select(key => previousMonthDates[key]).Prepend(0).Max();
        }
        private List<string> GetUniqueDateList(List<string> dateList)
        {
            var uniqueDateList = new List<string>();
            foreach (var i in dateList)
                if (!uniqueDateList.Contains(i))
                    uniqueDateList.Add(i);

            return uniqueDateList;
        }

        public float GetAvgPerHourInADay(string date, List<string> dateList, List<string> hourList)
        {
            var myHourList = new List<string>();

            for (var i = 0; i < hourList.Count; i++)
            {
                if (date == dateList[i])
                    myHourList.Add(hourList[i]);
            }

            var myCountHour = CountHours(myHourList);
            var hourAvgResult = myCountHour / 4;
            Console.WriteLine(hourAvgResult);

            var csvWriter = new WriteToCsvFile();
            const string filename = "FootfallDayCsv.csv";
            csvWriter.FootfallDayWeekCsvFileWriter(date, hourAvgResult,filename);

            return hourAvgResult;
        }
        public float GetAvgDailyFootfallInAWeek(string date,List<string> dateList)
        {

            var dateCount = new Dictionary<string, float>();

           const string format = "d/M/yyyy";
           var convertedDate = DateTime.ParseExact(date, format, null);
            
            var year = convertedDate.Year;
            var month = convertedDate.Month;


            var daysInMonth = DateTime.DaysInMonth(year, month);

            for(var i = 0; i < daysInMonth; i++)
            {
                var nextDate = convertedDate.AddDays(i);
                var day = (int) nextDate.DayOfWeek;

                if(day == 1)
                {
                    var myDate = nextDate.ToString("d/M/yyyy");

                    var countFreq = CountDateFreq(myDate, dateList);
                    dateCount.Add(myDate, countFreq);
                }
            }
            var addCountAvg = SumOfDateCountFreq(dateCount);

            var dailyAvgInAWeek = addCountAvg / dateCount.Count;
            Console.WriteLine(dailyAvgInAWeek);

            var csvWriter = new WriteToCsvFile();
            const string filename = "FootfallWeekCsv.csv";
            csvWriter.FootfallDayWeekCsvFileWriter(date, dailyAvgInAWeek, filename);
            return dailyAvgInAWeek;
        }

        public int PeakDailyFooFallInLastMonth(List<string> dateList)
        {
            var date = DateTime.Now;
            var previousMonth = Convert.ToInt32(date.AddMonths(-1).Month.ToString());
            var previousMonthDates = new Dictionary<string, int>();

            var uniqueDateList = GetUniqueDateList(dateList);

            foreach(var i in uniqueDateList)
            {
                const string format = "d/M/yyyy";
                var convertedDate = DateTime.ParseExact(i, format, null);
                

                var convertedDateMonth = convertedDate.Month;
                if(convertedDateMonth == previousMonth)
                {
                    var myDate = convertedDate.ToString("d/M/yyyy");

                    var countFreq = CountDateFreq(myDate, dateList);
                    previousMonthDates.Add(myDate, countFreq);
                }
            }

            var peak = GetPeakInAMonth(previousMonthDates);
            Console.WriteLine(peak);

            var csvWriter = new WriteToCsvFile();
            csvWriter.FootfallLastMonthCsvFileWriter(previousMonth, peak);
            return peak;
          
        }
     }
 }
