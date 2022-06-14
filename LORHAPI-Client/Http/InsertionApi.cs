using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LORHAPI_Client.Http
{
    public class InsertionApi
    {
        public HttpClient Initial()
        {
            var handler = new HttpClientHandler() // accepte tout les certificat à remove par la suite
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://162.19.64.76:5100");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
