using System;
using System.IO;
using NUnit.Framework;

namespace CleanCode
{
	[TestFixture]
	public class ChessTest
	{
		[Test]
		public void Test()
		{
			var testsCount = 0;
			foreach (var file in Directory.GetFiles("ChessTests"))
			{
				if (Path.GetExtension(file) != string.Empty) continue;
				using (var f = File.OpenText(file))
				{
					var actualAnswer = new Chess(new Board(f)).GetWhiteStatus();
					var expectedAnswer = File.ReadAllText(file + ".ans").Trim();
					Assert.AreEqual(expectedAnswer, actualAnswer, "error in file " + file);
				}
				testsCount++;
			}
			Console.WriteLine("Tests count: " + testsCount);
		}
	}
}