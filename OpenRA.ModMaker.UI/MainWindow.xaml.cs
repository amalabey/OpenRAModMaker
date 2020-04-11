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
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Adapters;
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
			 
			var modsPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods";
			var workingDirectoryPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA";

			var mod = new Mod(workingDirectoryPath, modsPath, "ra");
			this.DataContext = new ManifestTreeViewNode(mod.Manifest);

			this.Variables["Test"] = false;
			this.Variables["Test2"] = 200;
			this.Variables["Test.With.Dots"] = 200.5;
			this.Variables["Test2WithoutDots"] = "help";

			//this.PropertyGrid.SelectedObject = new DictionaryPropertyGridAdapter<string, object>(this.Variables);
		}

		public IDictionary<string, object> Variables { get; set; } = new ConcurrentDictionary<string, object>();

		private void Save_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
