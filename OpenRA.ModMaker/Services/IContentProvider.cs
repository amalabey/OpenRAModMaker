using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.Services
{
	public interface IContentProvider
	{
		SpriteSequence GetSpriteSequence(string tileSet, string actorName, string sequenceName);
	}
}
