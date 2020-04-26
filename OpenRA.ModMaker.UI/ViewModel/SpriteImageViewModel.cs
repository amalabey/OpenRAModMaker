using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class SpriteImageViewModel : BaseViewModel
	{
		private const string DefaultTileSetName = "SNOW";

		private readonly IContentProvider contentProvider;
		private readonly IResourceProvider resourceProvider;
		private readonly IUIContext uiContext;
		private readonly string actorName;
		private readonly string defaultSequenceName;

		public SpriteImageViewModel(IContentProvider contentProvider, IResourceProvider resourceProvider, IUIContext uiContext, string actorName, string defaultSequenceName)
		{
			this.contentProvider = contentProvider;
			this.resourceProvider = resourceProvider;
			this.uiContext = uiContext;
			this.actorName = actorName;
			this.defaultSequenceName = defaultSequenceName;
			ImageSource = resourceProvider.GetImage("loading.png");

			Task.Factory.StartNew(() => LoadSpriteImage());
		}

		public BitmapSource ImageSource { get; set; }

		private void LoadSpriteImage()
		{
			try
			{
				var sequence = contentProvider.GetSpriteSequence(DefaultTileSetName, actorName, (x) => x.FirstOrDefault(y => y == defaultSequenceName) ?? x.FirstOrDefault());
				if (sequence != null && sequence.Sprites != null && sequence.Sprites.Length > 0)
				{
					var spriteImage = sequence.Sprites[0];
					var data = spriteImage.RawData.Value;
					var imageSource = ConvertToBitmapImageSource(data, spriteImage.Width, spriteImage.Height);
					imageSource.Freeze();
					uiContext.BeginInvoke(() =>
					{
						ImageSource = imageSource;
					});
				}
				else
				{
					LoadFailedImage();
				}
			}
			catch (System.Exception)
			{
				LoadFailedImage();
			}
		}

		private void LoadFailedImage()
		{
			uiContext.BeginInvoke(() =>
			{
				var failedIcon = resourceProvider.GetImage("failed.png");
				failedIcon.Freeze();
				ImageSource = failedIcon;
			});
		}

		private BitmapSource ConvertToBitmapImageSource(int[] rawData, int width, int height)
		{
			var stride = 4 * width;
			var bitmapSource = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, rawData, stride);
			return bitmapSource;
		}

	}

}
