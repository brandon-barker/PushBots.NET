using System.Threading.Tasks;
using PushBots.NET.Models;

namespace PushBots.NET
{
    internal interface IPushBotsClient
    {
        Task PushSingle(SinglePush message);
        Task PushBatch(BatchPush message);
    }
}