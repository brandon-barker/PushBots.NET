using System.Net.Http;

namespace PushBots.NET
{
    public interface IClientFactory
    {
        HttpClient GetPushClient(string appId, string secret);
    }
}