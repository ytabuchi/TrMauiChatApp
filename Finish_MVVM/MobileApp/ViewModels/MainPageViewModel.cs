using System.Collections.ObjectModel;
using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.ViewModels;
public class MainPageViewModel : ViewModelBase
{
    public ObservableCollection<ChatRoom> ChatRooms { get; set; } = new();

    readonly IChatService _chatService;

    public MainPageViewModel(IChatService chatService)
    {
        Title = "Chat Rooms";
        _chatService = chatService;

        GetChatRooms();
    }

    void GetChatRooms()
    {
        ChatRooms.Clear();

        var tempChatRoom = _chatService.GetChatRooms();
        foreach (var chatRoom in tempChatRoom)
        {
            ChatRooms.Add(chatRoom);
        }
    }
}
