using System.Net.Http;
using System.Threading.Tasks;
using PushBots.NET.Models;

namespace PushBots.NET
{
    internal interface IPushBotsClient
    {
        Task<HttpResponseMessage> PushSingle(SinglePush message);
        Task<HttpResponseMessage> PushBatch(BatchPush message);
    }
}