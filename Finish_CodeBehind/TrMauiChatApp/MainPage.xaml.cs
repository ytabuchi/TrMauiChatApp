
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;


namespace TrMauiChatApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Message> ChatMessages { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitializeChat();
    }

    void InitializeChat()
    {
        ChatMessages.Clear();
        ChatMessages.Add(new Message { MessageText = "質問を入力してください", IsUserMessage = false });
        BindingContext = ChatMessages;
    }

    async void OnSendClicked(object sender, EventArgs e)
    {
        MessageEntry.IsEnabled = false;
        SendButton.IsEnabled = false;

        var userMessage = new Message { MessageText = MessageEntry.Text, IsUserMessage = true };
        ChatMessages.Add(userMessage);
        MessageEntry.Text = string.Empty;

        var responseMessage = await SendRequestAsync(userMessage.MessageText);
        ChatMessages.Add(responseMessage);

        MessageEntry.IsEnabled = true;
        SendButton.IsEnabled = true;
    }

    async void PullToRefreshing(object sender, EventArgs e)
    {
        MessageEntry.IsEnabled = false;
        SendButton.IsEnabled = false;

        await Task.Delay(1000);
        InitializeChat();
        ChatRefreshView.IsRefreshing = false;

        MessageEntry.IsEnabled = true;
        SendButton.IsEnabled = true;
    }

    //static readonly HttpClient _httpClient = new HttpClient();
    //static readonly string _url = "";
    //static readonly string _apiKey = "";
    //async Task<Message> SendRequestAsync(string userMessage)
    //{
    //    var requestBody = new
    //    {
    //        messages = new[]
    //        {
    //                new { role = "system", content = "あなたは.NETのマスコットキャラクターである.NET Bot君です。.NET MAUIに関することを教えてください。" },
    //                new { role = "user", content = userMessage },
    //                new { role = "assistant", content = "" }
    //            },
    //        temperature = 0.8,
    //        top_p = 0.95,
    //        frequency_penalty = 0,
    //        presence_penalty = 0,
    //        max_tokens = 800,
    //        stop = "null"
    //    };

    //    var json = JsonSerializer.Serialize(requestBody);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");
    //    _httpClient.DefaultRequestHeaders.Clear();
    //    _httpClient.DefaultRequestHeaders.Add("api-key", _apiKey);

    //    var response = await _httpClient.PostAsync(_url, content);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var responseBody = await response.Content.ReadAsStringAsync();
    //        var responseJson = JsonDocument.Parse(responseBody);
    //        var assistantMessageContent = responseJson.RootElement
    //            .GetProperty("choices")[0]
    //            .GetProperty("message")
    //            .GetProperty("content")
    //            .GetString();

    //        var assistantMessage = new Message
    //        {
    //            MessageText = assistantMessageContent ?? "Error!!",
    //            IsUserMessage = false
    //        };
    //        return assistantMessage;
    //    }
    //    else
    //    {
    //        return new Message
    //        {
    //            MessageText = $"Error: {response.StatusCode}",
    //            IsUserMessage = false
    //        };
    //    }
    //}

    async Task<Message> SendRequestAsync(string userMessage)
    {
        return new Message
        {
            MessageText = userMessage,
            IsUserMessage = false
        };
    }
}

