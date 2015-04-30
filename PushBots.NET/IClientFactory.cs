using System.Net.Http;

namespace PushBots.NET
{
    public interface IClientFactory
    {
        HttpClient GetClient(string appId, string secret);
        HttpClient GetPushClient(string appId, string secret);        
    }
}