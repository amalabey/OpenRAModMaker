using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Dialogs.TextInput;
using OpenRA.ModMaker.UI.ViewModel.Base;
using System.Collections.Specialized;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNode : BaseViewModel
	{
		protected Node node;
		protected readonly IMediator mediator;
		protected readonly INotifyPropertyChanged ownerViewModel;
		protected readonly IDialogService dialogService;
		
		public TreeViewNode Parent { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string Link { get; set; }
		public bool Linked
		{
			get
			{
				return Link == null;
			}
		}
		public virtual string Image { get; }
		public bool IsExpanded { get; set; }
		public ObservableCollection<TreeViewNode> Children { get; set; }
		public ObservableCollection<TreeViewNodeProperty> Properties { get; set; }
		public ObservableCollection<NodeAction> ContextActions { get; set; }
		
		public ICommand SelectCommand { get; set; }
		public ICommand LinkCommand { get; set; }
		
		public TreeViewNode(TreeViewNode parent, Node node, IMediator mediator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService)
		{
			this.Children = new ObservableCollection<TreeViewNode>();
			this.SelectCommand = new RelayCommand<object>(OnNodeSelection, p => true);
			this.LinkCommand = new RelayCommand<object>(OnLinkClicked, p => true);
			this.node = node;
			this.mediator = mediator;
			this.Parent = parent;
			this.Name = node.Name;
			this.Value = node.Value;
			
			this.ownerViewModel = ownerViewModel;
			this.dialogService = dialogService;

			this.Properties = new ObservableCollection<TreeViewNodeProperty>(node.Attributes.Select(kvp => new TreeViewNodeProperty(this.node, kvp.Key, kvp.Value)));
			this.Properties.CollectionChanged += OnPropertiesCollectionChanged;
			
			this.ContextActions = GetContextActions();
		}

		protected virtual void OnLinkClicked(object parameter)
		{
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
				Properties.Add(new TreeViewNodeProperty(this.node, textInputData.Text, string.Empty));
				mediator.NotifyAttributeAdded(this);
			}
		}

		protected virtual void OnNodeSelection(object parameter) 
		{
			this.mediator.NotifyNodeSelected((TreeViewNode)parameter);
		}

		protected virtual void OnPropertiesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.NewItems != null)
			{
				foreach (TreeViewNodeProperty newItem in e.NewItems)
				{
					if(!this.node.Attributes.ContainsKey(newItem.Name))
						this.node.Attributes.Add(newItem.Name, newItem.Value);
				}
			}

			if(e.OldItems != null)
			{
				foreach (TreeViewNodeProperty removedItem in e.OldItems)
				{
					if(this.node.Attributes.ContainsKey(removedItem.Name))
						this.node.Attributes.Remove(removedItem.Name);
				}
			}
		}
	}
}
