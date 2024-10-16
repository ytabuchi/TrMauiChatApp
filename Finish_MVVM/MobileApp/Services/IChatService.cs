using MobileApp.Models;

namespace MobileApp.Services;
public interface IChatService
{
    List<Bot> GetBots();

    Task<Message> SendRequestAsync(string userMessage, Bot bot);
}
