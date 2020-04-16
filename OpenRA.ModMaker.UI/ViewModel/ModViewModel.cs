using System;
using System.Linq;
using System.IO;
using System.Reflection;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ModViewModel : BaseViewModel
	{
		private Mod mod;
		private IDialogService dialogService;
		private string findKeyword;

		public ITreeNavigator Navigator { get; set; }
		public ManifestTreeViewNode Manifest { get; set; }
		public string FindKeyword { 
			get
			{
				return findKeyword; 
			}
			set
			{
				findKeyword = value;
				this.FindNextCommand.RaiseCanExecuteChanged(this, null);
				this.FindPreviousCommand.RaiseCanExecuteChanged(this, null);
			}
		}

		public RelayCommand<object> OpenCommand { get; set; }
		public RelayCommand<object> FindNextCommand { get; set; }
		public RelayCommand<object> FindPreviousCommand { get; set; }

		public ModViewModel(IDialogService dialogService, string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			Initialize(dialogService);
			LoadMod(workingDirectoryPath, modsDirectoryPath, modId);
		}

		public ModViewModel(IDialogService dialogService)
		{
			Initialize(dialogService);
		}

		private void Initialize(IDialogService dialogService)
		{
			this.dialogService = dialogService;

			this.OpenCommand = new RelayCommand<object>(OpenManifest, p => true);
			this.FindNextCommand = new RelayCommand<object>((_) => this.Navigator.FindNext(this.FindKeyword), p => !String.IsNullOrEmpty(this.FindKeyword));
			this.FindPreviousCommand = new RelayCommand<object>((_) => this.Navigator.FindPrevious(this.FindKeyword), p => !String.IsNullOrEmpty(this.FindKeyword));
			
			this.Navigator = new TreeNavigator(this.Manifest);
		}
		
		private void LoadMod(string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			this.mod = new Mod(workingDirectoryPath, modsDirectoryPath, modId);
			this.Manifest = new ManifestTreeViewNode(null, this.mod.Manifest, this.Navigator, this, this.dialogService);
			this.Navigator.Root = this.Manifest;
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
	}
}
