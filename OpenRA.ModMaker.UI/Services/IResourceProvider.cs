using System.Windows.Media.Imaging;

namespace OpenRA.ModMaker.UI.Services
{
	public interface IResourceProvider
	{
		BitmapImage GetImage(string fileName);
	}
}
