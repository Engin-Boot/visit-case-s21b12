//ReSharper disable all
using System;

namespace SenderVisitCount
{
    public class Sender
    {
        public static void Main()
        {
            
            var csvData = new ReadingFile().ReadCsv();
            Console.WriteLine(csvData);
        }
    }
}
//ReSharper restore all
