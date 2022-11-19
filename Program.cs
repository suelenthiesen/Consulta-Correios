using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RastreioAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.linketrack.com/track/json?user=teste&token=1abcd00b2731640e886fb41a8a9671ad1434c599dbaa0a0de9a5aa619f29a83f&codigo=NA636495843BR");
            var request = new RestRequest("", Method.Get) ;
            var response = client.Execute(request);
            Console.WriteLine(response.Content);

            string jsonString = JsonSerializer.Serialize(response.Content);

            Console.WriteLine(response.Content);
                

            Console.ReadKey();
        }
    }
}
