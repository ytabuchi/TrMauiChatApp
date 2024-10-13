using MobileApp.Models;

namespace MobileApp.Services;
public class ChatService : IChatService
{
    public List<ChatRoom> GetChatRooms()
    {
        return
        [
            new()  { Name = "General", Description = "General chat room" },
            new() { Name = "Random", Description = "Random chat room" },
            new() { Name = "News", Description = "News chat room" },
            new() { Name = "Tech", Description = "Tech chat room" },
            new() { Name = "Games", Description = "Games chat room" }
        ];
    }
}
