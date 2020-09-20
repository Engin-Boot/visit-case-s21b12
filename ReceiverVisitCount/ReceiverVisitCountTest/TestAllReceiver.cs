using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using ReceiverVisitCount;

namespace ReceiverVisitCountTest
{
    public class TestAllReceiver
    {
        [Fact]
        public void CheckDataWriteToCSVFile()
        {
            WriteTocsvFile csvfileWriter = new WriteTocsvFile();

            string filenameDay = "FootfallDayCsv.csv";
            string filenameWeek = "FootfallWeekCsv.csv";

            Assert.True(csvfileWriter.FootfallDayWeekCsvFileWriter("14/9/2020", (float)0.04166667, filenameDay));
            Assert.True(csvfileWriter.FootfallDayWeekCsvFileWriter("1/9/2020", (float)1.25, filenameWeek));
            Assert.True(csvfileWriter.FootfallLastMonthCsvFileWriter(8, 4));
        }

        [Fact]
        public void CheckTimeSplit()
        {
            List<string> checkTimeList = new List<string> { "10:11:01", "12:03:34", "14:05:04", "18:07:21" };
            TimeSplit splitTime = new TimeSplit(checkTimeList);
            Assert.True(splitTime.isTimeSplitted);
        }

        [Fact]
        public void checkDataSplit()
        {
            List<string> CheckDataList = new List<string> { "Date,Time","1/8/2020,10:00:01","1/9/2020,10:00:01","3/9/2020,10:30:27" };
            DataSplit splitData = new DataSplit(CheckDataList);
            Assert.True(splitData.isDataSplitted);
        }

        [Fact]
        public void CheckDataReceive()
        {
            List<string> checkDataListTrue = new List<string> { "Date,Time", "1/8/2020,10:00:01", "1/9/2020,10:00:01", "3/9/2020,10:30:27" };
            List<string> checkDataListFalse = new List<string> { "cc,dd", "aa,kh", "po,lk", "ph,kl" };
            DataReceive receiveData = new DataReceive();
            List<string>ReceivedDataList = receiveData.ReceiveData();
            Assert.False(checkDataListFalse == ReceivedDataList);
        }

        [Fact]
        public void CheckAggregator()
        {
            Aggregator aggregatorObj = new Aggregator();
            List<string> myhourlist = new List<string> { "10", "10", "10", "10","10","10","11"};
            float countHour = aggregatorObj.countHours(myhourlist);
            Assert.True(countHour == 7);

            string mydate = "1/9/2020";
            List<string> datelist = new List<string> { "1/9/2020", "1/9/2020", "1/9/2020", "1/9/2020", "1/9/2020", "1/9/2020","3/9/2020","2/8/2020","2/8/2020","2/8/2020","2/8/2020","7/9/2020"};
            int countFreq = aggregatorObj.CountDateFreq(mydate, datelist);
            Assert.True(countFreq == 6);

            float checkAvgPerHour = aggregatorObj.getAvgPerHourInADay(mydate, datelist, myhourlist);
            Assert.True(checkAvgPerHour == 1.5F);

            float checkAvgWeek = aggregatorObj.getAvgDailyFootfallInAWeek(mydate, datelist);
            Assert.True(checkAvgWeek == 0.25F);

            float checkPeak = aggregatorObj.peakDailyFoofallInLastMonth(datelist);
            Assert.True(checkPeak == 4);
            
        }
    }
}
