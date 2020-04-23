using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRA.FileFormats;
using OpenRA.Graphics;
using OpenRA.ModMaker.Model;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var modsPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods";
			var workingDirectoryPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA";

			var mod = new Mod(workingDirectoryPath, modsPath, "ra");

			Assert.IsNotNull(mod.Manifest);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var modSearchPaths = new string[] { "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods" };
			var explicitModPaths = new string[] { "ra" };

			Log.AddChannel("debug", "c:\\temp\\openra.log");
			Log.AddChannel("perf", "c:\\temp\\openra-perf.log");

			var currentDirectory = "C:\\work\\games\\OpenRAModMaker\\OpenRA";
			Environment.CurrentDirectory = currentDirectory;
			Directory.SetCurrentDirectory(currentDirectory);

			Game.Settings = new Settings(Platform.ResolvePath(Path.Combine(Platform.SupportDirPrefix, "settings.yaml")), new Arguments { });

			var mods = new InstalledMods(modSearchPaths, explicitModPaths);
			var raMod = mods["ra"];
			var modData = new ModData(raMod, mods, true);
			var sequences = modData.DefaultSequences;
			var snowSeqProv = sequences["SNOW"];
			var harv = snowSeqProv.GetSequence("harv", "icon");

			int[] ChannelMasks = { 2, 1, 0, 3 };
			var palette = new ImmutablePalette("C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods\\cnc\\bits\\snow.pal", new int[0]);


			//png.Save($"C:\\temp\\harv\\harv-0.png");
			for (int i = 0; i < 50; i++)
			{
				var sprite = harv.GetSprite(i);
				var sheet = sprite.Sheet;
				sheet.AsPng((TextureChannel)ChannelMasks[2], palette).Save($"C:\\temp\\harv\\harv-{i}.png");
			}

		}

		[TestMethod]
		public void TestMethod3()
		{
			var modSearchPaths = new string[] { "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods" };
			var explicitModPaths = new string[] { "ra" };

			Log.AddChannel("debug", "c:\\temp\\openra.log");
			Log.AddChannel("perf", "c:\\temp\\openra-perf.log");

			var currentDirectory = "C:\\work\\games\\OpenRAModMaker\\OpenRA";
			Environment.CurrentDirectory = currentDirectory;
			Directory.SetCurrentDirectory(currentDirectory);
			var palette = new ImmutablePalette("C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods\\cnc\\bits\\snow.pal", new int[0]);
			int[] ChannelMasks = { 2, 1, 0, 3 };
			Game.Settings = new Settings(Platform.ResolvePath(Path.Combine(Platform.SupportDirPrefix, "settings.yaml")), new Arguments { });

			var mods = new InstalledMods(modSearchPaths, explicitModPaths);
			var raMod = mods["ra"];
			var modData = new ModData(raMod, mods, true);
			var defaultSequences = modData.DefaultSequences;
			var sequences = defaultSequences["SNOW"];
			var harv = sequences.GetSequence("harv", "harvest");

			sequences.Preload();
			for (int i = 0; i < harv.Length; i++)
			{
				var sprite = harv.GetSprite(i);
				byte[] spriteBytes = new byte[sprite.Bounds.Width * sprite.Bounds.Height];

				GetSpriteData(sprite, spriteBytes);

				var bitmap = ToBitmap(spriteBytes, sprite.Bounds.Width, sprite.Bounds.Height, palette);
				bitmap.Save("c:\\temp\\harv\\to-bmp.bmp");
				//var png = new Png(pngBytes, sprite.Bounds.Width, sprite.Bounds.Height);
				//var png = ToPng(pngBytes, sprite.Bounds.Width, sprite.Bounds.Height);
				//var png = ToPng(pngBytes, sprite.Bounds.Width, sprite.Bounds.Height, sprite.Channel, palette);
				//png.Save($"c:\\temp\\harv\\from-raw-bytes-{i}.png");
				//Assert.IsNotNull(png);
			}
		}

		public static Bitmap ToBitmap(byte[] data, int width, int height, IPalette palette)
		{
			var bitmap = new Bitmap(width, height);
			var imgData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			unsafe
			{
				int* q = (int*)imgData.Scan0.ToPointer();
				var stride2 = imgData.Stride >> 2;
				for (var i = 0; i < width; i++)
					for (var j = 0; j < height; j++)
					{
						q[j * stride2 + i] = Palette.GetColor(palette, data[i + width * j]).ToArgb();
					}
			}
			bitmap.UnlockBits(imgData);
			return bitmap;
		}

		public static Png ToPng(byte[] data, int width, int height)
		{
			// Convert BGRA to RGBA
			for (var i = 0; i < width * height; i++)
			{
				var temp = data[i * 4];
				data[i * 4] = data[i * 4 + 2];
				data[i * 4 + 2] = temp;
			}

			return new Png(data, width, height);
		}

		public static Png ToPng(byte[] data, int width, int height, TextureChannel channel, IPalette pal)
		{
			var plane = new byte[width * height];
			var dataStride = 4 * width;
			var channelOffset = (int)channel;

			for (var y = 0; y < height; y++)
				for (var x = 0; x < width; x++)
					plane[y * width + x] = data[y * dataStride + channelOffset + 4 * x];

			var palColors = new OpenRA.Primitives.Color[Palette.Size];
			for (var i = 0; i < Palette.Size; i++)
				palColors[i] = pal.GetColor(i);

			return new Png(plane, width, height, palColors);
		}


		static readonly int[] ChannelMasks = { 2, 1, 0, 3 };

		public static void GetSpriteData(Sprite sprite, byte[] destData)
		{
			byte[] src = sprite.Sheet.GetData();
			var width = sprite.Bounds.Width;
			var height = sprite.Bounds.Height;

			if (sprite.Channel == TextureChannel.RGBA)
			{
				var destStride = sprite.Sheet.Size.Width;
				var x = sprite.Bounds.Left;
				var y = sprite.Bounds.Top;

				var k = 0;
				//#todo: convert below to direct access and avoid multiple loops
				for (var j = 0; j < height; j++)
				{
					for (var i = 0; i < width; i++)
					{
						destData[k++] = src[(y + j) * destStride + x + i];
					}
				}
			}
			else
			{
				var srcStride = sprite.Sheet.Size.Width * 4;
				var srcOffset = srcStride * sprite.Bounds.Top + sprite.Bounds.Left * 4 + ChannelMasks[(int)sprite.Channel];
				var srcSkip = srcStride - 4 * width;

				var destOffset = 0;
				for (var j = 0; j < height; j++)
				{
					for (var i = 0; i < width; i++)
					{
						destData[destOffset++] = src[srcOffset];
						srcOffset += 4;
					}

					srcOffset += srcSkip;
				}
			}
		}
	}
}
