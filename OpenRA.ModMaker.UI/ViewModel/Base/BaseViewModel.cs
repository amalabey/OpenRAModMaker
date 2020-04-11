using System.ComponentModel;
using PropertyChanged;

namespace OpenRA.ModMaker.UI.ViewModel.Base
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
