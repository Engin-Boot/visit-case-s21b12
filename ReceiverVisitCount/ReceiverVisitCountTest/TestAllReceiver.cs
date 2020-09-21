using System.Collections.Generic;
using Xunit;
using ReceiverVisitCount;

namespace ReceiverVisitCountTest
{
    public class TestAllReceiver
    {
        [Fact]
        public void CheckDataWriteToCsvFile()
        {
             var csvFileWriter = new WriteToCsvFile();

             string filenameDay = "FootfallDayCsv.csv";
             string filenameWeek = "FootfallWeekCsv.csv";

            Assert.True(csvFileWriter.FootfallDayWeekCsvFileWriter("1/9/2020", (float)1.5, filenameDay));
            Assert.True(csvFileWriter.FootfallDayWeekCsvFileWriter("1/9/2020", (float)1.75, filenameWeek));
            Assert.True(csvFileWriter.FootfallLastMonthCsvFileWriter(8, 4));
        }

        [Fact]
        public void CheckTimeSplit()
        {
            var checkTimeList = new List<string> { "10:11:01", "12:03:34", "14:05:04", "18:07:21" };
            var splitTime = new TimeSplit(checkTimeList);
            Assert.True(splitTime.IsTimeSplit);
        }

        [Fact]
        public void CheckDataSplit()
        {
            var checkDataList = new List<string> { "Date,Time","1/8/2020,10:00:01","1/9/2020,10:00:01","3/9/2020,10:30:27" };
            var splitData = new DataSplit(checkDataList);
            Assert.True(splitData.IsDataSplit);
        }

        /*[Fact]
        public void CheckDataReceive()
        {
            //List<string> checkDataListTrue = new List<string> { "Date,Time", "1/8/2020,10:00:01", "1/9/2020,10:00:01", "3/9/2020,10:30:27" };
            var checkDataListFalse = new List<string> { "cc,dd", "aa,kh", "po,lk", "ph,kl" };
            var receiveData = new DataReceive();
            var receivedDataList = receiveData.ReceiveData();
            Assert.False(checkDataListFalse == receivedDataList);
        }*/

        [Fact]
        public void CheckAggregator()
        {
            var aggregatorObj = new Aggregator();
            var myHourList = new List<string> { "10", "10", "10", "10","10","10","11"};
            var countHour = aggregatorObj.CountHours(myHourList);
            Assert.True(countHour < 8);

            const string myDate = "1/9/2020";
            var dateList = new List<string> { "1/9/2020", "1/9/2020", "1/9/2020", "1/9/2020", "1/9/2020", "1/9/2020","3/9/2020","2/8/2020","2/8/2020","2/8/2020","2/8/2020","7/9/2020"};
            var countFreq = aggregatorObj.CountDateFreq(myDate, dateList);
            Assert.True(countFreq == 6);

            var checkAvgPerHour = aggregatorObj.GetAvgPerHourInADay(myDate, dateList, myHourList);
            Assert.True(checkAvgPerHour < 2.5F);

            var checkAvgWeek = aggregatorObj.GetAvgDailyFootfallInAWeek(myDate, dateList);
            Assert.True(checkAvgWeek < 1.25F);

            var checkPeak = aggregatorObj.PeakDailyFooFallInLastMonth(dateList);
            Assert.True(checkPeak < 6);
            
        }
    }
}
