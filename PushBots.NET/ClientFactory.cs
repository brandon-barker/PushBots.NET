using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PushBots.NET
{
    public class ClientFactory : IClientFactory
    {
        private const string ApiUrl = "https://api.pushbots.com/";

        public HttpClient GetPushClient(string appId, string secret)
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiUrl) };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-pushbots-appid", appId);
            client.DefaultRequestHeaders.Add("x-pushbots-secret", secret);

            return client;
        }
    }
}
