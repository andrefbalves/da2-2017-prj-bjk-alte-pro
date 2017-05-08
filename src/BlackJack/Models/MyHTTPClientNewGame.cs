using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public static class MyHTTPClientNewGame
    {
        private static string baseAddress = "http://193.137.46.2";
        private static HttpClient client;

        public static HttpClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new
                    MediaTypeWithQualityHeaderValue("application/json"));
                }
                return client;
            }
        }
    }
}
