using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushBots.NET.Enums;
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
        Task<HttpResponseMessage> RegisterDevice(Device device);
        Task<HttpResponseMessage> RegisterDevice(string[] tokens, Platform platform, string[] tags);
        Task<HttpResponseMessage> UnregisterDevice(string token, Platform platform);
        Task<HttpResponseMessage> SetAlias(Platform platform, string token, string alias,
            string currentAlias);
        Task<HttpResponseMessage> TagDevice(Platform platform, string tag, string token, string alias);
        Task<HttpResponseMessage> UntagDevice(Platform platform, string tag, string token, string alias);
        Task<HttpResponseMessage> DeviceLocation(Platform platform, string token, string lat, string lng);
    }
}