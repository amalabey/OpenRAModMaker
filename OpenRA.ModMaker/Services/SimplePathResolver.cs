using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenRA.ModMaker.Services
{
	public class SimplePathResolver : IPathResolver
	{
		private readonly OpenRA.ModMaker.Model.Manifest manifest;
		private readonly string modsDirectoryPath;
		private readonly string workingDirectoryPath;

		public SimplePathResolver(OpenRA.ModMaker.Model.Manifest manifest, 
			string modsDirectoryPath, 
			string workingDirectoryPath)
		{
			this.manifest = manifest;
			this.modsDirectoryPath = modsDirectoryPath;
			this.workingDirectoryPath = workingDirectoryPath;
		}

		public string ResolvePath(string tokenizedPath)
		{
			// # todo: revisit to make this code more reliable
			var tokenIndex = tokenizedPath.IndexOf("|");
			if (tokenIndex <= 0)
				return tokenizedPath;

			var token = tokenizedPath.Substring(0, tokenIndex);
			var packageKey = this.manifest
				.Children
				.FirstOrDefault(x => x.Name == Constants.PackagesNodeName)
				.Attributes
				.FirstOrDefault(kv => kv.Value == token).Key;

			if (string.IsNullOrEmpty(packageKey))
				throw new KeyNotFoundException($"Token: {token} not found in the registered packages in the manifest");

			if(packageKey.StartsWith("$"))
			{
				// E.g. "$ra: ra"
				var modFolder = packageKey.Replace("$", "");
				return Path.Combine(modsDirectoryPath, modFolder, tokenizedPath.Substring(tokenIndex + 1, tokenizedPath.Length - tokenIndex - 1));
			}else if(packageKey.StartsWith("."))
			{
				// E.g. "./mods/common: common"
				var targetFolder = packageKey.Replace(".", "");
				return Path.Combine(workingDirectoryPath, targetFolder, tokenizedPath.Substring(tokenIndex + 1, tokenizedPath.Length - tokenIndex));
			}else
			{
				return Path.Combine(packageKey, tokenizedPath.Substring(tokenIndex + 1, tokenizedPath.Length - tokenIndex));
			}
		}
	}
}
