using MobileApp.ViewModels;

namespace MobileApp.Views;

public partial class ChatPage : ContentPage
{
	public ChatPage(ChatPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}