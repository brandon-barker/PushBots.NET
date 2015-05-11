using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PushBots.NET.Exceptions;

namespace PushBots.NET
{
    public class PushBotsServiceConfiguration : ConfigurationSection
    {
        public PushBotsServiceConfiguration()
        {
            try
            {
                Settings = ConfigurationManager.GetSection("PushBotsServiceSettings") as PushBotsServiceConfiguration;
            }
            catch (NullReferenceException ex)
            {
                throw new SettingsConfigNotFoundException("Could not find PushBotsServiceSettings configSection", ex);
            }            
        }

        public PushBotsServiceConfiguration Settings { get; private set; }

        [ConfigurationProperty("apiUrl", DefaultValue = "https://api.pushbots.com/")]
        public string ApiUrl
        {
            get { return (string)this["apiUrl"]; }
            set { this["apiUrl"] = value; }
        }

        [ConfigurationProperty("singlePushApiPath", DefaultValue = "push/one")]
        public string SinglePushApiPath
        {
            get { return (string)this["singlePushApiPath"]; }
            set { this["singlePushApiPath"] = value; }
        }

        [ConfigurationProperty("batchPushApiPath", DefaultValue = "push/all")]
        public string BatchPushApiPath
        {
            get { return (string)this["batchPushApiPath"]; }
            set { this["batchPushApiPath"] = value; }
        }

        [ConfigurationProperty("badgeApiPath", DefaultValue = "badge")]
        public string BadgeApiPath
        {
            get { return (string)this["badgeApiPath"]; }
            set { this["badgeApiPath"] = value; }
        }

        [ConfigurationProperty("analyticsApiPath", DefaultValue = "analytics")]
        public string AnalyticsApiPath
        {
            get { return (string)this["analyticsApiPath"]; }
            set { this["analyticsApiPath"] = value; }
        }

        [ConfigurationProperty("devicesApiPath", DefaultValue = "devices")]
        public string DevicesApiPath
        {
            get { return (string)this["devicesApiPath"]; }
            set { this["devicesApiPath"] = value; }
        }

        [ConfigurationProperty("registerDeviceApiPath", DefaultValue = "deviceToken")]
        public string RegisterDeviceApiPath
        {
            get { return (string)this["registerDeviceApiPath"]; }
            set { this["registerDeviceApiPath"] = value; }
        }

        [ConfigurationProperty("registerDeviceBatchApiPath", DefaultValue = "deviceToken/batch")]
        public string RegisterDeviceBatchApiPath
        {
            get { return (string)this["registerDeviceBatchApiPath"]; }
            set { this["registerDeviceBatchApiPath"] = value; }
        }

        [ConfigurationProperty("unregisterDeviceApiPath", DefaultValue = "deviceToken/del")]
        public string UnregisterDeviceApiPath
        {
            get { return (string)this["unregisterDeviceApiPath"]; }
            set { this["unregisterDeviceApiPath"] = value; }
        }

        [ConfigurationProperty("tagDeviceApiPath", DefaultValue = "tag")]
        public string TagDeviceApiPath
        {
            get { return (string)this["tagDeviceApiPath"]; }
            set { this["tagDeviceApiPath"] = value; }
        }

        [ConfigurationProperty("untagDeviceApiPath", DefaultValue = "tag/del")]
        public string UntagDeviceApiPath
        {
            get { return (string)this["untagDeviceApiPath"]; }
            set { this["untagDeviceApiPath"] = value; }
        }

        [ConfigurationProperty("deviceLocationApiPath", DefaultValue = "geo")]
        public string DeviceLocationApiPath
        {
            get { return (string)this["deviceLocationApiPath"]; }
            set { this["deviceLocationApiPath"] = value; }
        }
    }
}
