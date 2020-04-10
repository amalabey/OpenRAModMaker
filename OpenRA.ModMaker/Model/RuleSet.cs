using System;

namespace OpenRA.ModMaker.Model
{
	public class RuleSet : Node, IEditable
	{
		public RuleSet(string path)
		{
			Path = path;
		}

		public override NodeType NodeType
		{
			get
			{
				return NodeType.RuleSet;
			}
		}

		public bool IsDirty => throw new NotImplementedException();

		public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Load()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}
