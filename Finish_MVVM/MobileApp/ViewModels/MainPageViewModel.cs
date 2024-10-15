using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;

namespace MobileApp.ViewModels;
public partial class MainPageViewModel : ViewModelBase
{
    public ObservableCollection<ChatRoom> ChatRooms { get; set; } = [];

    readonly IChatService _chatService;

    [ObservableProperty]
    ChatRoom _selectedChatRoom;

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

    [RelayCommand]
    async Task ChatRoomSelected()
    {
        if (SelectedChatRoom is null)
            return;

        await Shell.Current.GoToAsync(nameof(ChatPage), true);
    }
}
