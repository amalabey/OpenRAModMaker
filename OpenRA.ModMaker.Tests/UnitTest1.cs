using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var modsPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods";
			var workingDirectoryPath = "C:\\work\\games\\OpenRAModMaker\\OpenRA";

			var mod = new Mod(workingDirectoryPath, modsPath, "ra");

			Assert.IsNotNull(mod.Manifest);
		}
	}
}
