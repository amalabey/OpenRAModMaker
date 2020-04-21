namespace OpenRA.ModMaker.Model
{
	public class SpriteSequence
	{
		public SpriteSequence(string actorName, string sequenceName, SpriteImage[] sprites)
		{
			ActorName = actorName;
			SequenceName = sequenceName;
			Sprites = sprites;
		}

		public string ActorName { get; private set; }
		public string SequenceName { get; private set; }
		public SpriteImage[] Sprites { get; private set; }
	}
}
