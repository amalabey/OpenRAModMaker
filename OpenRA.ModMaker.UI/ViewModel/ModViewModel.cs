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

		public ModViewModel(IDialogService dialogService, string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			this.OpenCommand = new RelayCommand<object>(OpenManifest, p => true);
			this.dialogService = dialogService;
			this.mediator = new Mediator();
			this.mediator.NodeSelected += OnNodeSelected;

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
			this.Manifest = new ManifestTreeViewNode(this.mod.Manifest, this.mediator, this, this.dialogService);
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
