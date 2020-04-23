using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ImageViewModel : BaseViewModel
	{
		private BitmapSource bitmapSource;

		public ImageViewModel(int[] rawData, int width, int height)
		{
			RawData = rawData;
			Width = width;
			Height = height;
		}

		public int[] RawData { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public BitmapSource ImageSource
		{
			get 
			{
				if (bitmapSource == null)
					bitmapSource = ToBitmapImageSource();

				return bitmapSource;
			}
		}

		//public Bitmap ToBitmap()
		//{
		//	var data = RawData;
		//	var bitmap = new Bitmap(Width, Height);
		//	var imgData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		//	unsafe
		//	{
		//		int* q = (int*)imgData.Scan0.ToPointer();
		//		var stride2 = imgData.Stride >> 2;
		//		for (var i = 0; i < Width; i++)
		//			for (var j = 0; j < Height; j++)
		//			{
		//				q[j * stride2 + i] = data[i + Width * j];
		//			}
		//	}
		//	bitmap.UnlockBits(imgData);
		//	return bitmap;
		//}

		public BitmapSource ToBitmapImageSource()
		{
			var stride = 4 * Width;
			var bitmapSource = BitmapSource.Create(Width, Height, 96, 96, PixelFormats.Bgra32, null, RawData, stride);
			return bitmapSource;
		}
	}
}
