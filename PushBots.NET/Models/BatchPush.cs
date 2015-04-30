using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushBots.NET.Enums;

namespace PushBots.NET.Models
{
    [DataContract]
    public class BatchPush
    {
        [DataMember(Name = "platform")]
        public Platform[] Platforms { get; set; }
        [DataMember(Name = "msg")]
        public string Message { get; set; }
        [DataMember(Name = "sound")]
        public string Sound { get; set; }
        [DataMember(Name = "badge")]
        public string Badge { get; set; }
        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }
        [DataMember(Name = "except_tags")]
        public string[] ExceptTags { get; set; }
        [DataMember(Name = "active")]
        public string[] Types { get; set; }
        [DataMember(Name = "except_active")]
        public string[] ExceptTypes { get; set; }
        [DataMember(Name = "alias")]
        public string Alias { get; set; }
        [DataMember(Name = "except_alias")]
        public string ExceptAlias { get; set; }
        [DataMember(Name = "payload")]
        public JObject Payload { get; set; }
    }
}
