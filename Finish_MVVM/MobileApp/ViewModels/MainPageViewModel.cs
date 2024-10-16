using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;

namespace MobileApp.ViewModels;
public partial class MainPageViewModel : ViewModelBase
{
    public ObservableCollection<Bot> Bots { get; set; } = [];

    readonly IChatService _chatService;

    [ObservableProperty]
    Bot _selectedBot;

    public MainPageViewModel(IChatService chatService)
    {
        Title = "Chat Rooms";
        _chatService = chatService;

        GetBots();
    }

    void GetBots()
    {
        Bots.Clear();

        var tempChatRoom = _chatService.GetBots();
        foreach (var chatRoom in tempChatRoom)
        {
            Bots.Add(chatRoom);
        }
    }

    [RelayCommand]
    async Task BotSelected()
    {
        if (SelectedBot is null)
            return;

        await Shell.Current.GoToAsync(nameof(ChatPage), true, new Dictionary<string, object>
        {
            { "Bot", SelectedBot }
        });
    }
}
