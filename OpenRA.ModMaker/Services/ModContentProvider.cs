using System;
using System.Collections.Generic;
using System.IO;
using OpenRA.Graphics;
using OpenRA.ModMaker.Exceptions;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.Services
{
	public class ModContentProvider : IContentProvider
	{
		private int[] ChannelMasks = { 2, 1, 0, 3 };
		private readonly string modsDirectoryPath;
		private readonly string workingDirectoryPath;
		private readonly string modId;
		private readonly string palettePath;
		private ModData modData;
		private IPalette palette;

		public ModContentProvider(string modsDirectoryPath, string workingDirectoryPath, string modId, string palettePath)
		{
			this.modsDirectoryPath = modsDirectoryPath;
			this.workingDirectoryPath = workingDirectoryPath;
			this.modId = modId;
			this.palettePath = palettePath;

			Initialize();
		}

		private void Initialize()
		{
			var tempPath = Path.GetTempPath();
			Log.AddChannel("debug", $"{tempPath}\\openra.log");
			Log.AddChannel("perf", $"{tempPath}\\openra-perf.log");

			Environment.CurrentDirectory = workingDirectoryPath;
			palette = new ImmutablePalette(palettePath, new int[0]);
			Game.Settings = new Settings(Platform.ResolvePath(Path.Combine(Platform.SupportDirPrefix, "settings.yaml")), new Arguments { });

			var mods = new InstalledMods(new string[] { modsDirectoryPath }, new string[] { modId });
			var mod = mods[modId];
			modData = new ModData(mod, mods, true);
		}

		public SpriteSequence GetSpriteSequence(string tileSet, string actorName, Func<IEnumerable<string>, string> sequenceSelector)
		{
			if (modData == null)
				throw new ModLoaderException("ModData is not loaded");

			var defaultSequences = modData.DefaultSequences;
			var sequences = defaultSequences[tileSet];
			var unitSequences = sequences.Sequences(actorName);
			var sequenceName = sequenceSelector(unitSequences);

			return GetSpriteSequence(tileSet, actorName, sequenceName);
		}

		public SpriteSequence GetSpriteSequence(string tileSet, string actorName, string sequenceName)
		{
			if (modData == null)
				throw new ModLoaderException("ModData is not loaded");

			var defaultSequences = modData.DefaultSequences;
			var sequences = defaultSequences[tileSet];
			var sequence = sequences.GetSequence(actorName, sequenceName);

			//sequences.Preload();
			var spriteImages = new SpriteImage[sequence.Length];
			for (int i = 0; i < sequence.Length; i++)
			{
				var sprite = sequence.GetSprite(i);
				spriteImages[i] = new SpriteImage(sprite.Bounds.Width, sprite.Bounds.Height, new Lazy<int[]>(() => GetImageData(sprite, palette)));
			}

			return new SpriteSequence(actorName, sequenceName, spriteImages);
		}

		private int[] GetImageData(Sprite sprite, IPalette palette)
		{
			int[] destData = new int[sprite.Bounds.Width * sprite.Bounds.Height];
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
						destData[k++] = Palette.GetColor(palette, src[(y + j) * destStride + x + i]).ToArgb();
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
						destData[destOffset++] = Palette.GetColor(palette, src[srcOffset]).ToArgb();
						srcOffset += 4;
					}

					srcOffset += srcSkip;
				}
			}

			return destData;
		}
	}
}
