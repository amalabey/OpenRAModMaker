using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Adapters;
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
			this.DataContext = new ModViewModel(workingDirectoryPath, modsPath, "yr");
			//this.DataContext = new ModViewModel(dialogService);
		}
	}
}
