﻿using System;
using System.Collections.Generic;


namespace ReceiverVisitCount
{
    public class DataSplit
    {
        public List<string> DateList { get; set; }
        public List<string> TimeList { get; set; }

        public bool IsDataSplit { get; set; }

        public DataSplit(List<string> receiveDataList)
        {
            IsDataSplit = false;
            DateList = new List<string>();
            TimeList = new List<string>();
            SplitDataIntoDateAndTime(receiveDataList);
            IsDataSplit = true;
        }

        public void SplitDataIntoDateAndTime(List<string> receiveDataList)
        {
            try 
            {
                for (var i = 1; i < receiveDataList.Count-1; i++)
                {

                  var dateTime = receiveDataList[i].Split(',');

                  DateList.Add(dateTime[0]);
                  TimeList.Add(dateTime[1]);

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

