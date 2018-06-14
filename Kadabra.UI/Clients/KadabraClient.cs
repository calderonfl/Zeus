using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Kadabra.UI.Clients
{
    public class KadabraClient : HttpClient
    {
        private readonly string uriBase = "http://localhost/Kadabra.Api/";
        public KadabraClient()
        {
            BaseAddress = new Uri(uriBase);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Timeout = new TimeSpan(0, 0, 1, 0, 0);
        }
    }
}