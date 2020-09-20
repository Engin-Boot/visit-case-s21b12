using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverVisitCount
{
    public class Receiver
    {
        static void Main(string[] args)
        {
            try
            {

                List<string> ReceivedDataList = new List<string>();
                DataReceive datareceive = new DataReceive();

                ReceivedDataList = datareceive.ReceiveData();

                DataSplit splitdata = new DataSplit(ReceivedDataList);
                List<string> dateList = splitdata.dateList;
                List<string> timeList = splitdata.timeList;

                TimeSplit splittime = new TimeSplit(timeList);
                List<string> hourList = splittime.hourList;
                List<string> minuteList = splittime.minuteList;
                List<string> secondList = splittime.secondList;

                Aggregator getAggregate = new Aggregator();

                string date = "1/9/2020";
                var perHourAvgInADay = getAggregate.getAvgPerHourInADay(date, dateList, hourList);

                string startdate = "1/9/2020";
                var avgFootfallInAWeek = getAggregate.getAvgDailyFootfallInAWeek(startdate, dateList);

                var peakFootfallLastMonth = getAggregate.peakDailyFoofallInLastMonth(dateList);
            }
            catch(Exception e)
            {
                Console.WriteLine(e + "Fuctions do not Work");
            }
        }
    }
}
