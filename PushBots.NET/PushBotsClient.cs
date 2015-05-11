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
using PushBots.NET.Enums;
using PushBots.NET.Exceptions;
using PushBots.NET.Models;

namespace PushBots.NET
{
    public class PushBotsClient : IPushBotsClient
    {
        private string AppId { get; set; }
        private string Secret { get; set; }

        private readonly IClientFactory _clientFactory;
        private readonly PushBotsServiceConfiguration _settings = new PushBotsServiceConfiguration();

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

            return await client.PostAsJsonAsync(_settings.SinglePushApiPath, message);
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

            return await client.PostAsJsonAsync(_settings.BatchPushApiPath, message);
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

            return await client.PutAsJsonAsync(_settings.BadgeApiPath, new { token, platform, badgecount });
        }

        /// <summary>
        /// Get Push analytics of a single application
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#getAnalytics"/>
        /// <returns>A JSON Object containing Analytics Data</returns>
        public async Task<JObject> GetPushAnalytics()
        {
            var client = _clientFactory.GetClient(AppId, Secret);
            var response = await client.GetAsync(_settings.AnalyticsApiPath);
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
            var response = await client.GetAsync(_settings.DevicesApiPath);
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

        /// <summary>
        /// Register a Device
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#register"/>
        /// <param name="device"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RegisterDevice(Device device)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.RegisterDeviceApiPath, device);
        }

        /// <summary>
        /// Register multiple Devices (up to 500 per batch request)
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#batchtoken"/>
        /// <param name="tokens"></param>
        /// <param name="platform"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RegisterDevice(string[] tokens, Platform platform, string[] tags)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.RegisterDeviceBatchApiPath, new { tokens, platform, tags });
        }

        /// <summary>
        /// unRegister device token of the app from the database
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#unregister"/>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UnregisterDevice(string token, Platform platform)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.UnregisterDeviceApiPath, new { token, platform });
        }

        /// <summary>
        /// Add/update alias of a device.
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#alias"/>
        /// <param name="platform"></param>
        /// <param name="token"></param>
        /// <param name="alias"></param>
        /// <param name="currentAlias"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> SetAlias(Platform platform, string token, string alias,
            string currentAlias)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.UnregisterDeviceApiPath, new { platform, token, alias, current_alias = currentAlias });
        }

        /// <summary>
        /// Tag a device with its token through SDK or Alias through your backend
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#tag" />
        /// <param name="platform"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> TagDevice(Platform platform, string tag, string token, string alias)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.TagDeviceApiPath, new { platform, tag, token, alias });
        }

        /// <summary>
        /// unTag a device its token through SDK or Alias through your backend
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#deltag" />
        /// <param name="platform"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UntagDevice(Platform platform, string tag, string token, string alias)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.UntagDeviceApiPath, new { platform, tag, token, alias });
        }

        /// <summary>
        /// Add/update location of a device
        /// </summary>
        /// <see cref="https://pushbots.com/developer/api/1#geo" />
        /// <param name="platform"></param>
        /// <param name="token"></param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeviceLocation(Platform platform, string token, string lat, string lng)
        {
            var client = _clientFactory.GetClient(AppId, Secret);

            return await client.PutAsJsonAsync(_settings.DeviceLocationApiPath, new { platform, token, lat, lng });
        }
    }
}
