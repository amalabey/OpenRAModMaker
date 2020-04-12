using System.Windows;
using System.Windows.Controls;
using MvvmDialogs;

namespace OpenRA.ModMaker.UI.Dialogs.TextInput
{
    public class TextInputDialog : IWindow
	{
        private readonly TextInputDialogWindow dialog;

        public TextInputDialog()
        {
            dialog = new TextInputDialogWindow();
        }

        object IWindow.DataContext
        {
            get => dialog.DataContext;
            set => dialog.DataContext = value;
        }

        bool? IWindow.DialogResult
        {
            get => dialog.DialogResult;
            set => dialog.DialogResult = value;
        }

        ContentControl IWindow.Owner
        {
            get => dialog.Owner;
            set => dialog.Owner = (Window)value;
        }

        bool? IWindow.ShowDialog()
        {
            return dialog.ShowDialog();
        }

        void IWindow.Show()
        {
            dialog.Show();
        }
    }
}
