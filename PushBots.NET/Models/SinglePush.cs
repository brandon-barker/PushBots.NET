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
    public class SinglePush
    {
        [DataMember(Name = "platform")]
        public Platform Platform { get; set; }
        [DataMember(Name = "token")]
        public string Token { get; set; }
        [DataMember(Name = "msg")]
        public string Message { get; set; }
        [DataMember(Name = "sound")]
        public string Sound { get; set; }
        [DataMember(Name = "badge")]
        public string Badge { get; set; }
        [DataMember(Name = "payload")]
        public JObject Payload { get; set; }
    }
}
