using System.Net.Http;
using System.Threading.Tasks;
using PushBots.NET.Models;

namespace PushBots.NET
{
    internal interface IPushBotsClient
    {
        Task<HttpResponseMessage> Push(SinglePush message);
        Task<HttpResponseMessage> Push(BatchPush message);
        Task<HttpResponseMessage> Badge(string token, string platform, int badgecount);
    }
}