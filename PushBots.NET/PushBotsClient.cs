using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushBots.NET.Exceptions;
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
        private readonly string _badgeApiPath = PushBotsServiceConfiguration.Settings.BadgeApiPath;
        private readonly string _analyticsApiPath = PushBotsServiceConfiguration.Settings.AnalyticsApiPath;
        private readonly string _devicesApiPath = PushBotsServiceConfiguration.Settings.DevicesApiPath;

        /// <summary>
        /// Instantiate a PushBotsClient
        /// </summary>
        /// <param name="appId">Your App's Application ID</param>
        /// <param name="secret">Your App's Secret Key</param>
        public PushBotsClient(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;

            _clientFactory = new ClientFactory();
        }

        /// <summary>
        /// Push a notification to a single device
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#PushOne"/>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Push(SinglePush message)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PostAsJsonAsync(_singlePushApiPath, message);
        }

        /// <summary>
        /// Push a notification to Devices under certain conditions
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#batch_push"/>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Push(BatchPush message)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PostAsJsonAsync(_batchPushApiPath, message);
        }

        /// <summary>
        /// Update Device Badge
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#badge" />
        /// <param name="token">Device Token</param>
        /// <param name="platform">Platform ("0" for iOS / "1" for Android - currently only iOS is supported)</param>
        /// <param name="badgecount">Number to increment Badge Count by</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Badge(string token, string platform, int badgecount)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_badgeApiPath, new {token, platform, badgecount});
        }

        /// <summary>
        /// Get Push analytics of a single application
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#getAnalytics"/>
        /// <returns>A JSON Object containing Analytics Data</returns>
        public async Task<JObject> GetPushAnalytics()
        {
            var client = _clientFactory.GetClient(AppId, Secret);            
            var response = await client.GetAsync(_analyticsApiPath);
            var analytics = await response.Content.ReadAsAsync<JObject>();

            return analytics;
        }

        /// <summary>
        /// Get all registered Devices
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Device>> GetDevices()
        {
            var client = _clientFactory.GetClient(AppId, Secret);
            var response = await client.GetAsync(_devicesApiPath);
            var analytics = await response.Content.ReadAsAsync<List<Device>>();

            return analytics;
        }

        /// <summary>
        /// Get all Device info for a specified alias
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public async Task<Device> GetDeviceByAlias(string alias)
        {
            var devices = await GetDevices();
            var device = devices.FirstOrDefault(p => p.Alias == alias);

            if (device != null)
            {
                return device;
            }

            throw new DeviceNotFoundException(String.Format("Could not find a matching device with the supplied alias: {0}", alias));
        }
    }
}
