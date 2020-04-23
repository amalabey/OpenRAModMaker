using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using OpenRA.ModMaker.UI.ViewModel;

namespace OpenRA.ModMaker.UI
{
	[ValueConversion(typeof(TreeViewNode), typeof(BitmapImage))]
	public class NodeToImageConverter : IValueConverter
	{
		public static NodeToImageConverter Instance = new NodeToImageConverter();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var uri = new Uri($"pack://application:,,,/Images/{value}");
			return new BitmapImage(uri);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
 