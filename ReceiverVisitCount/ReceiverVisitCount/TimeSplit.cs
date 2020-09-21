using System;
using System.Collections.Generic;


namespace ReceiverVisitCount
{
   public class TimeSplit
    {
        public List<string> HourList { get; }
        public bool IsTimeSplit { get;}

        public TimeSplit(List<string> timeList)
        {
            IsTimeSplit = false;
            HourList = new List<string>();
            TimeSplitIntoHourMinuteSecond(timeList);
            IsTimeSplit = true;
        }
        private void TimeSplitIntoHourMinuteSecond(List<string> timeList)
        {
            try
            {
                foreach (var i in timeList)
                {
                    var date = i.Split(':');
                    HourList.Add(date[0]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Data Cannot be split into Time");
                throw;
            }
        }
    }
}
