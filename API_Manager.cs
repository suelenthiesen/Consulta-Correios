using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Threading;
using System.Numerics;

namespace RastreioAPI
{
    public class Eventos
    {
        public string status { get; set; }
        public string local { get; set; }

        public string destino { get; set; }

        public string data { get; set; }

    }
    public class API_Manager
    {
        public string codigo { get; set; }
        public string host { get; set; }
        
        public string subStatus { get; set; }

        public IEnumerable<Eventos> eventos { get; set; }
        public void Run(string cod)
        {
            try
            {

                var client = new RestClient("https://api.linketrack.com/track/json?user=teste&token=1abcd00b2731640e886fb41a8a9671ad1434c599dbaa0a0de9a5aa619f29a83f&codigo=" + cod);
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
               // Console.WriteLine(response.Content);
                if (response.Content == "Unauthorized")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Favor verificar codigo de rastreio.");
                    Console.ResetColor();
                }
                else
                {
                    API_Manager RastAPI =
                    JsonSerializer.Deserialize<API_Manager>(response.Content);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Codigo de rastreio: " + RastAPI.codigo);
                    Console.ResetColor();

                    foreach (var i in RastAPI.eventos)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(i.data);
                        Console.WriteLine(i.status);
                        Console.WriteLine(i.local);
                      
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }


        }

    }
}
