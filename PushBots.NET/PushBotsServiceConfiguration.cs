using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBots.NET
{
    public class PushBotsServiceConfiguration : ConfigurationSection
    {
        // ReSharper disable once InconsistentNaming
        private static readonly PushBotsServiceConfiguration _settings = ConfigurationManager.GetSection("PushBotsServiceSettings") as PushBotsServiceConfiguration;

        public static PushBotsServiceConfiguration Settings
        {
            get
            {
                return _settings;
            }
        }

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
    }
}
