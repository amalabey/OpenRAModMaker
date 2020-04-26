using System;
using System.Windows.Media.Imaging;

namespace OpenRA.ModMaker.UI.Services
{
	public class WpfPackResourceProvider : IResourceProvider
	{
		public BitmapImage GetImage(string fileName)
		{
			var uri = new Uri($"pack://application:,,,/Images/{fileName}");
			return new BitmapImage(uri);
		}
	}
}
