using System.Text.Json;
using System.Text;
using MobileApp.Services;
using System.Collections.ObjectModel;
using MobileApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileApp.ViewModels;

[QueryProperty(nameof(Bot), "Bot")]
public partial class ChatPageViewModel : ViewModelBase
{
    public ObservableCollection<Message> ChatMessages { get; set; } = [];

    readonly IChatService _chatService;

    [ObservableProperty]
    Bot _bot;

    [ObservableProperty]
    bool _canSend = true;

    [ObservableProperty]
    bool _isRefreshing;

    [ObservableProperty]
    string _messageEntry = string.Empty;

    public ChatPageViewModel(IChatService chatService)
    {
        _chatService = chatService;
    }

    partial void OnBotChanged(Bot? oldValue, Bot newValue)
    {
        InitializeChat(newValue.Icon);
    }

    [RelayCommand]
    void RefreshClicked()
    {
        InitializeChat(Bot.Icon);
    }

    void InitializeChat(string botIcon)
    {
        CanSend = false;

        ChatMessages.Clear();
        ChatMessages.Add(new Message { MessageText = "質問を入力してください", IsUserMessage = false, Icon = botIcon });

        CanSend = true;
        IsRefreshing = false;
    }

    [RelayCommand(CanExecute = nameof(CanSend))]
    async Task SendClicked()
    {
        CanSend = false;

        await Task.Delay(1000);

        var userMessage = new Message { MessageText = MessageEntry, IsUserMessage = true };
        ChatMessages.Add(userMessage);
        MessageEntry = string.Empty;

        var responseMessage = await _chatService.SendRequestAsync(userMessage.MessageText, Bot);
        ChatMessages.Add(responseMessage);

        CanSend = true;
        IsRefreshing = false;
    }
}
