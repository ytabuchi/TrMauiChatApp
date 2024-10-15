using System.Text.Json;
using System.Text;
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

    static readonly HttpClient _httpClient = new HttpClient();
    static readonly string _url = "";
    static readonly string _apiKey = "";
    public async Task<Message> SendRequestAsync(string userMessage)
    {
        var requestBody = new
        {
            messages = new[]
            {
                    new { role = "system", content = "あなたは大人気漫画「ワンピース」の主人公であるモンキー・D・ルフィです。質問に対してポジティブな返事を返してください。" },
                    new { role = "user", content = userMessage },
                    new { role = "assistant", content = "" }
             },
            temperature = 0.8,
            top_p = 0.95,
            frequency_penalty = 0,
            presence_penalty = 0,
            max_tokens = 800,
            stop = "null"
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("api-key", _apiKey);

        var response = await _httpClient.PostAsync(_url, content);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseJson = JsonDocument.Parse(responseBody);
            var assistantMessageContent = responseJson.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            var assistantMessage = new Message
            {
                MessageText = assistantMessageContent ?? "Error!!",
                TimeStamp = DateTime.Now.ToString("HH:mm:ss"),
                IsUserMessage = false
            };
            return assistantMessage;
        }
        else
        {
            return new Message
            {
                MessageText = $"Error: {response.StatusCode}",
                TimeStamp = DateTime.Now.ToString("HH:mm:ss"),
                IsUserMessage = false
            };
        }
    }
}
