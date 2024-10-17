using MobileApp.Models;

namespace MobileApp.Services;

class MockChatService : IChatService
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

    public Task<Message> SendRequestAsync(string userMessage, Bot bot)
    {
        return Task.FromResult(new Message { MessageText = userMessage, IsUserMessage = false, Icon = bot.Icon });
    }
}
