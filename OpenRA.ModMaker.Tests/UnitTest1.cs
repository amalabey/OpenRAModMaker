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
			var path = "C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods\\ra\\mod.yaml";
			//var modPackage = new ModDirectory();
			//var manifest = modPackage.ReadManifest("C:\\work\\games\\OpenRAModMaker\\OpenRA\\mods\\ra", "ra");
			//Assert.IsNotNull(manifest);
			var manifest = new Manifest(path);

			Assert.IsNotNull(manifest);
		}
	}
}
