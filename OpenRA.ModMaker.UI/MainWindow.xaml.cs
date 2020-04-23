using System.Windows;
using System.Windows.Controls;
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

			var colorPalettePath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods\\cnc\\bits\\snow.pal";
			var dialogService = new DialogService(frameworkDialogFactory: new CustomFrameworkDialogFactory());

			//var modsPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods";
			//var workingDirectoryPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA";
			//var modId = "ra";

			var modsPath = "C:\\work\\games\\Yuris-Revenge\\mods";
			var workingDirectoryPath = "C:\\work\\games\\Yuris-Revenge";
			var modId = "yr";

			this.DataContext = new ModViewModel(dialogService, workingDirectoryPath, modsPath, modId, colorPalettePath);
		}

		private void ModDefinitionTreeView_Expanded(object sender, RoutedEventArgs e)
		{
			if(e.OriginalSource != null)
			{
				(e.OriginalSource as TreeViewItem).BringIntoView();
			}
		}
	}
}
