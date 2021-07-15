using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

using System.Xml;



namespace testapi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program coma = new Program();
            
            Console.WriteLine(coma.GetDataFromServer(10, 10));

            Console.ReadLine();
        }

        public int GetDataFromServer(int a, int b)
        {
            var client = new RestClient("http://demo.macroscop.com:8080/command?type=gettime&login=root&password=");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            

            string dateInput = response.Content;
            dateInput = dateInput.Remove(0, 49);
            



            var parsedfrom = DateTime.ParseExact(dateInput.Remove(19), "G", null);

            var periodfrom = parsedfrom.AddSeconds(-15);
            var periodTo = parsedfrom.AddSeconds(15);
            // для времени UTC
            //var periodNow = DateTime.Now.ToUniversalTime();

            //для локального времени
            var periodNow = DateTime.Now;
            Console.WriteLine(DateTime.Now.ToUniversalTime());
            
            if (periodNow > periodfrom && periodNow < periodTo)
            {
                Console.WriteLine("true");
                return a + b;
            }


            else
            {
                Console.WriteLine("false");
                return 1;
            }
            
        }
    }
}
