using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PushBots.NET.Enums;

namespace PushBots.NET.Models
{
    [DataContract]
    public class Device
    {
        [DataMember(Name = "_id")]
        public string Id { get; set; }
        [DataMember(Name = "appID")]
        public string AppId { get; set; }
        [DataMember(Name = "platform")]
        public Platform Platform { get; set; }
        [DataMember(Name = "token")]
        public string Token { get; set; }
        [DataMember(Name = "udid")]
        public string Udid { get; set; }
        [DataMember(Name = "ccode")]
        public string CountryCode { get; set; }
        [DataMember(Name = "tz")]
        public string TimeZone { get; set; }
        [DataMember(Name = "alias")]
        public string Alias { get; set; }
        [DataMember(Name = "badge")]
        public int Badge { get; set; }
        [DataMember(Name = "stats")]
        public int Stats { get; set; }
        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }
        [DataMember(Name = "active")]
        public string[] Types { get; set; }
        [DataMember(Name = "lat")]
        public string Latitude { get; set; }
        [DataMember(Name = "lng")]
        public string Longitude { get; set; }
    }
}
