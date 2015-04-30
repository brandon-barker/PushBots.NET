using System;
using System.Collections.Generic;
using System.Configuration;
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

        private readonly IClientFactory _clientFactory;

        private readonly string _singlePushApiPath = PushBotsServiceConfiguration.Settings.SinglePushApiPath;
        private readonly string _batchPushApiPath = PushBotsServiceConfiguration.Settings.BatchPushApiPath;

        public PushBotsClient(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;

            _clientFactory = new ClientFactory();
        }

        public async Task<HttpResponseMessage> PushSingle(SinglePush message)
        {
            var client = _clientFactory.GetPushClient(AppId, Secret);

            return await client.PostAsJsonAsync(_singlePushApiPath, message);
        }

        public async Task<HttpResponseMessage> PushBatch(BatchPush message)
        {
            var client = _clientFactory.GetPushClient(AppId, Secret);

            return await client.PostAsJsonAsync(_batchPushApiPath, message);
        }
    }
}
