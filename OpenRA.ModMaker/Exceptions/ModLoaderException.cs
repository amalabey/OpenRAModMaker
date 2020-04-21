using System;

namespace OpenRA.ModMaker.Exceptions
{
	public class ModLoaderException : Exception
	{
		public ModLoaderException(string message) : base(message)
		{
		}

		public ModLoaderException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
