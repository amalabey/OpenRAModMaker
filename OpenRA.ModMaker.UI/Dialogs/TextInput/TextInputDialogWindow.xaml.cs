using System.Windows;
using System.Windows.Input;

namespace OpenRA.ModMaker.UI.Dialogs.TextInput
{
	/// <summary>
	/// Interaction logic for TextInputDialogWindow.xaml
	/// </summary>
	public partial class TextInputDialogWindow : Window
	{
		public TextInputDialogWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
				Close();
		}
	}
}
