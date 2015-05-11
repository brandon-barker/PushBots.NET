using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PushBots.NET.Exceptions;

namespace PushBots.NET
{
    public class ClientFactory : IClientFactory
    {
        private readonly PushBotsServiceConfiguration _settings = new PushBotsServiceConfiguration();

        public HttpClient GetClient(string appId)
        {
            var client = new HttpClient { BaseAddress = new Uri(_settings.ApiUrl) };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-pushbots-appid", appId);

            return client;
        }

        public HttpClient GetClient(string appId, string secret)
        {
            var client = new HttpClient { BaseAddress = new Uri(_settings.ApiUrl) };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-pushbots-appid", appId);
            client.DefaultRequestHeaders.Add("x-pushbots-secret", secret);

            return client;
        }
    }
}
