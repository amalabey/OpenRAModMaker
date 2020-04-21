using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.Services
{
	public interface IContentProvider
	{
		SpriteSequence GetSprites(string tileSet, string actorName, string sequenceName);
	}
}
