using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverVisitCount
{
   public class Aggregator
    {
        public float countHours(List<string> myhourlist)
        {
            var mycounthour = 0;
            for (int i = 0; i < myhourlist.Count; i++)
            {
                mycounthour = mycounthour + 1;
            }
            return mycounthour;
        }

        public int CountDateFreq(string mydate,List<string> datelist)
        {
            int countFreq = 0;
            for(int i=0;i<datelist.Count;i++)
            {
                if (mydate == datelist[i])
                    countFreq++;
            }
            return countFreq;
        }
        public float sumOfDateCountFreq(Dictionary<string, float> dateCount)
        {
            float AddCount = 0F;

            foreach (KeyValuePair<string, float> kvp in dateCount)
            {
                AddCount = AddCount + kvp.Value;
            }
            return AddCount;
        }
        public  int getPeakInAMonth(Dictionary<string, int> previousMonthDates)
        {
            return previousMonthDates.Keys.Select(key => previousMonthDates[key]).Prepend(0).Max();
        }
        public List<string> GetUniqueDateList(List<string> datelist)
        {
            List<string> uniqueDatelist = new List<string>();
            for (int i = 0; i < datelist.Count; i++)
                if (!uniqueDatelist.Contains(datelist[i]))
                    uniqueDatelist.Add(datelist[i]);

            return uniqueDatelist;
        }

        public float getAvgPerHourInADay(string date, List<string> datelist, List<string> hourlist)
        {
            List<string> myhourlist = new List<string>();

            for (int i = 0; i < hourlist.Count; i++)
            {
                if (date == datelist[i])
                    myhourlist.Add(hourlist[i]);
            }

            var mycounthour = countHours(myhourlist);
            var hourAvgResult = mycounthour / 4;
            Console.WriteLine(hourAvgResult);

            WriteTocsvFile csvWriter = new WriteTocsvFile();
            string filename = "FootfallDayCsv.csv";
            csvWriter.FootfallDayWeekCsvFileWriter(date, hourAvgResult,filename);

            return hourAvgResult;
        }
        public float getAvgDailyFootfallInAWeek(string date,List<string> datelist)
        {

            Dictionary<string, float> dateCount = new Dictionary<string, float>();

            string format = "d/M/yyyy";
            DateTime convertedDate = DateTime.ParseExact(date, format, null);
            
            int year = convertedDate.Year;
            int month = convertedDate.Month;
            int startDate = convertedDate.Day;
            

            int daysInMonth = DateTime.DaysInMonth(year, month);

            for(int i = 0; i < daysInMonth; i++)
            {
                DateTime nextDate = convertedDate.AddDays(i);
                int day = (int) nextDate.DayOfWeek;

                if(day == 1)
                {
                    string mydate = nextDate.ToString("d/M/yyyy");

                    var countfreq = CountDateFreq(mydate, datelist);
                    dateCount.Add(mydate, countfreq);
                }
            }
            var AddCountAvg = sumOfDateCountFreq(dateCount);

            var DailyAvgInAWeek = AddCountAvg / dateCount.Count;
            Console.WriteLine(DailyAvgInAWeek);

            WriteTocsvFile csvWriter = new WriteTocsvFile();
            string filename = "FootfallWeekCsv.csv";
            csvWriter.FootfallDayWeekCsvFileWriter(date, DailyAvgInAWeek, filename);
            return DailyAvgInAWeek;
        }

        public int peakDailyFoofallInLastMonth(List<string> datelist)
        {
            var date = DateTime.Now;
            int previousMonth = Convert.ToInt32(date.AddMonths(-1).Month.ToString());
            Dictionary<string, int> previousMonthDates = new Dictionary<string, int>();

            List<string> uniqueDatelist = GetUniqueDateList(datelist);

            for(int i=0; i< uniqueDatelist.Count; i++)
            {
                string format = "d/M/yyyy";
                DateTime convertedDate = DateTime.ParseExact(uniqueDatelist[i], format, null);
                

                int convertedDateMonth = convertedDate.Month;
                if(convertedDateMonth == previousMonth)
                {
                    string mydate = convertedDate.ToString("d/M/yyyy");

                    var countfreq = CountDateFreq(mydate, datelist);
                    previousMonthDates.Add(mydate, countfreq);
                }
            }

            var peak = getPeakInAMonth(previousMonthDates);
            Console.WriteLine(peak);

            WriteTocsvFile csvWriter = new WriteTocsvFile();
            csvWriter.FootfallLastMonthCsvFileWriter(previousMonth, peak);
            return peak;
          
        }
     }
 }

