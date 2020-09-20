using System;

namespace SenderVisitCount
{
    class Sender
    {
        public static void Main()
        {
            
            string csvData = new ReadingFile().ReadCsv();
            Console.WriteLine(csvData);
        }
    }
}