using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Adapters;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ModViewModel : BaseViewModel
	{
		private readonly Mod mod;
		public ManifestTreeViewNode Manifest { get; set; }

		public ModViewModel(string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			this.mod = new Mod(workingDirectoryPath, modsDirectoryPath, modId);
			this.Manifest = new ManifestTreeViewNode(this.mod.Manifest);
		}
	}
}
