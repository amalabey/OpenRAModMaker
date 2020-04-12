using System.Windows;
using MvvmDialogs;
using OpenRA.ModMaker.UI.Dialogs;
using OpenRA.ModMaker.UI.ViewModel;

namespace OpenRA.ModMaker.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			//var modsPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods";
			//var workingDirectoryPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA";

			var modsPath = "C:\\work\\games\\Yuris-Revenge\\mods";
			var workingDirectoryPath = "C:\\work\\games\\Yuris-Revenge";
			var dialogService = new DialogService(frameworkDialogFactory: new CustomFrameworkDialogFactory());

			//var mod = new Mod(workingDirectoryPath, modsPath, "ra");
			this.DataContext = new ModViewModel(dialogService, workingDirectoryPath, modsPath, "yr");
			//this.DataContext = new ModViewModel(dialogService);
		}
	}
}
