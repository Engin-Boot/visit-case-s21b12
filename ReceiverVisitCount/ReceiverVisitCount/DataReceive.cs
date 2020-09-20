using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverVisitCount
{
    public class DataReceive
    {
        public List<string> ReceiveData()
        {
            List<string> ReceiverDataList = new List<string>();
            
           // var reader = new StreamReader(File.OpenRead("C:/Users/deeks/OneDrive/Desktop/Footfall_Dataset.csv")); //extra

            try
           {
                /*while (!reader.EndOfStream)   //extra
                {
                    var line = reader.ReadLine();
                    ReceiverDataList.Add(line);
                }*/

                string data;

                while ((data = Console.ReadLine()) != null)
                {
                    ReceiverDataList.Add(data);
                }
                return ReceiverDataList;
               //return ReceiverDataList;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
