using System;
using System.Windows;
using System.Windows.Data;
using OpenRA.ModMaker.UI.ViewModel;

namespace OpenRA.ModMaker.UI
{
    [ValueConversion(typeof(TreeViewNode), typeof(Visibility))]
    public class NullToVisibilityConverter : IValueConverter
    {
        public static NullToVisibilityConverter Instance = new NullToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
