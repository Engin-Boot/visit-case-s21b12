﻿using System;
using System.IO;

namespace SenderVisitCount
{
    public class ReadingFile
    {

        public string ReadCsv()
        {
            var csvFilePath = Directory.GetCurrentDirectory();
            var csvFileName = "Footfall_DataSet.csv";
            csvFilePath += @"\" + csvFileName;

            try
            {
                var fileDataStreamReader = new StreamReader(csvFilePath);
                var data = fileDataStreamReader.ReadToEnd();
                fileDataStreamReader.Close();
                return data;
            }
            catch (Exception )
            {

                throw new FileNotFoundException("The required file not found");
                


            }
        }
    }
}