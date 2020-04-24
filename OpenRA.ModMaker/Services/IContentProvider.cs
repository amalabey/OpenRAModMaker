using System;
using System.Collections.Generic;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.Services
{
	public interface IContentProvider
	{
		SpriteSequence GetSpriteSequence(string tileSet, string actorName, string sequenceName);
		SpriteSequence GetSpriteSequence(string tileSet, string actorName, Func<IEnumerable<string>, string> sequenceSelector);
	}
}
