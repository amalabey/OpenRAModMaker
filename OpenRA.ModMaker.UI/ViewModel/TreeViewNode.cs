﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Primitives;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNode : BaseViewModel
	{
		protected Node node;
		protected readonly IMediatorContext context;

		public string Name { get; set; }
		public virtual string Image { get; }
		public bool IsExpanded { get; set; }
		public ICommand SelectCommand { get; set; }
		public ObservableCollection<TreeViewNode> Children { get; set; }
		public AttributeDictionary<string, object> Attributes { get; set; }
		public ObservableCollection<NodeAction> ContextActions { get; set; }

		public TreeViewNode(Node node, IMediatorContext context)
		{
			this.Attributes = new AttributeDictionary<string, object>();
			this.Children = new ObservableCollection<TreeViewNode>();
			this.SelectCommand = new RelayCommand<object>(OnNodeSelection, p => true);
			this.node = node;
			this.context = context;
			this.Name = node.Name;

			if (node.Attributes != null)
			{
				foreach (var attrib in node.Attributes)
				{
					this.Attributes.Add(attrib.Key, attrib.Value);
				}
			}

			this.Attributes.SyncTo(this.node.Attributes);
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
			// #todo: add attribute using modal popup
			Attributes.Add("TestAttrib", "testval");
			context.NotifyAttributeAdded(this);
		}

		protected virtual void OnNodeSelection(object parameter) { }
	}
}
