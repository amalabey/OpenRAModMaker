using System;
using System.Collections.Generic;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeNavigator : BaseViewModel, ITreeNavigator
	{
		private KeyValuePair<string, IList<TreeViewNode>> foundNodes;
		private int foundNodeIndex;

		public TreeViewNode Root { get; set; }
		public TreeViewNode SelectedNode { get; set; }

		public TreeNavigator(TreeViewNode root)
		{
			Root = root;
		}

		public void FindNext(string keyword)
		{
			if (String.IsNullOrEmpty(keyword))
				return;

			if (this.foundNodes.Key != keyword)
			{
				FindNodesByKeyword(keyword);
				this.foundNodeIndex = 0;
			}
			else if (foundNodeIndex < this.foundNodes.Value.Count - 1)
			{
				foundNodeIndex++;
			}
			else if (foundNodeIndex == this.foundNodes.Value.Count - 1)
			{
				return;
			}

			if (this.foundNodes.Value.Count > 0)
			{
				var node = this.foundNodes.Value[this.foundNodeIndex];
				ExpandToNode(node);
				node.IsSelected = true;
				this.SelectedNode = node;
			}
		}

		private void ExpandToNode(TreeViewNode node)
		{
			if (node != null)
			{
				node.IsExpanded = true;
				ExpandToNode(node.Parent);
			}
		}

		public void FindPrevious(string keyword)
		{
			if (String.IsNullOrEmpty(keyword))
				return;

			if (this.foundNodes.Key != keyword)
			{
				FindNodesByKeyword(keyword);
				this.foundNodeIndex = 0;
			}
			else if (foundNodeIndex > 0)
			{
				foundNodeIndex--;
			}
			else if (foundNodeIndex == 0)
			{
				return;
			}

			if (this.foundNodes.Value.Count > 0)
			{
				var node = this.foundNodes.Value[this.foundNodeIndex];
				ExpandToNode(node);
				node.IsSelected = true;
				this.SelectedNode = node;
			}
		}

		private void FindNodesByKeyword(string keyword)
		{
			var foundNodes = new List<TreeViewNode>();
			var nodeQueue = new Queue<TreeViewNode>();
			nodeQueue.Enqueue(this.Root);
			while (nodeQueue.Count > 0)
			{
				var node = nodeQueue.Dequeue();
				foreach (TreeViewNode child in node.Children)
				{
					nodeQueue.Enqueue(child);
				}

				if (node.Matches(keyword))
				{
					foundNodes.Add(node);
				}
			}

			this.foundNodes = new KeyValuePair<string, IList<TreeViewNode>>(keyword, foundNodes);
		}
	}
}
