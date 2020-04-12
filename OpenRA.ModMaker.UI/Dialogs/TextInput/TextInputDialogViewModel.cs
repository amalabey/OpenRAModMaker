using System.Windows.Input;
using MvvmDialogs;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.Dialogs.TextInput
{
    public class TextInputDialogViewModel : BaseViewModel, IModalDialogViewModel
    {
        public TextInputDialogViewModel()
        {
            OkCommand = new RelayCommand<object>(Ok, p => true);
        }

        public string Text { get; set; }
        public ICommand OkCommand { get; }
        public bool? DialogResult { get; set; }

        private void Ok(object parameter)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                DialogResult = true;
            }
        }
    }
}
