using System;
using System.Collections.Generic;


namespace ReceiverVisitCount
{
    public class DataReceive
    {
        public List<string> ReceiveData()
        {
            var receiverDataList = new List<string>();

            try{

                string data;

                while ((data = Console.ReadLine()) != null)
                {
                    receiverDataList.Add(data);
                    
                }
                return receiverDataList;
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
