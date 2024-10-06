
using System.Collections.ObjectModel;

namespace TrMauiChatApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Message> Messages { get; set; } = new ();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadHistory();
    }

    void LoadHistory()
    {
        Messages.Clear();

        Messages.Add(new Message { MessageText = "Hello", TimeStamp = DateTime.Now.ToString("HH:mm:ss") , IsUserMessage = true});
        Messages.Add(new Message { MessageText = "Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello ", TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = false });
        Messages.Add(new Message { MessageText = "Hello", TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = true });
        Messages.Add(new Message { MessageText = "Hello", TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = false });
        Messages.Add(new Message { MessageText = "Hello", TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = true });

        BindingContext = Messages;
    }

    void OnSendClicked(object sender, EventArgs e)
    {
        Messages.Add(new Message { MessageText = MessageEntry.Text, TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = true });
        Messages.Add(new Message { MessageText = MessageEntry.Text, TimeStamp = DateTime.Now.ToString("HH:mm:ss"), IsUserMessage = false });
        MessageEntry.Text = string.Empty;
    }
}

