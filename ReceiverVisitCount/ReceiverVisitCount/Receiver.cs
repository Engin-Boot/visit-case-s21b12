using System;




namespace ReceiverVisitCount
{
    class Receiver
    {
        public static void Main()
        {
            try
            {
                 Receiver receive = new Receiver();
                 var dataReceive = new DataReceive();

                 var receivedDataList = dataReceive.ReceiveData();

                 var splitData = new DataSplit(receivedDataList);
                 var dateList = splitData.DateList;
                 var timeList = splitData.TimeList;
 
                 var splitTime = new TimeSplit(timeList);
                 var hourList = splitTime.HourList;
                 
 
                 var getAggregate = new Aggregator();
 
                 const string date = "1/9/2020";
                 getAggregate.GetAvgPerHourInADay(date, dateList, hourList);
 
                 const string startDate = "1/9/2020";
                 getAggregate.GetAvgDailyFootfallInAWeek(startDate, dateList);
 
                 getAggregate.PeakDailyFooFallInLastMonth(dateList);
            }
            catch(Exception e)
            {
                Console.WriteLine(e + " Functions do not Work");
            }
        }
    }
}
