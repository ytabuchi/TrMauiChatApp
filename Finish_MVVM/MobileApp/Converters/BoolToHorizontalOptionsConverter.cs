using System.Globalization;

namespace MobileApp.Converters;

public class BoolToHorizontalOptionsConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isUserMessage)
        {
            return isUserMessage ? LayoutOptions.End : LayoutOptions.Start;
        }
        return LayoutOptions.Start;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
