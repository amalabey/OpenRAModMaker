using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Dialogs.TextInput;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNode : BaseViewModel
	{
		protected Node node;
		protected readonly IMediator mediator;
		protected readonly INotifyPropertyChanged ownerViewModel;
		protected readonly IDialogService dialogService;

		public string Name { get; set; }
		public virtual string Image { get; }
		public bool IsExpanded { get; set; }
		public ICommand SelectCommand { get; set; }
		public ObservableCollection<TreeViewNode> Children { get; set; }
		public ObservableCollection<TreeViewNodeProperty> Properties { get; set; }
		public ObservableCollection<NodeAction> ContextActions { get; set; }

		public TreeViewNode(Node node, IMediator mediator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService)
		{
			this.Children = new ObservableCollection<TreeViewNode>();
			this.SelectCommand = new RelayCommand<object>(OnNodeSelection, p => true);
			this.node = node;
			this.mediator = mediator;
			this.Name = node.Name;
			this.ownerViewModel = ownerViewModel;
			this.dialogService = dialogService;

			this.Properties =  new ObservableCollection<TreeViewNodeProperty>(node.Attributes.Select(kvp => new TreeViewNodeProperty
			{
				Name = kvp.Key,
				Value = kvp.Value
			}));
			
			this.ContextActions = GetContextActions();
		}

		protected virtual ObservableCollection<NodeAction> GetContextActions()
		{
			return new ObservableCollection<NodeAction>
			{
				new NodeAction
				{
					Name = ContextActionNames.AddAttribute,
					Command = new RelayCommand<object>(OnAddAttribute, p => true) }
			};
		}

		protected virtual void OnAddAttribute(object parameter)
		{
			var textInputData = new TextInputDialogViewModel
			{
				Title = "Property Name"
			};
			bool? success = dialogService.ShowCustomDialog<TextInputDialog>(ownerViewModel, textInputData);
			if (success == true)
			{
				Properties.Add(new TreeViewNodeProperty
				{
					Name = textInputData.Text,
					Value = ""
				});
				mediator.NotifyAttributeAdded(this);
			}
		}

		protected virtual void OnNodeSelection(object parameter) 
		{
			this.mediator.NotifyNodeSelected((TreeViewNode)parameter);
		}
	}
}
