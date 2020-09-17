using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicioPrueba.Application.Configuration.Service
{
    public interface IKraken
    {
        string CreateMessageKraken<T>(string target, string operation, List<T> data);

        string CreateMessageAgrupadaKraken<T>(List<T> data);

        Task<string> SendKrakenPOST(string message);
    }
}
