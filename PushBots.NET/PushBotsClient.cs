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
        private const string ApiUrl = "https://api.pushbots.com/";

        private string AppId { get; set; }
        private string Secret { get; set; }

        public PushBotsClient(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;
        }

        public async Task PushSingle(SinglePush message)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-pushbots-appid", AppId);
                client.DefaultRequestHeaders.Add("x-pushbots-secret", Secret);
                
                var response = await client.PostAsJsonAsync("push/one", message);                

                if (response.IsSuccessStatusCode)
                {
                    var pushUri = response.Headers.Location;                    
                }
            }
        }

        public async Task PushBatch(BatchPush message)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-pushbots-appid", AppId);
                client.DefaultRequestHeaders.Add("x-pushbots-secret", Secret);

                var response = await client.PostAsJsonAsync("push/all", message);

                if (response.IsSuccessStatusCode)
                {
                    var pushUri = response.Headers.Location;
                }
            }
        }
    }
}
