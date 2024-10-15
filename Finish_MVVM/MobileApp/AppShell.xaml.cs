using MobileApp.Views;

namespace MobileApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
    }
}
