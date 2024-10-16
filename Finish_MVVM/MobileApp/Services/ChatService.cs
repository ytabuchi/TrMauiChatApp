using System.Text.Json;
using System.Text;
using MobileApp.Models;

namespace MobileApp.Services;
public class ChatService : IChatService
{
    public List<Bot> GetBots()
    {
        return
        [
            new() { Name = "アザラシ", Description = "アザラシ Bot", Icon = "seal.png" },
            new() { Name = "ウシ", Description = "ウシ Bot", Icon = "cow.png"  },
            new() { Name = "オオカミ", Description = "オオカミ Bot", Icon = "wolf.png"  },
            new() { Name = "キツネ", Description = "キツネ Bot", Icon = "fox.png"  },
            new() { Name = "サル", Description = "サル Bot", Icon = "monkey.png"  },
            new() { Name = "ブタ", Description = "ブタ Bot", Icon = "pig.png"  }
        ];
    }

    static readonly HttpClient _httpClient = new HttpClient();
    static readonly string _url = "";
    static readonly string _apiKey = "";
    public async Task<Message> SendRequestAsync(string userMessage, Bot bot)
    {
        var requestBody = new
        {
            messages = new[]
            {
                    new { role = "system", content = $"あなたは動物の{bot.Name}です。あなたの生態や習性は一般的な{bot.Name}と同様です。質問に対する回答は小さな子供でも理解できる言葉づかいで、{bot.Name}になり切って語尾に鳴き声を付けて会話してください。" },
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
                IsUserMessage = false,
                Icon = bot.Icon
            };
            return assistantMessage;
        }
        else
        {
            return new Message
            {
                MessageText = $"Error: {response.StatusCode}",
                IsUserMessage = false,
                Icon = bot.Icon
            };
        }
    }
}
