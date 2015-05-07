using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushBots.NET.Models;

namespace PushBots.NET
{
    internal interface IPushBotsClient
    {
        Task<HttpResponseMessage> Push(SinglePush message);
        Task<HttpResponseMessage> Push(BatchPush message);
        Task<HttpResponseMessage> Badge(string token, string platform, int badgecount);
        Task<JObject> GetPushAnalytics();
        Task<IEnumerable<Device>> GetDevices();
        Task<Device> GetDeviceByAlias(string alias);
    }
}