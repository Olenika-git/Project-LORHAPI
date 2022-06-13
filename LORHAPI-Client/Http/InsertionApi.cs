using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LORHAPI_Client.Http
{
    public class InsertionApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://162.19.64.76:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
