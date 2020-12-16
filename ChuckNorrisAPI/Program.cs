using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ChuckNorrisAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitString = "";

            do
            {
                NorrisQuote();

                Console.WriteLine();
                Console.WriteLine("Type 'exit' to quit, type anything to continue");

                exitString = Console.ReadLine();

            } while (exitString.ToLower() != "exit");
            
        }

        public static void NorrisQuote()
        {
            var norrisURL = "https://api.chucknorris.io/jokes/random";

            var client = new HttpClient();

            var norrisResponse = client.GetStringAsync(norrisURL).Result;

            var norrisQuote = JObject.Parse(norrisResponse).GetValue("value").ToString();

            Console.WriteLine($"{norrisQuote}");
        }
    }
}
