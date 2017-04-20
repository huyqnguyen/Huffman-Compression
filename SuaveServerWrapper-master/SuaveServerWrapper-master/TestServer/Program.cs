using SuaveServerWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    class Program
    {
        private static HttpHost _server;
        static void Main(string[] args)
        {
            _server = new HttpHost(8000);
            Test().Wait();
            Console.Read();
        }

        static async Task Test()
        {
            await _server.OpenAsync(request =>
            {
                return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(request.RequestUri.Query)});
            });
        }
    }
}
