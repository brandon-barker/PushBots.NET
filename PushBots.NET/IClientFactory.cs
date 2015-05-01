using System.Net.Http;

namespace PushBots.NET
{
    public interface IClientFactory
    {
        HttpClient GetClient(string appId);
        HttpClient GetClient(string appId, string secret);        
    }
}