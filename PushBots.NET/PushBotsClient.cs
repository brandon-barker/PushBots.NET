using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PushBots.NET.Models;

namespace PushBots.NET
{
    public class PushBotsClient : IPushBotsClient
    {
        private string AppId { get; set; }
        private string Secret { get; set; }

        private readonly ClientFactory _clientFactory;

        public PushBotsClient(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;

            _clientFactory = new ClientFactory();
        }

        public async Task PushSingle(SinglePush message)
        {
            var client = _clientFactory.GetPushClient(AppId, Secret);

            var response = await client.PostAsJsonAsync("push/one", message);

            if (response.IsSuccessStatusCode)
            {
            }

            client.Dispose();
        }

        public async Task PushBatch(BatchPush message)
        {
            var client = _clientFactory.GetPushClient(AppId, Secret);

            var response = await client.PostAsJsonAsync("push/all", message);

            if (response.IsSuccessStatusCode)
            {
            }

            client.Dispose();
        }
    }
}
