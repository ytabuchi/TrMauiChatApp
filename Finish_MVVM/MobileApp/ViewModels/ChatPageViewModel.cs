using System.Text.Json;
using System.Text;
using MobileApp.Services;
using System.Collections.ObjectModel;
using MobileApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileApp.ViewModels;

public partial class ChatPageViewModel : ViewModelBase
{
    public ObservableCollection<Message> ChatMessages { get; set; } = [];

    readonly IChatService _chatService;

    [ObservableProperty]
    bool _canSend = true;

    [ObservableProperty]
    bool _isRefreshing;

    [ObservableProperty]
    string _messageEntry = string.Empty;

    public ChatPageViewModel(IChatService chatService)
    {
        Title = "Chat Page";
        _chatService = chatService;

        InitializeChat();
    }

    [RelayCommand]
    void InitializeChat()
    {
        ChatMessages.Clear();
        ChatMessages.Add(new Message { MessageText = "質問を入力してください", TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = false });
        IsRefreshing = false;
    }

    [RelayCommand(CanExecute = nameof(CanSend))]
    async Task SendClicked()
    {
        CanSend = false;

        await Task.Delay(1000);

        var userMessage = new Message { MessageText = MessageEntry, TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = true };
        ChatMessages.Add(userMessage);
        MessageEntry = string.Empty;

        var responseMessage = await _chatService.SendRequestAsync(userMessage.MessageText);
        ChatMessages.Add(responseMessage);

        CanSend = true;
        IsRefreshing = false;
    }
}
