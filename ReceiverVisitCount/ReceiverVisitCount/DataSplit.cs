using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverVisitCount
{
    public class DataSplit
    {
        public List<string> dateList { get; set; }
        public List<string> timeList { get; set; }

        public bool isDataSplitted { get; set; }

        public DataSplit(List<string> ReceieveDataList)
        {
            isDataSplitted = false;
            this.dateList = new List<string>();
            this.timeList = new List<string>();
            this.SplitDataIntoDateAndTime(ReceieveDataList);
            isDataSplitted = true;
        }
        public void SplitDataIntoDateAndTime(List<string> ReceieveDataList)
        {
            try
            {
                for (int i = 1; i < ReceieveDataList.Count; i++)
                {
                    string[] dateTime = ReceieveDataList[i].Split(',');
                    dateList.Add(dateTime[0]);
                    timeList.Add(dateTime[1]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Date Cannot be split into Date and Time");
                throw;
            }
        }
    }
}
