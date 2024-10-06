namespace TrMauiChatApp;
public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is bool isUserMessage)
        {
            return isUserMessage ? Colors.LightBlue : Colors.LightGray;
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}