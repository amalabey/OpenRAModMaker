using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ModViewModel : BaseViewModel
	{
		private Mod mod;
		private readonly IDialogService dialogService;
		private readonly Mediator mediator;

		public ManifestTreeViewNode Manifest { get; set; }
		public TreeViewNode SelectedNode { get; set; }
		public ICommand OpenCommand { get; set; }
		public ICommand FindNextCommand { get; set; }
		public ICommand FindPreviousCommand { get; set; }

		public ModViewModel(IDialogService dialogService, string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			this.OpenCommand = new RelayCommand<object>(OpenManifest, p => true);
			this.dialogService = dialogService;
			this.mediator = new Mediator();
			this.mediator.NodeSelected += OnNodeSelected;
			this.mediator.ActorNavigationRequested += OnActorNavigationRequested;

			LoadMod(workingDirectoryPath, modsDirectoryPath, modId);
		}

		public ModViewModel(IDialogService dialogService)
		{
			this.OpenCommand = new RelayCommand<object>(OpenManifest, p => true);
			this.mediator = new Mediator();
			this.dialogService = dialogService;
		}

		private void LoadMod(string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			this.mod = new Mod(workingDirectoryPath, modsDirectoryPath, modId);
			this.Manifest = new ManifestTreeViewNode(null, this.mod.Manifest, this.mediator, this, this.dialogService);
		}

		private void OnActorNavigationRequested(string nodeName)
		{
			var targetActor = this.Manifest.Children
				.FirstOrDefault(x => x.Name == NodeNames.RulesNodeName)
				.Children
				.SelectMany(rset => rset.Children)
				.FirstOrDefault(actor => actor.Name == nodeName);

			if(targetActor != null)
			{
				foreach (var topNode in this.Manifest.Children)
				{
					topNode.IsExpanded = false;
				}
				ExpandToNode(targetActor);
				targetActor.IsSelected = true;
				this.SelectedNode = targetActor;
			}
		}

		private void ExpandToNode(TreeViewNode node)
		{
			if(node != null)
			{
				node.IsExpanded = true;
				ExpandToNode(node.Parent);
			}
		}

		private void LoadMod(string manifestPath)
		{
			var modDirectoryPath = Path.GetDirectoryName(manifestPath);
			var modId = new DirectoryInfo(modDirectoryPath).Name;
			var modsDirectoryPath = Path.GetDirectoryName(modDirectoryPath);
			var workingDirectoryPath = Path.GetDirectoryName(modsDirectoryPath);

			this.LoadMod(workingDirectoryPath, modsDirectoryPath, modId);
		}

		private void OpenManifest(object parameter)
		{
			if (dialogService == null)
				return;

			var settings = new OpenFileDialogSettings
			{
				Title = "Open Mod Manifest",
				InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
				Filter = "Yaml Files (*.yaml)|*.yaml|All Files (*.*)|*.*"
			};
			
			bool? success = dialogService.ShowOpenFileDialog(this, settings);
			if (success == true)
			{
				this.LoadMod(settings.FileName);
			}
		}

		private void OnNodeSelected(TreeViewNode node)
		{
			this.SelectedNode = node;
		}
	}
}
