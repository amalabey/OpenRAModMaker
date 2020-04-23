using System;

namespace OpenRA.ModMaker.Model
{
	public class SpriteImage
	{
		public SpriteImage(int width, int height, Lazy<int[]> sheetData)
		{
			Width = width;
			Height = height;
			RawData = sheetData;
		}

		public int Width { get; set; }
		public int Height { get; set; }
		public Lazy<int[]> RawData { get; private set; }
	}
}
