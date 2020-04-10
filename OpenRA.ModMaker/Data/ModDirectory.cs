using System;
using System.IO;
using OpenRA.FileSystem;

namespace OpenRA.ModMaker.Data
{
	public class ModDirectory : IModFileStore
	{
		public Manifest ReadManifest(string path, string modId)
		{
			IReadOnlyPackage package;
			try
			{
				if (!Directory.Exists(path))
				{
					Log.Write("debug", path + " is not a valid mod package");
					return null;
				}

				package = new Folder(path);
				if (package.Contains("mod.yaml"))
					return new Manifest(modId, package);
			}
			catch (Exception e)
			{
				Log.Write("debug", "Load mod '{0}': {1}".F(path, e));
				throw e;
			}

			if (package != null)
				package.Dispose();

			return null;
		}
	}
}
