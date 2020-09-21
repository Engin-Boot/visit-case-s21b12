using System;
using System.Collections.Generic;


namespace ReceiverVisitCount
{
   public class TimeSplit
    {
        public List<string> HourList { get; set; }
        public List<string> MinuteList { get; set; }
        public List<string> SecondList { get; set; }
        public bool IsTimeSplit { get; set; }

        public TimeSplit(List<string> timeList)
        {
            IsTimeSplit = false;
            HourList = new List<string>();
            MinuteList = new List<string>();
            SecondList = new List<string>();
            TimeSplitIntoHourMinuteSecond(timeList);
            IsTimeSplit = true;
        }
        public bool TimeSplitIntoHourMinuteSecond(List<string> timeList)
        {
            try
            {
                foreach (var i in timeList)
                {
                    var date = i.Split(':');
                    HourList.Add(date[0]);
                    MinuteList.Add(date[1]);
                    SecondList.Add(date[2]);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Data Cannot be split into Time");
                throw;
            }
        }
    }
}
