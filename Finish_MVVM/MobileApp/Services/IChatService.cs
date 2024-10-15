using MobileApp.Models;

namespace MobileApp.Services;
public interface IChatService
{
    List<ChatRoom> GetChatRooms();

    Task<Message> SendRequestAsync(string userMessage);
}
