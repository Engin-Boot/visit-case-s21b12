using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverVisitCount
{
   public class TimeSplit
    {
        public List<string> hourList { get; set; }
        public List<string> minuteList { get; set; }
        public List<string> secondList { get; set; }
        public bool isTimeSplitted { get; set; }

        public TimeSplit(List<string> timeList)
        {
            isTimeSplitted = false;
            this.hourList = new List<string>();
            this.minuteList = new List<string>();
            this.secondList = new List<string>();
            this.TimeSplitIntoHourMinuteSecond(timeList);
            isTimeSplitted = true;
        }
        public bool TimeSplitIntoHourMinuteSecond(List<string> timelist)
        {
            try
            {
                for (int i = 0; i < timelist.Count; i++)
                {
                    string[] date = timelist[i].Split(':');
                    hourList.Add(date[0]);
                    minuteList.Add(date[1]);
                    secondList.Add(date[2]);
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
